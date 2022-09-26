using System;

namespace AloVoIP.OpenCRM.Requests
{
    public class SubmitVotingRequest
    {
        public long VotingResultId { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string VotingCode { get; set; }
        public string QuestionCode { get; set; }
        public string QuestionIndex { get; set; }
        public string PeerCode { get; set; }
        public string QueueCode { get; set; }
        public string QueueName { get; set; }
        public string PhoneNumber { get; set; }
        public string CallerIdNum { get; set; }
        public string CallerIdName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerNo { get; set; }
        public long CallId { get; set; }
        public long CallChannelId { get; set; }
        public string Input { get; set; }
        public bool IsValid { get; set; }
    }
}
