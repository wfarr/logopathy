using System;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public class TpUser : IUser {
        private string name;
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
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
        
        public event EventHandler StatusChanged;
        
        public TpUser() {
            //FIXME
        }
    }
}
