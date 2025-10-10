using System.ComponentModel.DataAnnotations;

namespace BT3_Nhom3_23WebC.Models
{
    public class UsersModel
    {
        public string Username { get; set; }
        public string Passwork { get; set; }
        public int Role { get; set; } // 1 - Admin, 2 - User
    }
}
