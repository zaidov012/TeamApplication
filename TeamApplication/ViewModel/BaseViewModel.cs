using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using TeamApplication.Commands;
using TeamApplication.Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using Newtonsoft.Json;

namespace TeamApplication.ViewModel
{
    public class BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; } 
        private List<BaseModel> _users { get; set; }
        public ICommand CloseCommand { get; set; }
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

           ReadToFile();
        }

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
    }
}