using AloVoIP.OpenCRM;
using AloVoIP.OpenCRM.Dto;
using AloVoIP.OpenCRM.Enums;
using Newtonsoft.Json;
using PayamGostarClient.TelephonySystem;
using Serilog;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AloVoIP.OpenCRM.General
{
    public class GeneralCallStoreService : ICallStoreService
    {
        public virtual string CallStoreId { get; }
        protected string Host { get; }
        protected string Username { get; }
        protected string Password { get; }
        protected AuthType AuthType { get; }

        public GeneralCallStoreService(string callStoreId, string host, string username, string password, AuthType authType)
        {
            CallStoreId = callStoreId;
            Host = host;
            Username = username;
            Password = password;
            AuthType = authType;
        }

        #region private

        private PhoneCallType ConvertToPgCallType(CallType phoneCallType, CallResult callResult)
        {
            switch (phoneCallType)
            {
                case CallType.Incoming:
                    return callResult == CallResult.Answered
                            ? PhoneCallType.ReceivedCall
                            : PhoneCallType.MissedCall;
                case CallType.Outgoing:
                    return PhoneCallType.OutgoingCall;
                case CallType.Internal:
                    return PhoneCallType.Internal;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private TelephonySystemPeerType ConvertToPgPeerType(PeerType channelOwnerType)
        {
            switch (channelOwnerType)
            {
                case PeerType.Trunk:
                    return TelephonySystemPeerType.Trunk;
                case PeerType.Extension:
                    return TelephonySystemPeerType.Extension;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private PayamGostarClient.TelephonySystem.ChannelResponse ConvertToPgChannelResponseType(Enums.ChannelResponse channelResponse)
        {
            switch (channelResponse)
            {
                case Enums.ChannelResponse.Answered:
                    return PayamGostarClient.TelephonySystem.ChannelResponse.Answered;
                case Enums.ChannelResponse.NotAnswered:
                    return PayamGostarClient.TelephonySystem.ChannelResponse.NotAnswered;
                case Enums.ChannelResponse.Busy:
                    return PayamGostarClient.TelephonySystem.ChannelResponse.Busy;
                case Enums.ChannelResponse.Transfered:
                    return PayamGostarClient.TelephonySystem.ChannelResponse.Transfered;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private ChannelStatus ConvertToPgChannelStatusType(ChannelState channelState)
        {
            switch (channelState)
            {
                case ChannelState.Down:
                case ChannelState.OffHook:
                case ChannelState.Unknown:
                case ChannelState.Busy:
                    return ChannelStatus.Down;
                case ChannelState.PreRing:
                case ChannelState.Ring:
                case ChannelState.Ringing:
                case ChannelState.Dialing:
                case ChannelState.DialingOffhook:
                    return ChannelStatus.Ringing;
                case ChannelState.Up:
                    return ChannelStatus.Up;
                case ChannelState.Hangedup:
                    return ChannelStatus.HangUp;
                default:
                    Log.Error($"Error in converting channelStatus to PayamGostarChannelStatus: {nameof(channelState)}:{channelState}");
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void CallApi(CallRequestDto model)
        {
            using (HttpClient client = new HttpClient())
            {

                var httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(Host),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                };

                if (AuthType == AuthType.Basic)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Username}:{Password}")));
                }

                try
                {
                    var response = client.SendAsync(httpRequestMessage).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Log.Debug("Successs detail:{@httpRequestMessage} ", httpRequestMessage);
                    }
                    else
                    {

                        Log.Debug("{model : @httpRequestMessage} and status code is {@StatusCode} ", httpRequestMessage, response.StatusCode);

                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "detail:{@httpRequestMessage}", httpRequestMessage);
                    throw;
                }
            }
        }

        #endregion

        public CallCreateResultDto CallCreated(string tsKey, bool isLive, string sourceCallId, string number, DateTime date, CallType callType, CallResult callResult, string sourceInitCallChannelId, string sourceInitCallChannelPeerName, PeerType sourceInitCallChannelPeerType)
        {
            var data = new CallCreateModel()
            {
                TsKey = tsKey,
                SourceId = sourceCallId,
                PhoneNumber = number,
                StartDate = date,
                CallTypeIndex = ConvertToPgCallType(callType, callResult),
                InitChannelSourceId = sourceInitCallChannelId,
                InitChannelPeerName = sourceInitCallChannelPeerName,
                InitChannelPeerTypeIndex = ConvertToPgPeerType(sourceInitCallChannelPeerType),
                IsLive = isLive
            };

            var model = new CallRequestDto(CallStoreType.CallCreated, JsonConvert.SerializeObject(data));


            CallApi(model);

            return new CallCreateResultDto()
            {
                CallId = sourceCallId,
                InitCallChannelId = sourceInitCallChannelId
            };
        }

        public CallUpdateResultDto CallUpdated(string callId, bool isLive, string number, DateTime? date, CallType callType, CallResult callResult, string profileId)
        {
            var data = new CallUpdateModel()
            {
                CallId = long.Parse(callId),
                PhoneNumber = number,
                EndDate = date,
                CallTypeIndex = ConvertToPgCallType(callType, callResult),
                IsLive = isLive
            };
            if (!string.IsNullOrEmpty(profileId))
                data.IdentityId = new Guid(profileId);

            var model = new CallRequestDto(CallStoreType.CallUpdated, JsonConvert.SerializeObject(data));
            CallApi(model);
            return new CallUpdateResultDto();

        }

        public string CallChannelCreated(string callId, bool isLive, string peerName, PeerType peerType, string channelId, ChannelState channelState, DateTime createDate)
        {
            var data = new CallChannelCreateModel()
            {
                CallId = long.Parse(callId),
                ChannelPeerName = peerName,
                ChannelPeerTypeIndex = ConvertToPgPeerType(peerType),
                ChannelSourceId = channelId,
                ChannelStatusIndex = ConvertToPgChannelStatusType(channelState),
                CreateDate = createDate,
                IsLive = isLive
            };
            var model = new CallRequestDto(CallStoreType.CallChannelCreated, JsonConvert.SerializeObject(data));
            CallApi(model);
            return channelId;
        }

        public void CallChannelUpdated(string channelId, bool isLive, ChannelState channelState, Enums.ChannelResponse channelResponse, DateTime? connectDate, DateTime? hangupDate, string recordedFileName, string toChangePeerName = "", PeerType? toChangePeerType = null)
        {
            var data = new CallChannelUpdateModel()
            {
                CallChannelId = long.Parse(channelId),
                ChannelStatusIndex = ConvertToPgChannelStatusType(channelState),
                ChannelResponseIndex = ConvertToPgChannelResponseType(channelResponse),
                ConnectDate = connectDate,
                HangupDate = hangupDate,
                RecordedFileName = recordedFileName,
                IsLive = isLive,
                ToChangePeerName = toChangePeerName,
                ToChangePeerTypeIndex = toChangePeerType != null ?
                                 ConvertToPgPeerType(toChangePeerType.Value) :
                                 (TelephonySystemPeerType?)null
            };

            var model = new CallRequestDto(CallStoreType.CallChannelUpdated, JsonConvert.SerializeObject(data));
            CallApi(model);
        }

        public void MergeCall(string tsKey, long sourceCallId, long destCallId)
        {
            var data = new Septa.PayamGostarApiClient.TelephonySystem.CallMergeModel()
            {
                TsKey = tsKey,
                SourceCallId = sourceCallId,
                DestinationCallId = destCallId,
            };
            var model = new CallRequestDto(CallStoreType.MergeCall, JsonConvert.SerializeObject(data));
            CallApi(model);
        }
    }
}
