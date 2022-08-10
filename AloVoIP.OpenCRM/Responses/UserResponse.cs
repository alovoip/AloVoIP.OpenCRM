using AloVoIP.OpenCRM.Enums;

namespace AloVoIP.OpenCRM.Responses
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string IdentityId { get; set; }
        public string NickName { get; set; }
        public string TelephonyPassword { get; set; }
        public string Key { get; set; }
        public string Username { get; set; }
        public UserType? UserType { get; set; }
        public LineResponse[] Lines { get; set; }
        public UserGroupResponse[] UserGroups { get; set; }
    }
}
