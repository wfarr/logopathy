using System;
using System.Collections;

using Gtk;

using Logopathy.Irc;
using Logopathy.Gui;

namespace Logopathy.Core {
    public static class Application {
        public static Logopathy.Gui.ChatWindow ChatWindow;
        
        public static ArrayList Log;
        
        public static void Main() {
            Gtk.Application.Init();
            
            Log = new ArrayList();
            
            ChatWindow = new Logopathy.Gui.ChatWindow();
            ChatWindow.ShowAll();
            
            Gtk.Application.Run();
        }
    }
}
