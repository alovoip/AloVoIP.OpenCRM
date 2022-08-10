using AloVoIP.OpenCRM.Requests;
using AloVoIP.OpenCRM.Responses;
using System.Threading.Tasks;

namespace AloVoIP.OpenCRM
{
    public interface ICallStoreService
    {
        string CallStoreId { get; set; }
        Task<CallCreateResponse> CallCreated(CallCreateRequest callCreateRequest);
        Task<CallUpdateResponse> CallUpdated(CallUpdateRequest callUpdateRequest);
        Task<CallChannelCreateResponse> CallChannelCreated(CallChannelCreateRequest callChannelCreateRequest);
        Task<CallChannelUpdateResponse> CallChannelUpdated(CallChannelUpdateRequest callChannelUpdateRequest);
        Task<MergeCallResponse> MergeCall(MergeCallRequest mergeCallRequest);
    }
}
