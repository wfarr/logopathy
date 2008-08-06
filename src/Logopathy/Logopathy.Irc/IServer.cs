using System;
using System.Collections;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public interface IServer {
        string Name;
        string Url;
        
        ArrayList<IChat> ActiveChats;
    }
}
