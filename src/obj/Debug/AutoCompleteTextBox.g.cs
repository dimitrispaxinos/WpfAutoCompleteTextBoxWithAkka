﻿#pragma checksum "..\..\AutoCompleteTextBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "21FD0E829112532D4384D9439EEE066E"
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
using WpfAutoCompleteTextBoxWithAkka;
using WpfAutoCompleteTextBoxWithAkka.LoadingControl;


namespace WpfAutoCompleteTextBoxWithAkka {
    
    
    /// <summary>
    /// AutoCompleteTextBox
    /// </summary>
    public partial class AutoCompleteTextBox : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\AutoCompleteTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfAutoCompleteTextBoxWithAkka.AutoCompleteTextBox Ctrl;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\AutoCompleteTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AutoCompleteTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PART_TextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AutoCompleteTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PART_Popup;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AutoCompleteTextBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PART_ListBox;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfAutoCompleteTextBoxWithAkka;component/autocompletetextbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AutoCompleteTextBox.xaml"
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
            this.Ctrl = ((WpfAutoCompleteTextBoxWithAkka.AutoCompleteTextBox)(target));
            return;
            case 2:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.PART_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\AutoCompleteTextBox.xaml"
            this.PART_TextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.PART_TextBox_OnKeyDown);
            
            #line default
            #line hidden
            
            #line 16 "..\..\AutoCompleteTextBox.xaml"
            this.PART_TextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PART_TextBox_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PART_Popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 5:
            this.PART_ListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 38 "..\..\AutoCompleteTextBox.xaml"
            this.PART_ListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PART_ListBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

