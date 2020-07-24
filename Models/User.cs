using System.ComponentModel.DataAnnotations;

namespace FujiwaraCarShop.Models {
    public class User {
        public User() {

        }
        public User( string name, string login, string password, bool isAdmin) {
            Name = name;
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public override string ToString() {
            return Login.ToString();
        }
    }
}
