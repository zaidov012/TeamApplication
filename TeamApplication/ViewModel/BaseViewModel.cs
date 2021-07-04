using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using TeamApplication.Commands;
using TeamApplication.Model;
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
            _empty = null;
            CloseCommand = new RelayCommand(o =>
            {
                System.Windows.Application.Current.Shutdown();
            }, o => true);

            ReadToFile();
        }

        private void ReadToFile()
        {
            var info = File.ReadAllLines("users.txt");
            if (info == null) return;
            for (int i = 0; i < info.Length; i++)  { _users.Add(JsonConvert.DeserializeObject<BaseModel>(info[i])); }
        }

        public void CheckInfo(object empty)
        {
            if (Username == null && Password == null) return;
            for (int i = 0; i < _users.Count; i++)
            {
                if (Username == _users[i].Name && Password == _users[i].Password)
                {
                    // Shemsen
                    return;
                }
            }
        }
    }
}