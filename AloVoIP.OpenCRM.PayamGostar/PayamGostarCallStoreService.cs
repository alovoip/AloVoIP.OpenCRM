using AloVoIP.OpenCRM.Dto;
using AloVoIP.OpenCRM.Enums;
using PayamGostarClient;
using Serilog;
using System;

namespace AloVoIP.OpenCRM.PayamGostar
{
    public class PayamGostarCallStoreService : ICallStoreService
    {
        private IPgClient _pgClient;
        private DateTime _nextClientCreateDate;

        public virtual string CallStoreId { get; }
        protected string Host { get; }
        protected string Username { get; }
        protected string Password { get; }

        public PayamGostarCallStoreService(string callStoreId, string host, string username, string password)
        {
            CallStoreId = callStoreId;
            Host = host;
            Username = username;
            Password = password;
        }

        protected IPgClient MyIPgClient
        {
            get
            {
                if (_pgClient == null || _nextClientCreateDate < DateTime.Now)
                {
                    _pgClient = Create(Host, Username, Password);
                    _nextClientCreateDate = DateTime.Now.AddHours(1);
                }

                return _pgClient;
            }
        }

        private IPgClient Create(string endPointAddress, string userName, string password)
        {
            return new PgClientFactory().Create(endPointAddress, new PgCredentials()
            {
                Username = userName,
                Password = password
            });
        }

        public CallCreateResultDto CallCreated(string tsKey, bool isLive, string sourceCallId, string number, DateTime date, CallType callType, CallResult callResult, string sourceInitCallChannelId, string sourceInitCallChannelPeerName, PeerType sourceInitCallChannelPeerType)
        {
            var callCreateResult = MyIPgClient.GetTelephonySystem().CallCreate(new PayamGostarClient.TelephonySystem.CallCreateModel()
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
            });
            return new CallCreateResultDto()
            {
                CallId = callCreateResult.CallId.ToString(),
                InitCallChannelId = callCreateResult.InitChannelId.ToString(),
                ProfileId = callCreateResult.IdentityId.HasValue ? callCreateResult.IdentityId.ToString() : null,
                ProfileName = callCreateResult.IdentityNickName,
            };
        }
        public CallUpdateResultDto CallUpdated(string callId, bool isLive, string number, DateTime? date, CallType callType, CallResult callResult, string profileId)
        {
            var model = new PayamGostarClient.TelephonySystem.CallUpdateModel()
            {
                CallId = long.Parse(callId),
                PhoneNumber = number,
                EndDate = date,
                CallTypeIndex = ConvertToPgCallType(callType, callResult),
                IsLive = isLive
            };
            if (!string.IsNullOrEmpty(profileId))
                model.IdentityId = new Guid(profileId);

            var callupdateResult = MyIPgClient.GetTelephonySystem().CallUpdate(model);
            return new CallUpdateResultDto()
            {
                ProfileId = callupdateResult.IdentityId.HasValue ? callupdateResult.IdentityId.ToString() : null,
                ProfileName = callupdateResult.IdentityNickName,
            };
        }
        public string CallChannelCreated(string callId, bool isLive, string peerName, PeerType peerType, string channelId, ChannelState channelState, DateTime createDate)
        {
            var callChannelCreateResult = MyIPgClient.GetTelephonySystem().CallChannelCreate(new PayamGostarClient.TelephonySystem.CallChannelCreateModel()
            {
                CallId = long.Parse(callId),
                ChannelPeerName = peerName,
                ChannelPeerTypeIndex = ConvertToPgPeerType(peerType),
                ChannelSourceId = channelId,
                ChannelStatusIndex = ConvertToPgChannelStatusType(channelState),
                CreateDate = createDate,
                IsLive = isLive
            });
            return callChannelCreateResult.CallChannelId.ToString();
        }
        public void CallChannelUpdated(string channelId, bool isLive, ChannelState channelState, ChannelResponse channelResponse, DateTime? connectDate, DateTime? hangupDate, string recordedFileName, string toChangePeerName = "", PeerType? toChangePeerType = null)
        {
            MyIPgClient.GetTelephonySystem().CallChannelUpdate(new PayamGostarClient.TelephonySystem.CallChannelUpdateModel()
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
                                            (PayamGostarClient.TelephonySystem.TelephonySystemPeerType?)null
            });
        }
        public void MergeCall(string tsKey, long sourceCallId, long destCallId)
        {
            MyIPgClient.GetTelephonySystem().MergeCall(new Septa.PayamGostarApiClient.TelephonySystem.CallMergeModel()
            {
                TsKey = tsKey,
                SourceCallId = sourceCallId,
                DestinationCallId = destCallId,
            });
        }

        private PayamGostarClient.TelephonySystem.PhoneCallType ConvertToPgCallType(CallType phoneCallType, CallResult callResult)
        {
            switch (phoneCallType)
            {
                case CallType.Incoming:
                    return callResult == CallResult.Answered
                            ? PayamGostarClient.TelephonySystem.PhoneCallType.ReceivedCall
                            : PayamGostarClient.TelephonySystem.PhoneCallType.MissedCall;
                case CallType.Outgoing:
                    return PayamGostarClient.TelephonySystem.PhoneCallType.OutgoingCall;
                case CallType.Internal:
                    return PayamGostarClient.TelephonySystem.PhoneCallType.Internal;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private PayamGostarClient.TelephonySystem.TelephonySystemPeerType ConvertToPgPeerType(PeerType channelOwnerType)
        {
            switch (channelOwnerType)
            {
                case PeerType.Trunk:
                    return PayamGostarClient.TelephonySystem.TelephonySystemPeerType.Trunk;
                case PeerType.Extension:
                    return PayamGostarClient.TelephonySystem.TelephonySystemPeerType.Extension;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private PayamGostarClient.TelephonySystem.ChannelResponse ConvertToPgChannelResponseType(ChannelResponse channelResponse)
        {
            switch (channelResponse)
            {
                case ChannelResponse.Answered:
                    return PayamGostarClient.TelephonySystem.ChannelResponse.Answered;
                case ChannelResponse.NotAnswered:
                    return PayamGostarClient.TelephonySystem.ChannelResponse.NotAnswered;
                case ChannelResponse.Busy:
                    return PayamGostarClient.TelephonySystem.ChannelResponse.Busy;
                case ChannelResponse.Transfered:
                    return PayamGostarClient.TelephonySystem.ChannelResponse.Transfered;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private PayamGostarClient.TelephonySystem.ChannelStatus ConvertToPgChannelStatusType(ChannelState channelState)
        {
            switch (channelState)
            {
                case ChannelState.Down:
                case ChannelState.OffHook:
                case ChannelState.Unknown:
                case ChannelState.Busy:
                    return PayamGostarClient.TelephonySystem.ChannelStatus.Down;
                case ChannelState.PreRing:
                case ChannelState.Ring:
                case ChannelState.Ringing:
                case ChannelState.Dialing:
                case ChannelState.DialingOffhook:
                    return PayamGostarClient.TelephonySystem.ChannelStatus.Ringing;
                case ChannelState.Up:
                    return PayamGostarClient.TelephonySystem.ChannelStatus.Up;
                case ChannelState.Hangedup:
                    return PayamGostarClient.TelephonySystem.ChannelStatus.HangUp;
                default:
                    Log.Error($"Error in converting channelStatus to PayamGostarChannelStatus: {nameof(channelState)}:{channelState}");
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
