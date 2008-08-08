using System;
using Gtk;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Gui {
    public class ChatWindow : Gtk.Window {
        private Gtk.ActionGroup ActionGroup;
        private Gtk.UIManager UiManager;
        
        private Gtk.Table Table;
        private Gtk.Paned MainPaned;
        
        // MenuBar
        private Gtk.Widget MenuBar;
        
        // Menus
        private Gtk.Action LogopathyMenu;
        private Gtk.Action EditMenu;
        private Gtk.Action ServerMenu;
        private Gtk.Action ChannelMenu;
        private Gtk.Action HelpMenu;
        
        // Logopathy menu
        private Gtk.Action CloseAction;
        
        // Edit menu
        private Gtk.Action CopyAction;
        
        // Server menu
        private Gtk.Action ConnectAction;
        
        // Channel menu
        private Gtk.Action JoinAction;
        
        // Help menu
        private Gtk.Action HelpAction;
        
        private Gtk.VPaned LeftSidebar;
        
        private Logopathy.Gui.ServerListView ServerView;
        private Gtk.ScrolledWindow ServerViewSW;
        
        private Logopathy.Gui.UserView UserView;
        private Gtk.ScrolledWindow UserViewSW;
        
        private Logopathy.Gui.ChatNotebook ChatNotebook;
        
        public ChatWindow() : base(Gtk.WindowType.Toplevel) {
            this.Title = "#gnome-hackers on irc.gimp.net - Logopathy";
            this.DeleteEvent += OnDeleteEvent;
            
            this.Table = new Gtk.Table(5, 5, false);
            this.Add(this.Table);
            
            this.ActionGroup = new Gtk.ActionGroup("General");
            SetUpActionGroup();
            
            UiManager = new Gtk.UIManager();
            UiManager.InsertActionGroup(this.ActionGroup, 0);
            AddAccelGroup(UiManager.AccelGroup);
            SetUpUiManager();
            
            this.MenuBar = UiManager.GetWidget("/MenuBar");
            this.Table.Attach(this.MenuBar, 0, 5, 0, 1, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 0, 0);
            
            MainPaned = new Gtk.HPaned();
            this.Table.Attach(MainPaned, 0, 5, 1, 2);
            
            LeftSidebar = new Gtk.VPaned();
            MainPaned.Pack1(LeftSidebar, true, true);
            
            ServerView = new Logopathy.Gui.ServerListView();
            ServerViewSW = new Gtk.ScrolledWindow(new Gtk.Adjustment(0, 0, 0, 0, 0, 0), new Gtk.Adjustment(0, 0, 0, 0, 0, 0));
            ServerViewSW.Add(ServerView);
            LeftSidebar.Pack1(ServerViewSW, true, true);
            
            UserView = new Logopathy.Gui.UserView();
            UserViewSW = new Gtk.ScrolledWindow(new Gtk.Adjustment(0, 0, 0, 0, 0, 0), new Gtk.Adjustment(0, 0, 0, 0, 0, 0));
            UserViewSW.Add(UserView);
            LeftSidebar.Pack2(UserViewSW, true, true);
            
            ChatNotebook = new Logopathy.Gui.ChatNotebook(new TpServer());
            MainPaned.Pack2(ChatNotebook, true, true);
        }
        
        private void OnDeleteEvent(object obj, EventArgs args) {
            Logopathy.Core.Application.Quit();
        }
        
        private void SetUpActionGroup() {
            // Menus
            LogopathyMenu = new Gtk.Action("LogopathyMenu", "_Logopathy", null, null);
            this.ActionGroup.Add(LogopathyMenu);
            
            EditMenu = new Gtk.Action("EditMenu", "_Edit", null, null);
            this.ActionGroup.Add(EditMenu);
            
            ServerMenu = new Gtk.Action("ServerMenu", "_Server", null, null);
            this.ActionGroup.Add(ServerMenu);
            
            ChannelMenu = new Gtk.Action("ChannelMenu", "_Channel", null, null);
            this.ActionGroup.Add(ChannelMenu);
            
            HelpMenu = new Gtk.Action("HelpMenu", "_Help", null, null);
            this.ActionGroup.Add(HelpMenu);
            
            // Actions within the Logopathy menu
            CloseAction = new Logopathy.Gui.Actions.CloseAction();
            this.ActionGroup.Add(CloseAction, "<ctrl>w");
            
            // Actions within the Edit menu
            CopyAction = new Logopathy.Gui.Actions.CopyAction();
            this.ActionGroup.Add(CopyAction, "<ctrl>c");
            
            // Actions within the Server menu
            ConnectAction = new Logopathy.Gui.Actions.ConnectAction();
            this.ActionGroup.Add(ConnectAction);
            
            // Actions within the Channel menu
            JoinAction = new Logopathy.Gui.Actions.JoinAction();
            this.ActionGroup.Add(JoinAction);
            
            // Actions within the Help menu
            HelpAction = new Logopathy.Gui.Actions.HelpAction();
            this.ActionGroup.Add(HelpAction);
        }
        
        private void SetUpUiManager() {
                string ui = @"<ui>
        <menubar name='MenuBar'>
            <menu action='LogopathyMenu'>
                <menuitem action='Close'/>
            </menu>
            <menu action='EditMenu'>
                <menuitem action='Copy'/>
            </menu>
            <menu action='ServerMenu'>
                <menuitem action='Connect'/>
            </menu>
            <menu action='ChannelMenu'>
                <menuitem action='Join'/>
            </menu>
            <menu action='HelpMenu'>
                <menuitem action='Help'/>
            </menu>
        </menubar>
        </ui>";
                UiManager.AddUiFromString(ui);
        }
    }
}
