using System;

namespace Logopathy.Core {
    public static class Log {
        public static void Message(string message) {
            Logopathy.Core.Application.Log.Add(message);
            
            if ( Logopathy.Core.Application.Log.Count > 100 ) {
                Logopathy.Core.Application.Log.Remove(Logopathy.Core.Application.Log[0]);
            }
        }
        
        public static void Exception(Exception e) {
            Logopathy.Core.Application.Log.Add(e.ToString()+" with message "+message);
            
            if ( Logopathy.Core.Application.Log.Count > 100 ) {
                Logopathy.Core.Application.Log.Remove(Logopathy.Core.Application.Log[0]);
            }
        }
    }
}
