using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        string UserId { get; }
        string RoleIdentity { get; }     
        int PortalId { get; }
        public string Email { get; }   
        public string FullName { get; }      
    }

    /// <summary>
    /// Thông tin danh tính người dùng
    /// </summary>
    public class IndentityUserModel
    {
        /// <summary>
        /// Mã người dùng
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string UserName { get; set; }
        


        /// <summary>
        /// Vai trò mặc định
        /// </summary>
        public string RoleDefault { get; set; }


    }
}
