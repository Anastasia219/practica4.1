﻿#pragma checksum "..\..\..\Pages\ListEmploye.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C540D835A1AA27909299B5896460D757F6844C279BE31148DEB9A9EF7717956A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Practica4._1.Pages;
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


namespace Practica4._1.Pages {
    
    
    /// <summary>
    /// ListEmploye
    /// </summary>
    public partial class ListEmploye : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 19 "..\..\..\Pages\ListEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTb;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\ListEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SortCb;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\ListEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView MyList;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Pages\ListEmploye.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddEmployeeBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Practica4.1;component/pages/listemploye.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ListEmploye.xaml"
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
            this.SearchTb = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\Pages\ListEmploye.xaml"
            this.SearchTb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SortCb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 44 "..\..\..\Pages\ListEmploye.xaml"
            this.SortCb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SortCb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MyList = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.AddEmployeeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\Pages\ListEmploye.xaml"
            this.AddEmployeeBtn.Click += new System.Windows.RoutedEventHandler(this.AddEmployeeBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 75 "..\..\..\Pages\ListEmploye.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Edit_MouseDown);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 82 "..\..\..\Pages\ListEmploye.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Delete_MouseDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

