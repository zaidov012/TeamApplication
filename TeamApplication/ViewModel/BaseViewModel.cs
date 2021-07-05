using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using TeamApplication.Commands;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using TeamApplication.Commands;
using TeamApplication.Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using Newtonsoft.Json;

using System.Text.RegularExpressions;
namespace TeamApplication.ViewModel
{
    public class BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        private List<BaseModel> _users { get; set; }
        private object _empty;
        private ICommand? _submitCommand;

        public ICommand SubmitCommand
        {
            set => _submitCommand = value;
            get { return _submitCommand ??= new RelayCommand(CheckInfo); }
        }

        public BaseViewModel()
        {
            _users = new List<BaseModel>();
            _empty = null;


            CloseCommand = new RelayCommand(o =>
            {
                System.Windows.Application.Current.Shutdown();
            }, o => true);

            mycmd = new RelayCommand(o =>
            {
                User user = new User();
                user.name = Name;
                user.surname = Surname;
                user.age = Age;
                user.mail = Mail;
                user.phone_number = Phone;
                user.password = password;
                user.username = username;
                ValidateProps();

                if(username!=null && Name!=null && Surname!=null && password!=null && Phone!=null && Mail!=null)
                {
                    string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                    File.WriteAllText(@"C:\Users\aydin\RiderProjects\TeamApplication\TeamApplication\Resources\users.txt",
                        json);
                    users.Add(user);
                }





            }, o => true);

           ReadToFile();
        }
        public RelayCommand mycmd { get; set; }
        public ICommand CloseCommand { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public string username { get; set; }

        public string password { get; set; }
        public string Mail { get; set; }
        List<User> users = new List<User>();

        private void ReadToFile()
        {
            var info = File.ReadAllText("../../../Resource/users.txt");
            if (info == null) return;
            _users = JsonConvert.DeserializeObject<List<BaseModel>>(info);
        }

        public void CheckInfo(object empty)
        {
            if (Username == null && Password == null) return;
            for (int i = 0; i < _users.Count; i++)
            {
                if (Username == _users[i].username && Password == _users[i].password)
                {
                    // TODO: next work Shemsedin.
                    return;
                }
            }
        }

        private void ValidateProps()
        {
            if (Regex.IsMatch(Mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")==false)
            {
                MessageBox.Show("Write an email adress!!!!!!!!!!!!!");
                 return;
            }
            else if (Name == null)
            {
                MessageBox.Show("I suppose you have name!");

            }
            else if (Surname == null)
            {
                MessageBox.Show("Of course a Surname tooo");

            }
            else if (username == null)
            {
                MessageBox.Show("Wanna get  username for yourself");

            }
            else if (password == null)
            {
                MessageBox.Show("U can`t get in without password");

            }
            else if (Phone == null)
            {
                MessageBox.Show("Go buy a phone number and after come back pls ty");

            }
        }

    }

}