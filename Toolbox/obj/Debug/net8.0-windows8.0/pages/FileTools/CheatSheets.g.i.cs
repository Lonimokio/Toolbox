﻿#pragma checksum "..\..\..\..\..\pages\FileTools\CheatSheets.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4B26CD31DC475C00FD9410E721AA400136DBB3DE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Toolbox.pages;


namespace Toolbox.pages {
    
    
    /// <summary>
    /// CheatSheets
    /// </summary>
    public partial class CheatSheets : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ViewButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox CheatSheetsNav;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser webBrowser;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox editTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Toolbox;component/pages/filetools/cheatsheets.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.EditButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
            this.EditButton.Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ViewButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
            this.ViewButton.Click += new System.Windows.RoutedEventHandler(this.ViewButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CheatSheetsNav = ((System.Windows.Controls.ListBox)(target));
            
            #line 29 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
            this.CheatSheetsNav.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CheatSheetsNav_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.webBrowser = ((System.Windows.Controls.WebBrowser)(target));
            return;
            case 5:
            this.editTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 40 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateSheetButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 41 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 43 "..\..\..\..\..\pages\FileTools\CheatSheets.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

