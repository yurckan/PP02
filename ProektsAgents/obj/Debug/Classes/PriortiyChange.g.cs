﻿#pragma checksum "..\..\..\Classes\PriortiyChange.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E2C1964DF736A3872E954C398ADE0E365B8ED7DC01400A385CE6A19C1117B373"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ProektsAgents.Classes;
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


namespace ProektsAgents.Classes {
    
    
    /// <summary>
    /// PriortiyChange
    /// </summary>
    public partial class PriortiyChange : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Classes\PriortiyChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Plus;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Classes\PriortiyChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minus;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Classes\PriortiyChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Classes\PriortiyChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountTB;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Classes\PriortiyChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveChangesBtn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Classes\PriortiyChange.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/ProektsAgents;component/classes/priortiychange.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Classes\PriortiyChange.xaml"
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
            this.Plus = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Classes\PriortiyChange.xaml"
            this.Plus.Click += new System.Windows.RoutedEventHandler(this.Plus_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Minus = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Classes\PriortiyChange.xaml"
            this.Minus.Click += new System.Windows.RoutedEventHandler(this.Minus_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.CountTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\Classes\PriortiyChange.xaml"
            this.CountTB.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.OnPreviewTextInput);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\Classes\PriortiyChange.xaml"
            this.CountTB.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.OnPasting));
            
            #line default
            #line hidden
            return;
            case 5:
            this.SaveChangesBtn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Classes\PriortiyChange.xaml"
            this.SaveChangesBtn.Click += new System.Windows.RoutedEventHandler(this.SaveChangesBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Classes\PriortiyChange.xaml"
            this.CancelBtn.Click += new System.Windows.RoutedEventHandler(this.CancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
