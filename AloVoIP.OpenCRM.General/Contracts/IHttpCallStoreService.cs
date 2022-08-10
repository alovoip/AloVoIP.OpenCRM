using AloVoIP.OpenCRM.Requests;
using AloVoIP.OpenCRM.Responses;
using Refit;
using System.Threading.Tasks;

namespace AloVoIP.OpenCRM.General.Contracts
{
    public interface IHttpCallStoreService
    {
        [Post("/CallCreated")]
        Task<CallCreateResponse> CallCreated([Body] CallCreateRequest callCreateRequest);

        [Post("/CallUpdated")]
        Task<CallUpdateResponse> CallUpdated([Body] CallUpdateRequest callUpdateRequest);

        [Post("/CallChannelCreated")]
        Task<CallChannelCreateResponse> CallChannelCreated([Body] CallChannelCreateRequest callChannelCreateRequest);

        [Post("/CallChannelUpdated")]
        Task<CallChannelUpdateResponse> CallChannelUpdated([Body] CallChannelUpdateRequest callChannelUpdateRequest);

        [Post("/MergeCall")]
        Task<MergeCallResponse> MergeCall([Body] MergeCallRequest mergeCallRequest);
    }
}
