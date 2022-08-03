using AloVoIP.OpenCRM.Dto;
using AloVoIP.OpenCRM.Enums;
using System;

namespace AloVoIP.OpenCRM
{
    public interface ICallStoreService
    {
        string CallStoreId { get; }
        CallCreateResultDto CallCreated(string tsKey, bool isLive, string sourceCallId, string number, DateTime date, CallType callType, CallResult callResult, string sourceInitCallChannelId, string sourceInitCallChannelPeerName, PeerType sourceInitCallChannelPeerType);
        CallUpdateResultDto CallUpdated(string callId, bool isLive, string number, DateTime? date, CallType callType, CallResult callResult, string profileId);

        string CallChannelCreated(string callId, bool isLive, string peerName, PeerType peerType, string sourceCallChannelId, ChannelState channelState, DateTime createDate);
        void CallChannelUpdated(string channelId, bool isLive, ChannelState channelState, ChannelResponse channelResponse, DateTime? connectDate, DateTime? hangupDate, string RecordedFileName, string toChangePeerName = "", PeerType? toChangePeerType = null);

        void MergeCall(string tsKey, long sourceCallId, long destCallId);
    }
}
