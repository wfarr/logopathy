using System;
using System.Collections;

using Logopathy.Core;

namespace Logopathy.Irc {
    public static class Core {
        public static IServer Connect(string url /*FIXME*/) {
            return new TpServer();
        }
        
        public static ArrayList GetServers() {
            ArrayList a = new ArrayList();
            return a;
        }
        
        public static IAccount RegisterUser(IServer server, string username, string password) {
            return new TpUser();
        }
    }
}
