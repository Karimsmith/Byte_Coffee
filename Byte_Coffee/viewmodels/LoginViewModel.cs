using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Byte_Coffee.viewmodels
{
   public class LoginViewModel:ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _errorMassage;
        private bool _isViewVisible=true;

        public string Username { 
            get 
            { 
                return _username ;
            }
            set {  
                _username = value;
                OnPropwetyCanged(nameof(Username));
            } 
        }
        public SecureString Password {
            get 
            {  
                return _password; 
            }
            set
            { 
                _password = value;
                OnPropwetyCanged(nameof(Password));

            }
        }
        public string ErrorMassage {
            get
            {
                return _errorMassage;
            }
            set
            { 
               _errorMassage = value;
                OnPropwetyCanged(nameof(ErrorMassage));

            }
        }
        public bool IsViewVisible {
            get
            { 
            return _isViewVisible;
            }
            set
            { 
            _isViewVisible = value;
                OnPropwetyCanged(nameof(IsViewVisible));

            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }


        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand( p => ExecuteRecoverPassCommand ("",""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool valiData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                valiData = false;
            else
                valiData = true;
                return valiData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
