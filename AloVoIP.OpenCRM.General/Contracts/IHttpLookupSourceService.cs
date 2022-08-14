using AloVoIP.OpenCRM.Requests;
using AloVoIP.OpenCRM.Responses;
using Refit;
using System;
using System.Threading.Tasks;

namespace AloVoIP.OpenCRM.General.Contracts
{
    public interface IHttpLookupSourceService : IHttpCallStoreService, IDisposable
    {
        [Post("/GetMoneyAccounts")]
        Task<MoneyAccountsResponse> GetMoneyAccounts();

        [Post("/GetBillableObjectTypes")]
        Task<BillableObjectTypesResponse> GetBillableObjectTypes();

        [Post("/GetCardtable")]
        Task<CardtableResponse> GetCardtable(CardtableRequest cardtableRequest);

        [Post("/GetPaymentInfo")]
        Task<PaymentResponse> GetPaymentInfo(PaymentInfoRequest paymentInfoRequest);

        [Post("/GetIdentityByCustomerInfo")]
        Task<IdentityResponse> GetIdentityByCustomerInfo(CustomerRequest customerRequest);

        [Post("/GetCustomerBalance")]
        Task<CustomerBalanceResponse> GetCustomerBalance(CustomerRequest customerRequest);

        [Post("/GetUserDefaultExtension")]
        Task<UserExtensionResponse> GetUserDefaultExtension(UserExtensionRequest userExtensionRequest);

        [Post("/CreateInvoice")]
        Task<CreateInvoiceResponse> CreateInvoice(CreateSalesInvoiceRequest createSalesInvoiceRequest);

        [Post("/GetUserInfoByIdentityId")]
        Task<UserResponse> GetUserInfoByIdentityId(UserInfoByIdentityRequest userInfoByIdentityRequest);

        [Post("/GetUserExtensions")]
        Task<UserTelephonySystemResponse> GetUserExtensions(UserExtensionsRequest userExtenstionsRequest);

        [Post("/EncryptCrmObjectAsync")]
        Task<EncryptCrmObjectResponse> EncryptCrmObjectAsync(EncryptCrmObjectRequest encryptCrmObjectRequest);

        [Post("/GetIdentityByPhoneNumber")]
        Task<IdentityResponse> GetIdentityByPhoneNumber(IdentityByPhoneNumberRequest identityByPhoneNumberRequest);

        [Post("/GetIdentityByCustomerNumber")]
        Task<IdentityResponse> GetIdentityByCustomerNumber(IdentityByCustomerNumberRequest identityByCustomerNumberRequest);

        [Post("/SendPaymentLinkToUser")]
        Task<SendPaymentLinkToUserResponse> SendPaymentLinkToUser(SendPaymentLinkToUserRequest sendPaymentLinkToUserRequest);

        [Post("/GetUserManagerExtension")]
        Task<UserExtensionResponse> GetUserManagerExtension(UserManagerByExtensionRequest userManagerByExtensionRequest);

        [Post("/BillableObjectTypePropsResponse")]
        Task<BillableObjectTypePropsResponse> GetBillableObjectTypeProps(BillableObjectTypePropsRequest billableObjectTypePropsRequest);

        [Post("/IdentityHasValidContract")]
        Task<IdentityHasValidContractResponse> IdentityHasValidContract(IdentityHasValidContractRequest identityHasValidContractRequest);

        [Post("/IdentityHasValidContract")]
        Task<CrmObjectUrlResponse> GetCrmObjectUrl(CrmObjectUrlRequest crmObjectUrlRequest);
    }
}