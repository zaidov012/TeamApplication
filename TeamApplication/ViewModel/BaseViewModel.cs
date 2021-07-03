using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using TeamApplication.Commands;
using TeamApplication.Model;
using System.Text.RegularExpressions;
namespace TeamApplication.ViewModel
{
    public class BaseViewModel
    {
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

        public BaseViewModel()
        {
            
            
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