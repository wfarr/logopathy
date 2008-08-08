using System;

namespace Logopathy.Core {
    public static class Util {
        public static string MakePrettyDate(DateTime dtdate) {
            string hour;
            string minute;
            string second;
            
            if ( dtdate.Hour.ToString().Length == 1 ) {
                hour = "0"+dtdate.Hour.ToString();
            } else {
                hour = dtdate.Hour.ToString();
            }
            
            if ( dtdate.Minute.ToString().Length == 1 ) {
                minute = "0"+dtdate.Minute.ToString();
            } else {
                minute = dtdate.Minute.ToString();
            }
            
            if ( dtdate.Second.ToString().Length == 1 ) {
                second = "0"+dtdate.Second.ToString();
            } else {
                second = dtdate.Second.ToString();
            }
            
            return hour+":"+minute+":"+second;
        }
    }
}
