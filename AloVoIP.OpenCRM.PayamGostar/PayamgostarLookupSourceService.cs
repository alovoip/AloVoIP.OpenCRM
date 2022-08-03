using AloVoIP.OpenCRM.Dto;
using AloVoIP.OpenCRM.PayamGostar.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PgContractService;
using PgCrmObjectService;
using PgCrmObjectTypeService;
using PgEPayService;
using PgIdentityService;
using PgInvoiceService;
using PgMoneyAccountService;
using PgUserService;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AloVoIP.OpenCRM.PayamGostar
{
    public class PayamgostarLookupSourceService : PayamGostarCallStoreService, ILookupSourceService
    {
        int lookupSourceId;
        string lookupSourceHost;
        string lookupSourceUsername;
        string lookupSourcePassword;
        public PayamgostarLookupSourceService(int id, string host, string username, string password)
            : base(id.ToString(), host, username, password)
        {
            lookupSourceId = id;
            lookupSourceHost = host;
            lookupSourceUsername = username;
            lookupSourcePassword = password;
        }

        public ICrmObjectTypeChannel CreateCrmObjectTypeClient()
        {
            return new PayamgostarServiceClientFactory<ICrmObjectTypeChannel>().Create(Host);
        }
        public ICrmObjectChannel CreateCrmObjectChannelClient()
        {
            return new PayamgostarServiceClientFactory<ICrmObjectChannel>().Create(Host);
        }
        public IIdentityChannel CreateIdentityChannelClient()
        {
            return new PayamgostarServiceClientFactory<IIdentityChannel>().Create(Host);
        }
        public IUserChannel CreateUserChannelClient()
        {
            return new PayamgostarServiceClientFactory<IUserChannel>().Create(Host);
        }
        public IContractChannel CreateContractChannelClient()
        {
            return new PayamgostarServiceClientFactory<IContractChannel>().Create(Host);
        }
        public IEpayChannel CreateEpayClient()
        {
            return new PayamgostarServiceClientFactory<IEpayChannel>().Create(Host);
        }
        public IInvoiceChannel CreateInvoiceClient()
        {
            return new PayamgostarServiceClientFactory<IInvoiceChannel>().Create(Host);
        }
        public IMoneyAccountChannel CreateMoneyAccountClient()
        {
            return new PayamgostarServiceClientFactory<IMoneyAccountChannel>().Create(Host);
        }

        public IdentityDto GetIdentityByPhoneNumber(string phoneNumber)
        {
            try
            {
                using (var identityChannel = CreateIdentityChannelClient())
                {
                    return identityChannel.FindIdentityByPhoneNumber(Username, Password, phoneNumber).IdentityInfo.ToDto();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error in GetIdentityByPhoneNumber. phoneNumber:{phoneNumber}");
            }

            Log.Debug($"GetIdentityByPhoneNumber, FindIdentityByPhoneNumber result is null. {nameof(phoneNumber)}:{phoneNumber}");
            return null;
        }

        public IdentityDto GetIdentityByCustomerNumber(string customerNumber)
        {
            try
            {
                using (var identityChannel = CreateIdentityChannelClient())
                {
                    var result = identityChannel.SearchIdentity(Username, Password, string.Empty, $"CustomerNumber==\"{customerNumber}\"");
                    if (result.Success)
                    {
                        if (result.IdentityInfoList.Length == 0)
                        {
                            Log.Debug($"GetIdentityByCustomerNumber, SearchIdentity result is success but identityInfoList is empty. {nameof(customerNumber)}:{customerNumber}");
                            return null;
                        }
                        else
                            return result.IdentityInfoList[0].ToDto();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error in GetIdentityByCustomerNumber. customerNumber:{customerNumber}");
            }

            Log.Debug($"GetIdentityByCustomerNumber, SearchIdentity result is null. {nameof(customerNumber)}:{customerNumber}");
            return null;
        }

        public IdentityDto GetIdentityByCustomerInfo(CustomerDto customerInfo)
        {
            try
            {
                Guid customerId;
                if (Guid.TryParse(customerInfo.CustomerId, out customerId))
                {
                    using (var identityChannel = CreateIdentityChannelClient())
                    {
                        return identityChannel.FindIdentityById(Username, Password, customerId).IdentityInfo.ToDto();
                    }
                }
                if (string.IsNullOrEmpty(customerInfo.CustomerNo))
                {
                    return GetIdentityByCustomerNumber(customerInfo.CustomerNo);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in GetIdentityByCustomerInfo. customerInfo: {@customerInfo}", customerInfo);
            }

            Log.Debug("GetIdentityByCustomerInfo result is null. {@customerInfo}", customerInfo);
            return null;
        }

        public UserDto GetUserInfoByIdentityId(string identityId)
        {
            try
            {
                using (var userChannel = CreateUserChannelClient())
                {
                    return userChannel.GetUserByIdentityId(Username, Password, new Guid(identityId)).ToDto();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in GetUserInfoByIdentityInfo. identityId: {identityId}", identityId);
            }

            Log.Debug("GetUserInfoByIdentityInfo, GetUserByIdentityId result is null. {identityId}", identityId);
            return null;
        }

        public bool IdentityHasValidContract(CustomerDto customerInfo, string contractKey)
        {
            try
            {
                using (var contractChannel = CreateContractChannelClient())
                {
                    var contracts = contractChannel.SearchContract(Username, Password, contractKey, $"IdentityId==\"{customerInfo.CustomerId}\"");
                    if (!contracts.Success)
                    {
                        Log.Debug("IdentityHasValidContract, SearchContract result is not success. customerInfo:{@customerInfo}, contractKey:{contractKey}", customerInfo, contractKey);
                        return false;
                    }

                    foreach (var contract in contracts.ContractInfoList)
                    {
                        if (contract.EndDate != null)
                        {
                            if (contract.EndDate.Value.Date.AddDays(1) > DateTime.Now)
                            {
                                if (contract.BillableObjectState == "User.GeneralPropertyItem.BillableObjectState_2" || contract.BillableObjectState == "تایید و شماره گذاری شده")
                                    return true;
                                else
                                    Log.Debug("IdentityHasValidContract, SearchContract found but BillableObjectState is not 'User.GeneralPropertyItem.BillableObjectState_2' or 'تایید و شماره گذاری شده'. customerInfo:{@customerInfo}, contractKey:{@contractKey}", customerInfo, contractKey);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in IdentityHasValidContract. customerInfo: {@customerInfo}, contractKey: {@contractKey}", customerInfo, contractKey);
            }

            Log.Debug("IdentityHasValidContract result is false. customerInfo:{@customerInfo}, contractKey:{@contractKey}", customerInfo, contractKey);
            return false;
        }

        public UserTelephonySystemDto GetUserExtenstions(string username)
        {
            Log.Debug($"GetUserExtenstions. username:{username}");

            try
            {
                using (var userChannel = CreateUserChannelClient())
                {
                    return userChannel.GetUserExtensions(Username, Password, username).ToDto();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error in GetUserExtenstions. username:{username}");
            }

            Log.Debug($"GetUserExtenstions, GetUserExtensions result is null. {nameof(username)}:{username}");
            return null;
        }

        public string GetUserExtenstion(string username, string telephonySystemKey)
        {
            Log.Debug($"GetUserExtenstion. username:{username}, telephonySystemKey:{telephonySystemKey}");

            try
            {
                using (var userChannel = CreateUserChannelClient())
                {
                    var userTelephonySystemInfo = userChannel.GetUserExtensions(Username, Password, username);
                    if (userTelephonySystemInfo != null &&
                        userTelephonySystemInfo.TelephonySystems != null &&
                        userTelephonySystemInfo.TelephonySystems.Length > 0)
                    {
                        var telephonySystem = userTelephonySystemInfo.TelephonySystems.FirstOrDefault(x => x.Key == telephonySystemKey);
                        if (telephonySystem != null)
                        {
                            var extensions = telephonySystem.Extensions;
                            if (extensions != null && extensions.Length > 0)
                            {
                                return extensions.First().Name;
                            }
                            else
                            {
                                Log.Debug($"GetUserExtenstion, TelephonySystem extension is null or empty.");
                            }
                        }
                        else
                        {
                            Log.Debug($"GetUserExtenstion, TelephonySystem is not found with the given key.");
                        }
                    }
                    else
                    {
                        Log.Debug($"GetUserExtenstion, UserTelephonySystemInfo is null or empty.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error in GetUserExtenstion, username:{username}, telephonySystemKey:{telephonySystemKey}");
            }

            Log.Debug($"GetUserExtenstion, GetUserExtensions result is empty. {nameof(username)}:{username}, {nameof(telephonySystemKey)}:{telephonySystemKey}");
            return string.Empty;
        }

        public CardtableResultDto GetCardtable(string crmObjectTypeKey, string identityId)
        {
            Log.Debug($"GetCardtable. crmObjectTypeKey:{crmObjectTypeKey}, identityId:{identityId}");

            try
            {

                using (var crmObjectTypeChannel = CreateCrmObjectTypeClient())
                {
                    return crmObjectTypeChannel.GetCardtable(Username,
                                                             Password,
                                                             null,
                                                             null,
                                                             crmObjectTypeKey,
                                                             new Guid(identityId),
                                                             SortOperator.Desc,
                                                             0,
                                                             1).ToDto();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"GetCardtable, crmObjectTypeKey:{crmObjectTypeKey}, identityId:{identityId}");
            }

            return null;
        }

        public string GetUserManagerExtenstionBy(int tsId, string userExtenstion)
        {
            Log.Debug($"GetUserManagerExtenstionBy. {nameof(tsId)}:{tsId}, {nameof(userExtenstion)}:{userExtenstion}");

            try
            {
                using (var userChannel = CreateUserChannelClient())
                {
                    var result = userChannel.GetUserHelperExtensionBy(Username,
                                                                      Password,
                                                                      userExtenstion);
                    if (result.Success)
                        return result.HelperExtension;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"GetUserManagerExtenstionBy. {nameof(userExtenstion)}:{userExtenstion}");
            }

            Log.Debug($"GetUserManagerExtenstionBy result is null. {nameof(tsId)}:{tsId}, {nameof(userExtenstion)}:{userExtenstion}");
            return null;
        }


        public decimal? GetCustomerBalance(CustomerDto customerInfo)
        {
            try
            {
                Guid customerId;
                if (Guid.TryParse(customerInfo.CustomerId, out customerId))
                {
                    using (var identityChannel = CreateIdentityChannelClient())
                    {
                        var identityInfoResult = identityChannel.FindIdentityById(Username, Password, new Guid(customerInfo.CustomerId));
                        if (identityInfoResult.Success &&
                            identityInfoResult.IdentityInfo != null &&
                            identityInfoResult.IdentityInfo.Balance.HasValue &&
                            identityInfoResult.IdentityInfo.Balance.Value < 0)
                        {
                            return Math.Abs(identityInfoResult.IdentityInfo.Balance.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in GetCustomerBalance. customerInfo: {@customerInfo}", customerInfo);
            }

            Log.Debug("GetCustomerBalance result is null. customerInfo:{@customerInfo}", customerInfo);
            return null;
        }
        private PaymentDto GetInvoiceInfo(CustomerDto customerInfo, string billableObjectTypeKey, string billableObjectNumber, string lookupNumberFieldKey, string valueFieldKey)
        {
            PaymentDto paymentDto = null;

            var query = string.Empty;

            if (customerInfo != null)
            {
                Guid customerId;
                if (Guid.TryParse(customerInfo.CustomerId, out customerId))
                {
                    query = $"IdentityId==\"{customerId}\" & ";
                }
            }

            // LookupNumberFieldKey
            if (string.IsNullOrEmpty(lookupNumberFieldKey))
                query = $"Number==\"{billableObjectNumber}\"";
            else
                query = $"{lookupNumberFieldKey}==\"{billableObjectNumber}\"";

            using (var invoiceChannel = CreateInvoiceClient())
            {
                var invoiceInfoResult = invoiceChannel.SearchInvoice(Username,
                                                                     Password,
                                                                     billableObjectTypeKey,
                                                                     query);
                if (invoiceInfoResult.Success &&
                    invoiceInfoResult.InvoiceInfoList != null &&
                    invoiceInfoResult.InvoiceInfoList.Length > 0)
                {
                    var invoice = invoiceInfoResult.InvoiceInfoList[0];

                    paymentDto = new PaymentDto();
                    if (invoice.IdentityId.HasValue)
                        paymentDto.IdentityId = invoice.IdentityId.Value.ToString();

                    if (string.IsNullOrEmpty(valueFieldKey))
                    {
                        paymentDto.Amount = invoice.FinalValue;
                    }
                    else
                    {
                        decimal res = 0;
                        var contractInfoType = invoice.GetType();
                        if (decimal.TryParse(contractInfoType.GetProperty(valueFieldKey).GetValue(invoice).ToString(), out res))
                            paymentDto.Amount = res;
                    }
                }

                return paymentDto;
            }
        }
        private PaymentDto GetContractInfo(CustomerDto customerInfo, string billableObjectTypeKey, string billableObjectNumber, string lookupNumberFieldKey, string valueFieldKey)
        {
            PaymentDto paymentDto = null;

            var query = string.Empty;

            if (customerInfo != null)
            {
                Guid customerId;
                if (Guid.TryParse(customerInfo.CustomerId, out customerId))
                {
                    query = $"IdentityId==\"{customerId}\" & ";
                }
            }

            // LookupNumberFieldKey
            if (string.IsNullOrEmpty(lookupNumberFieldKey))
                query = $"Number==\"{billableObjectNumber}\"";
            else
                query = $"{lookupNumberFieldKey}==\"{billableObjectNumber}\"";

            using (var contractChannel = CreateContractChannelClient())
            {
                var contractInfoResult = contractChannel.SearchContract(Username,
                                                                        Password,
                                                                        billableObjectTypeKey,
                                                                        query);
                if (contractInfoResult.Success &&
                    contractInfoResult.ContractInfoList != null &&
                    contractInfoResult.ContractInfoList.Length > 0)
                {
                    paymentDto = new PaymentDto();

                    if (contractInfoResult.ContractInfoList[0].IdentityId.HasValue)
                        paymentDto.IdentityId = contractInfoResult.ContractInfoList[0].IdentityId.Value.ToString();

                    if (string.IsNullOrEmpty(valueFieldKey))
                    {
                        paymentDto.Amount = contractInfoResult.ContractInfoList[0].FinalValue;
                    }
                    else
                    {
                        decimal res = 0;
                        var contractInfoType = contractInfoResult.ContractInfoList[0].GetType();
                        if (decimal.TryParse(contractInfoType.GetProperty(valueFieldKey).GetValue(contractInfoResult.ContractInfoList[0]).ToString(), out res))
                            paymentDto.Amount = res;
                    }
                }

                return paymentDto;
            }
        }
        public PaymentDto GetPaymentInfo(CustomerDto customerInfo, string billableObjectTypeKey, string billableObjectNumber, string lookupNumberFieldKey, string valueFieldKey)
        {
            try
            {
                using (var crmObjectType = CreateCrmObjectTypeClient())
                {
                    var crmObjectTypeInfo = crmObjectType.GetCrmObjectTypeInfo(Username, Password, billableObjectTypeKey);
                    if (crmObjectTypeInfo != null)
                    {
                        Log.Debug("PayamgostarLookupSourceService GetPaymentInfo. customerInfo:{@customerInfo}, billableObjectTypeKey:{@billableObjectTypeKey}, billableObjectNumber:{@billableObjectNumber}, lookupNumberFieldKey:{@lookupNumberFieldKey}, valueFieldKey:{@valueFieldKey}, CrmObjectType:{@CrmObjectType}", customerInfo, billableObjectTypeKey, billableObjectNumber, lookupNumberFieldKey, valueFieldKey, crmObjectTypeInfo.CrmObjectType);

                        switch (crmObjectTypeInfo.CrmObjectType)
                        {
                            case CrmObjectTypes.Invoice:
                                return GetInvoiceInfo(customerInfo, billableObjectTypeKey, billableObjectNumber, lookupNumberFieldKey, valueFieldKey);
                            case CrmObjectTypes.Quote:
                                break;
                            case CrmObjectTypes.Receipt:
                                break;
                            case CrmObjectTypes.Contract:
                                return GetContractInfo(customerInfo, billableObjectTypeKey, billableObjectNumber, lookupNumberFieldKey, valueFieldKey);
                            case CrmObjectTypes.PurchaseInvoice:
                                break;
                            case CrmObjectTypes.ReturnPurchaseInvoice:
                                break;
                            case CrmObjectTypes.ReturnSaleInvoice:
                                break;
                            case CrmObjectTypes.PurchaseQuote:
                                break;
                            case CrmObjectTypes.Payment:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error in GetPaymentInfo, billableObjectNumber:{billableObjectNumber}, billableObjectTypeKey:{billableObjectTypeKey}, lookupNumberFieldKey:{lookupNumberFieldKey}");
            }

            return null;
        }

        public bool SendPaymentLinkToUser(PaymentDto paymentInfo, string mobileNumber, string moneyAccountUserKey, out string resultMessage)
        {
            resultMessage = string.Empty;
            try
            {
                var paymentLinkInfo = new PaymentLinkInfo()
                {
                    IdentityId = new Guid(paymentInfo.IdentityId),
                    Amount = paymentInfo.Amount,
                    ExpireAfterDays = 7,
                    Description = string.Empty,
                    MoneyAccountUserKey = moneyAccountUserKey,
                    MobilePhoneNumber = mobileNumber,
                    //PaymentTypeUserKey=
                };
                using (var epayChannel = CreateEpayClient())
                {
                    var paymentLinkInfoResult = epayChannel.CreatePaymentLink(Username, Password, paymentLinkInfo);
                    Log.Debug("SendPaymentLinkToUser, paymentLinkInfoResult:{@paymentLinkInfoResult}", paymentLinkInfoResult);
                    if (paymentLinkInfoResult.Success)
                    {
                        return true;
                    }
                    else
                    {
                        resultMessage = paymentLinkInfoResult.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
                Log.Error(ex, "Error in SendPaymentLinkToUser. paymentInfo:{@paymentInfo}, mobileNumber:{@mobileNumber}, moneyAccountUserKey{@moneyAccountUserKey}", paymentInfo, mobileNumber, moneyAccountUserKey);
            }

            return false;
        }


        public Dictionary<string, string> GetBillableObjectTypes()
        {
            try
            {
                using (var crmObjectType = CreateCrmObjectTypeClient())
                {
                    var lstCrmObjectType = crmObjectType.GetCrmObjectTypeList(Username, Password, null);
                    if (lstCrmObjectType != null && lstCrmObjectType.CrmObjectTypeList != null && lstCrmObjectType.CrmObjectTypeList.Length > 0)
                    {
                        var crmObjectTypes = new[]
                        {
                        CrmObjectTypes.Invoice,
                        CrmObjectTypes.Quote,
                        CrmObjectTypes.Receipt,
                        CrmObjectTypes.Contract,
                        CrmObjectTypes.PurchaseInvoice,
                        CrmObjectTypes.ReturnPurchaseInvoice,
                        CrmObjectTypes.ReturnSaleInvoice,
                        CrmObjectTypes.PurchaseQuote,
                        CrmObjectTypes.Payment
                    };

                        var lstBillableObjects = lstCrmObjectType.CrmObjectTypeList.Where(x => crmObjectTypes.Contains(x.CrmObjectType) && x.UserKey != "");
                        if (lstBillableObjects != null)
                        {
                            return lstBillableObjects.ToDictionary(x => x.Name, x => x.UserKey);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in GetBillableObjectTypes.");
            }

            return null;
        }
        public Dictionary<string, string> GetBillableObjectTypeProps(string billableObjectTypeKey)
        {
            try
            {
                using (var crmObjectType = CreateCrmObjectTypeClient())
                {
                    var crmObjectTypeInfo = crmObjectType.GetCrmObjectTypeInfo(Username, Password, billableObjectTypeKey);
                    if (crmObjectTypeInfo != null &&
                        crmObjectTypeInfo.PropertyGroups != null &&
                        crmObjectTypeInfo.PropertyGroups.Length > 0 &&
                        crmObjectTypeInfo.PropertyGroups[0].Properties != null &&
                        crmObjectTypeInfo.PropertyGroups[0].Properties.Length > 0)
                    {
                        var propertyDisplayTypes = new[]
                        {
                    PropertyDisplayType.Text,
                    PropertyDisplayType.Currency,
                    PropertyDisplayType.Number
                };

                        var props = crmObjectTypeInfo.PropertyGroups[0].Properties.Where(x => propertyDisplayTypes.Contains(x.PropertyDisplayType.Value));
                        if (props != null)
                            return props.ToDictionary(x => x.Name, x => x.Key);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error in GetBillableObjectTypeProps. billableObjectTypeKey:{billableObjectTypeKey}");
            }

            return null;
        }

        public Dictionary<string, string> GetMoneyAccounts()
        {
            try
            {
                using (var moneyAccountChannel = CreateMoneyAccountClient())
                {
                    var moneyAccountListInfo = moneyAccountChannel.GetMoneyAccountList(Username, Password, 0, 50);
                    if (moneyAccountListInfo != null && moneyAccountListInfo.Items != null && moneyAccountListInfo.Items.Length > 0)
                    {
                        var lstmoneyAccounts = moneyAccountListInfo.Items.Where(x => x.UserKey != "");
                        if (lstmoneyAccounts != null)
                        {
                            return lstmoneyAccounts.ToDictionary(x => x.Name, x => x.UserKey);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in GetMoneyAccounts");
            }

            return null;
        }

        public string CreateInvoice(CreateSalesInvoiceDto invoice)
        {
            var result = MyIPgClient.GetSalesInvoiceClient().CallCreate(invoice.ToSalesInvoiceCreateModel());
            return result.CrmId.ToString();
        }

        public async Task<string> EncryptCrmObjectAsync(string guid)
        {
            var crmId = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Host);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var username = lookupSourceUsername;
                var password = lookupSourcePassword;
                var formContent = new FormUrlEncodedContent(new[]
                {
                  new KeyValuePair<string, string>("grant_type", "password"),
                  new KeyValuePair<string, string>("username", username),
                  new KeyValuePair<string, string>("password", password),
                });

                HttpResponseMessage responseMessage = await client.PostAsync("/api/v2/auth/login", formContent);
                var responseJson = await responseMessage.Content.ReadAsStringAsync();
                var jObj = JObject.Parse(responseJson);
                var token = jObj.GetValue("AccessToken").ToString();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.PostAsync("/api/v2/encryptor/encryptcrmobjectguid?id=" + guid, null);
                if (Res.IsSuccessStatusCode)
                {
                    var crmIdResponse = Res.Content.ReadAsStringAsync().Result;
                    crmId = JsonConvert.DeserializeObject<string>(crmIdResponse);
                }
            }
            return crmId;

        }
        public void Dispose()
        {

        }
    }
}