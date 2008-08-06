using System;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public class TpUser : IUser {
        public string Name;
        public string Nickname;
        
        public event EventHandler StatusChanged;
        
        public TpUser() {
            //FIXME
        }
    }
}