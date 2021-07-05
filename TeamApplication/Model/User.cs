using System.Runtime.CompilerServices;

namespace TeamApplication.Model
{
    public class User
    {
        public string username { get; set; }
        
        public string password { get; set; }
        public string name { get; set; }
        public string surname{ get; set; }
        public int age{ get; set; }
        public string phone_number{ get; set; }
        public string mail{ get; set; }

        public User()
        {
            
        }
    }
}