using AloVoIP.OpenCRM.Enums;
using AloVoIP.OpenCRM.General.Contracts;
using AloVoIP.OpenCRM.Requests;
using AloVoIP.OpenCRM.Responses;
using Refit;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AloVoIP.OpenCRM.General
{
    public class GeneralCallStoreService : ICallStoreService
    {
        protected string Host { get; }
        protected string Username { get; }
        protected string Password { get; }
        protected AuthType AuthType { get; }

        public virtual string CallStoreId { get; }


        public GeneralCallStoreService(string callStoreId, string host, string username, string password, AuthType authType)
        {
            CallStoreId = callStoreId;
            Host = host;
            Username = username;
            Password = password;
            AuthType = authType;
        }
        public async Task<CallCreateResponse> CallCreated([Body] CallCreateRequest callCreateRequest)
        {
            using (var client = CreateClient())
            {
                var api = RestService.For<IHttpCallStoreService>(client);
                return await api.CallCreated(callCreateRequest);
            }
        }
        public async Task<CallUpdateResponse> CallUpdated([Body] CallUpdateRequest callUpdateRequest)
        {
            using (var client = CreateClient())
            {
                var api = RestService.For<IHttpCallStoreService>(client);
                return await api.CallUpdated(callUpdateRequest);
            }
        }
        public async Task<CallChannelCreateResponse> CallChannelCreated([Body] CallChannelCreateRequest callChannelCreateRequest)
        {
            using (var client = CreateClient())
            {
                var api = RestService.For<IHttpCallStoreService>(client);
                return await api.CallChannelCreated(callChannelCreateRequest);
            }
        }
        public async Task<CallChannelUpdateResponse> CallChannelUpdated([Body] CallChannelUpdateRequest callChannelUpdateRequest)
        {
            using (var client = CreateClient())
            {
                var api = RestService.For<IHttpCallStoreService>(client);
                return await api.CallChannelUpdated(callChannelUpdateRequest);
            }
        }
        public async Task<MergeCallResponse> MergeCall([Body] MergeCallRequest mergeCallRequest)
        {
            using (var client = CreateClient())
            {
                var api = RestService.For<IHttpCallStoreService>(client);
                return await api.MergeCall(mergeCallRequest);
            }
        }
        protected virtual HttpClient CreateClient()
        {
            var client = RestService.CreateHttpClient(Host, null);
            if (AuthType == AuthType.Basic)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Username}:{Password}")));
            }
            return client;
        }

    }
}
