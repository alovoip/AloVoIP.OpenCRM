using AloVoIP.OpenCRM.Enums;
namespace AloVoIP.OpenCRM.Dto
{
    public class UserDto : OperationResultDto
    {
        public string Id { get; set; }
        public string IdentityId { get; set; }
        public string NickName { get; set; }
        public string TelephonyPassword { get; set; }
        public string Key { get; set; }
        public string Username { get; set; }
        public UserType? UserType { get; set; }
        public LineDto[] Lines { get; set; }
        public UserGroupDto[] UserGroups { get; set; }
    }
}
