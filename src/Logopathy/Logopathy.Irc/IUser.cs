using System;

namespace Logopathy.Irc {
    public interface IUser {
        string Name { get; set; }
        string Nickname { get; set; }
        
        UserStatus Status { get; set; }
        
        event EventHandler StatusChanged;
        
        // there should be some sort of enum to tell whether they're an op and whatnot
    }
}
