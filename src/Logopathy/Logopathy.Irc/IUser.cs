using System;

namespace Logopathy.Irc {
    public interface IUser {
        string Name;
        string Nickname;
        
        // there should be some sort of enum to tell whether they're an op and whatnot
    }
}
