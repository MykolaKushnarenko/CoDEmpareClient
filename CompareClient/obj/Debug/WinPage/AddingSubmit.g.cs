﻿#pragma checksum "..\..\..\WinPage\AddingSubmit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F6E8303023A6C2878CFEA2BDA52DF390637641A7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CoDEmpare.WinPage;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace CoDEmpare.WinPage {
    
    
    /// <summary>
    /// AddingSubmit
    /// </summary>
    public partial class AddingSubmit : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\WinPage\AddingSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TransitioningContent;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\WinPage\AddingSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameAuthor;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\WinPage\AddingSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\WinPage\AddingSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton CsharpLanguage;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\WinPage\AddingSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton JavaLanguage;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\WinPage\AddingSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton CppLanguage;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\WinPage\AddingSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddFile;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\WinPage\AddingSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadFileToBD;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\WinPage\AddingSubmit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CompilName;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CoDEmpare;component/winpage/addingsubmit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WinPage\AddingSubmit.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TransitioningContent = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 2:
            this.NameAuthor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CsharpLanguage = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 40 "..\..\..\WinPage\AddingSubmit.xaml"
            this.CsharpLanguage.Click += new System.Windows.RoutedEventHandler(this.ButtonBase_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.JavaLanguage = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 41 "..\..\..\WinPage\AddingSubmit.xaml"
            this.JavaLanguage.Click += new System.Windows.RoutedEventHandler(this.ButtonBase_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CppLanguage = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 42 "..\..\..\WinPage\AddingSubmit.xaml"
            this.CppLanguage.Click += new System.Windows.RoutedEventHandler(this.ButtonBase_OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddFile = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\WinPage\AddingSubmit.xaml"
            this.AddFile.Click += new System.Windows.RoutedEventHandler(this.AddFile_OnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LoadFileToBD = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\WinPage\AddingSubmit.xaml"
            this.LoadFileToBD.Click += new System.Windows.RoutedEventHandler(this.LoadFileToBD_OnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CompilName = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

