using System;
using Gtk;

namespace Logopathy.Gui.Actions {
    public class CloseAction : Gtk.Action {
        public CloseAction() : base("Close", "Close window") {
            Tooltip = "Close this window";
            StockId = Gtk.Stock.Close;
            Activated += OnActivated;
        }
        
        private void OnActivated(object obj, EventArgs args) {
            Gtk.Main.Quit();
        }
    }
    
    public class CopyAction : Gtk.Action {
        public CopyAction() : base("Copy", "Copy") {
            Tooltip = "Copy the selected text";
            StockId = Gtk.Stock.Copy;
            Activated += OnActivated;
        }
        
        private void OnActivated(object obj, EventArgs args) {
        }
    }
    
    public class ConnectAction : Gtk.Action {
        public ConnectAction() : base("Connect", "Connect to a new server") {
            StockId = null;
            Activated += OnActivated;
        }
        
        private void OnActivated(object obj, EventArgs args) {
        }
    }
    
    public class JoinAction : Gtk.Action {
        public JoinAction() : base("Join", "Join a new channel") {
            StockId = null;
            Activated += OnActivated;
        }
        
        private void OnActivated(object obj, EventArgs args) {
        }
    }
    
    public class HelpAction : Gtk.Action {
        public HelpAction() : base("Help", "Contents") {
            StockId = Gtk.Stock.Help;
            Activated += OnActivated;
        }
        
        private void OnActivated(object obj, EventArgs args) {
        }
    }
}
