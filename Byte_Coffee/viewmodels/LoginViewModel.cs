using Byte_Coffee.DB;
using Npgsql;
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
        private Condb condb = new Condb();
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
  

    }
}
