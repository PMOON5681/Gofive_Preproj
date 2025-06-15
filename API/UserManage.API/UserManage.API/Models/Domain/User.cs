﻿namespace UserManage.API.Models.Domain
{
    public class User
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string roleId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Permission permission { get; set; }
    }
}
