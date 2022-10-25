using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs
{
    public class UserDTO
    {
        private String user { get; set; }
        private String password { get; set; }
        private String targetUser { get; set; }

        public UserDTO(string user, string password, string targetUser)
        {
            this.user = user;
            this.password = password;
            this.targetUser = targetUser;
        }
    }
}
