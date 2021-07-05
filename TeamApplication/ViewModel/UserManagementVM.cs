using System;
using System.Windows;
using System.Windows.Input;
using TeamApplication.Commands;
using TeamApplication.Commands;
namespace TeamApplication.ViewModel
{
    public class UserManagementVM
    {
        public ICommand RegisterButton { get; set; }
        public ICommand LogInButton { get; set; }

        public ICommand CloseCommand { get; set; }

        public UserManagementVM()
        {
            RegisterButton = new RelayCommand(o =>
            {
                //TODO: Open Aydin form
            }, o => true);
            
            LogInButton = new RelayCommand(o =>
            {
                //TODO: Open Omer form
            }, o => true);

            CloseCommand = new RelayCommand(o =>
            {
                System.Windows.Application.Current.Shutdown();
            }, o => true);
        }
    }
}