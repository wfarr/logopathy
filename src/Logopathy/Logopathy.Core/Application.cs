using System;
using System.Collections;
using Gtk;

using Logopathy.Core;
using Logopathy.Gui;
using Logopathy.Irc;

namespace Logopathy.Core {
    public static class Application {
        public static ArrayList Log;
        
        public static ChatWindow ChatWindow;
        
        public static void Main() {
            Gtk.Application.Init();
            
            Log = new ArrayList();
            
            ChatWindow = new ChatWindow();
            ChatWindow.ShowAll();
            
            Gtk.Application.Run();
        }
        
        public static void Quit() {
            Gtk.Main.Quit();
        }
    }
}
