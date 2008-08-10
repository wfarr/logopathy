using System;
using System.Collections;

using Logopathy.Core;

namespace Logopathy.Irc {
    public class TpAccount : IAccount {
        private string username;
        public string Username {
            get {
                return username;
            }
            set {
                username = value;
            }
        }
        private string password;
        public string Password {
            get {
                return password;
            }
            set {
                password = value;
            }
        }
        
        private string nickname;
        public string Nickname {
            get {
                return nickname;
            }
            set {
                nickname = value;
            }
        }
        
        private DateTime last_login;
        public DateTime LastLogin {
            get {
                return last_login;
            }
            set {
                last_login = value;
            }
        }
        
        public TpAccount() {
            //FIXME
        }
    }
}
