using AloVoIP.OpenCRM.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AloVoIP.OpenCRM
{
    public interface ILookupSourceService : ICallStoreService, IDisposable
    {
        IdentityDto GetIdentityByPhoneNumber(string phoneNumber);
        IdentityDto GetIdentityByCustomerNumber(string customerNumber);
        IdentityDto GetIdentityByCustomerInfo(CustomerDto customerInfo);
        UserDto GetUserInfoByIdentityId(string identityId);
        bool IdentityHasValidContract(CustomerDto customerInfo, string contractKey);
        string CreateInvoice(CreateSalesInvoiceDto invoice);
        Task<string> EncryptCrmObjectAsync(string guid);
        UserTelephonySystemDto GetUserExtenstions(string username);
        string GetUserExtenstion(string username, string telephonySystemKey);
        CardtableResultDto GetCardtable(string crmObjectTypeKey, string identityId);
        string GetUserManagerExtenstionBy(int tsId, string userExtenstion);
        decimal? GetCustomerBalance(CustomerDto customerInfo);
        PaymentDto GetPaymentInfo(CustomerDto customerInfo, string billableObjectTypeKey, string billableObjectNumber, string lookupNumberFieldKey, string valueFieldKey);
        bool SendPaymentLinkToUser(PaymentDto paymentInfo, string mobileNumber, string moneyAccountUserKey, out string resultMessate);
        Dictionary<string, string> GetBillableObjectTypes();
        Dictionary<string, string> GetBillableObjectTypeProps(string billableObjectTypeKey);
        Dictionary<string, string> GetMoneyAccounts();
    }
}