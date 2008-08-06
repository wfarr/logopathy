using System;
using Gtk;

namespace Logopathy.Gui {
    public class ChatWindow : Gtk.Window {
        private Gtk.ActionGroup ActionGroup;
        private Gtk.UIManager UiManager;
        
        private Gtk.Table Table;
        private Gtk.Paned MainPane;
        
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
        
        // The left sidebar
        private Gtk.VPaned LeftSidebar;
        private Logopathy.Gui.ChannelView ChannelView;
        private Gtk.ScrolledWindow ChannelViewSW;
        private Logopathy.Gui.UserView UserView;
        private Gtk.ScrolledWindow UserViewSW;
        
        // The main view
        private Gtk.Table MainTable;
        
        private Gtk.Label ChannelLabel;
        private Gtk.TextBuffer ChannelBuffer;
        private Gtk.TextView ChannelTextView;
        private Gtk.ScrolledWindow ChannelTextViewSW;
        
        private Gtk.HBox EntryHBox;
        private Gtk.Label EntryNameLabel;
        private Gtk.Entry EntryTextEntry;
        
        public ChatWindow() : base(Gtk.WindowType.Toplevel) {
            this.Title = "#gnome-hackers on irc.gimp.net - Logopathy";
            this.DeleteEvent += OnDeleteEvent;
            
            this.Table = new Gtk.Table(5, 5, false);
            this.Add(this.Table);
            
            ActionGroup = new Gtk.ActionGroup("General");
            SetUpActionGroup();
            
            UiManager = new Gtk.UIManager();
            UiManager.InsertActionGroup(this.ActionGroup, 0);
            AddAccelGroup(UiManager.AccelGroup);
            SetUpUiManager();
            
            this.MenuBar = UiManager.GetWidget("/MenuBar");
            this.Table.Attach(this.MenuBar, 0, 5, 0, 1, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 0, 0);
            
            MainPane = new Gtk.HPaned();
            this.Table.Attach(this.MainPane, 0, 5, 1, 2);
            
            LeftSidebar = new Gtk.VPaned();
            MainPane.Pack1(LeftSidebar, true, true);
            
            ChannelView = new Logopathy.Gui.ChannelView();
            ChannelViewSW = new Gtk.ScrolledWindow(new Gtk.Adjustment(0, 0, 0, 0, 0, 0), new Gtk.Adjustment(0, 0, 0, 0, 0, 0));
            ChannelViewSW.ShadowType = Gtk.ShadowType.In;
            ChannelViewSW.SetPolicy(Gtk.PolicyType.Automatic, Gtk.PolicyType.Automatic);
            ChannelViewSW.Add(ChannelView);
            LeftSidebar.Pack1(ChannelViewSW, true, true);
            
            UserView = new Logopathy.Gui.UserView();
            UserViewSW = new Gtk.ScrolledWindow(new Gtk.Adjustment(0, 0, 0, 0, 0, 0), new Gtk.Adjustment(0, 0, 0, 0, 0, 0));
            UserViewSW.ShadowType = Gtk.ShadowType.In;
            UserViewSW.SetPolicy(Gtk.PolicyType.Automatic, Gtk.PolicyType.Automatic);
            UserViewSW.Add(UserView);
            LeftSidebar.Pack2(UserViewSW, true, true);
            
            MainTable = new Gtk.Table(4, 4, false);
            MainPane.Pack2(MainTable, true, true);
            
            ChannelLabel = new Gtk.Label();
            ChannelLabel.Markup = "<b>#gnome-hackers</b>";
            MainTable.Attach(ChannelLabel, 0, 4, 0, 1, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 0, 0);
            
            string chat = @"(12:29:52 PM) Ethan: Might look cluttered with a sidebar on the right and left, though.
(12:29:58 PM) Will: What about a split pane? Like in Summa?
(12:30:03 PM) Ethan: Okay.
(12:30:05 PM) Will: Channels on top, users on bottom?
(12:42:09 PM) Will: Autotools gets more arcane with each passing secon
(12:42:15 PM) Will: *d
(12:43:02 PM) Ethan: Indeed
(12:43:09 PM) Will: GAPI's worse than most
(12:43:15 PM) Will: because it uses the new bootstrap shit
(12:43:38 PM) Ethan: Ewwie.
(12:43:41 PM) Will: Yeah
(12:45:04 PM) Ethan: I suppose we'll use a GtkTextView for the chat?
(12:45:11 PM) Will: Most likely.
(12:45:15 PM) Ethan: Joy.
(12:45:26 PM) Will: If I feel artsy fartsy at some point in the future, I may make use of WebKit to render it
(12:45:28 PM) Will: for html goodness
(12:45:30 PM) Will: but for now
(12:45:33 PM) Will: textview works
(12:46:15 PM) Ethan: *remembers how to use TextView*
(12:46:30 PM) Will: brb";
            
            
            ChannelBuffer = new Gtk.TextBuffer(new Gtk.TextTagTable());
            ChannelBuffer.Text = chat;
            ChannelTextView = new Gtk.TextView(ChannelBuffer);
            ChannelTextView.WrapMode = Gtk.WrapMode.Word;
            ChannelTextViewSW = new Gtk.ScrolledWindow(new Gtk.Adjustment(0, 0, 0, 0, 0, 0), new Gtk.Adjustment(0, 0, 0, 0, 0, 0));
            ChannelTextViewSW.ShadowType = Gtk.ShadowType.In;
            ChannelTextViewSW.SetPolicy(Gtk.PolicyType.Automatic, Gtk.PolicyType.Automatic);
            ChannelTextViewSW.Add(ChannelTextView);
            MainTable.Attach(ChannelTextViewSW, 0, 4, 1, 2);
            
            EntryHBox = new Gtk.HBox();
            MainTable.Attach(EntryHBox, 0, 4, 2, 3, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 0, 0);
            
            EntryNameLabel = new Gtk.Label();
            EntryNameLabel.Markup = "wfarr";
            EntryHBox.PackStart(EntryNameLabel);
            
            EntryTextEntry = new Gtk.Entry();
            EntryHBox.PackStart(EntryTextEntry);
        }
        
        private void OnDeleteEvent(object obj, EventArgs args) {
            this.Destroy();
            Gtk.Main.Quit();
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
