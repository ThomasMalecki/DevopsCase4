﻿#pragma checksum "..\..\..\..\View\Messages.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7B373730DAB1D94E1FCE41D8DBF620E6BD8B3041"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevopsCase4.View;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DevopsCase4.View {
    
    
    /// <summary>
    /// Messages
    /// </summary>
    public partial class Messages : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\View\Messages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevopsCase4.View.Messages ucMessages;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\View\Messages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSearchPersonChat;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\View\Messages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchPersonChat;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\View\Messages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MessageUserList;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\View\Messages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MessagesList;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\View\Messages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnChatSend;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\View\Messages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtChatMessageBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DevopsCase4;component/view/messages.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Messages.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ucMessages = ((DevopsCase4.View.Messages)(target));
            
            #line 9 "..\..\..\..\View\Messages.xaml"
            this.ucMessages.Loaded += new System.Windows.RoutedEventHandler(this.ucMessages_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnSearchPersonChat = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\View\Messages.xaml"
            this.BtnSearchPersonChat.Click += new System.Windows.RoutedEventHandler(this.BtnSearchPersonChat_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtSearchPersonChat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.MessageUserList = ((System.Windows.Controls.DataGrid)(target));
            
            #line 36 "..\..\..\..\View\Messages.xaml"
            this.MessageUserList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.MessageUserList_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MessagesList = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.BtnChatSend = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\..\View\Messages.xaml"
            this.BtnChatSend.Click += new System.Windows.RoutedEventHandler(this.BtnChatSend_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtChatMessageBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

