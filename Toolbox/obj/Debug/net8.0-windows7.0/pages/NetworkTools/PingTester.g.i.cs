﻿#pragma checksum "..\..\..\..\..\pages\NetworkTools\PingTester.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "978E1F9AFA7C477A88297037352D0DE45F92BB77"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
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


namespace Toolbox.pages {
    
    
    /// <summary>
    /// PingTester
    /// </summary>
    public partial class PingTester : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\..\pages\NetworkTools\PingTester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDomain;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\pages\NetworkTools\PingTester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPing;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\pages\NetworkTools\PingTester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart pingChart;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\pages\NetworkTools\PingTester.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbResults;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Toolbox;V1.0.0.0;component/pages/networktools/pingtester.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\pages\NetworkTools\PingTester.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtDomain = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\..\..\pages\NetworkTools\PingTester.xaml"
            this.txtDomain.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtDomain_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnPing = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\..\pages\NetworkTools\PingTester.xaml"
            this.btnPing.Click += new System.Windows.RoutedEventHandler(this.btnPing_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.pingChart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 4:
            this.lbResults = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

