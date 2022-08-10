using AloVoIP.OpenCRM.Requests;
using AloVoIP.OpenCRM.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AloVoIP.OpenCRM
{
    public interface ILookupSourceService : ICallStoreService
    {
        Task<IdentityResponse> GetIdentityByCustomerInfo(CustomerRequest customerRequest);
        Task<IdentityResponse> GetIdentityByPhoneNumber(IdentityByPhoneNumberRequest identityByPhoneNumberRequest);
        Task<IdentityResponse> GetIdentityByCustomerNumber(IdentityByCustomerNumberRequest identityByCustomerNumberRequest);
        
        Task<IdentityHasValidContractResponse> IdentityHasValidContract(IdentityHasValidContractRequest identityHasValidContractRequest);

        Task<UserResponse> GetUserInfoByIdentityId(UserInfoByIdentityRequest userInfoByIdentityRequest);
        Task<UserTelephonySystemResponse> GetUserExtensions(UserExtensionsRequest userExtenstionsRequest);
        Task<UserExtensionResponse> GetUserDefaultExtension(UserExtensionRequest userExtensionRequest);
        Task<UserExtensionResponse> GetUserManagerExtension(UserManagerByExtensionRequest userManagerByExtensionRequest);
        Task<CustomerBalanceResponse> GetCustomerBalance(CustomerRequest customerRequest);
        
        Task<CardtableResponse> GetCardtable(CardtableRequest cardtableRequest);
        
        Task<BillableObjectTypesResponse> GetBillableObjectTypes();
        Task<MoneyAccountResponse> GetMoneyAccounts();

        Task<CreateInvoiceResponse> CreateInvoice(CreateSalesInvoiceRequest createSalesInvoiceRequest);
        Task<EncryptCrmObjectResponse> EncryptCrmObjectAsync(EncryptCrmObjectRequest encryptCrmObjectRequest);
        Task<BillableObjectTypePropsResponse> GetBillableObjectTypeProps(BillableObjectTypePropsRequest billableObjectTypePropsRequest);
        Task<PaymentResponse> GetPaymentInfo(PaymentInfoRequest paymentInfoRequest);
        Task<SendPaymentLinkToUserResponse> SendPaymentLinkToUser(SendPaymentLinkToUserRequest sendPaymentLinkToUserRequest);
        Task<CrmObjectUrlResponse> GetCrmObjectUrl(CrmObjectUrlRequest crmObjectUrlRequest);
    }
}