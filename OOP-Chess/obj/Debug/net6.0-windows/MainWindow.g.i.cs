﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4FA041842CD7B337EFBEA2BE83D2D330F027733D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Chess;
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


namespace Chess {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas spielfeld;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbDropdown;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border dropdownContent;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel dropdownInnerContent;
        
        #line default
        #line hidden
        
        
        #line 260 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GameOverOverlay;
        
        #line default
        #line hidden
        
        
        #line 320 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid StartOverlay;
        
        #line default
        #line hidden
        
        
        #line 395 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid NotImplementedOverlay;
        
        #line default
        #line hidden
        
        
        #line 399 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label notImplementedLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OOP-Chess;V1.0.0.0;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.spielfeld = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.cbDropdown = ((System.Windows.Controls.CheckBox)(target));
            
            #line 134 "..\..\..\MainWindow.xaml"
            this.cbDropdown.Checked += new System.Windows.RoutedEventHandler(this.OpenDropdown);
            
            #line default
            #line hidden
            
            #line 136 "..\..\..\MainWindow.xaml"
            this.cbDropdown.Unchecked += new System.Windows.RoutedEventHandler(this.CloseDropdown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dropdownContent = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.dropdownInnerContent = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            
            #line 239 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Resume);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 244 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainMenu);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 249 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 254 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Won);
            
            #line default
            #line hidden
            return;
            case 9:
            this.GameOverOverlay = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            
            #line 281 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Resume);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 293 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainMenu);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 305 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 13:
            this.StartOverlay = ((System.Windows.Controls.Grid)(target));
            return;
            case 14:
            
            #line 343 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Resume);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 353 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.notImplementedYet);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 363 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.notImplementedYet);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 373 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 384 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.notImplementedYet);
            
            #line default
            #line hidden
            return;
            case 19:
            this.NotImplementedOverlay = ((System.Windows.Controls.Grid)(target));
            return;
            case 20:
            this.notImplementedLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

