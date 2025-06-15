namespace UserManage.API.Models.Domain
{
    public class Permission
    {
        public string PermissionId { get; set; }
        public bool IsReadable { get; set; }
        public bool IsWriteable { get; set; }
        public bool IsDeleteable { get; set; }
    }
}
