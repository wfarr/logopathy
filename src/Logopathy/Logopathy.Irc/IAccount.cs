using System;
using System.Collections;

using Logopathy.Core;

namespace Logopathy.Irc {
    public interface IAccount {
        string Username { get; set; }
        string Password { get; set; }
        
        string Nickname { get; set; }
        
        DateTime LastLogin { get; set; }
    }
}
