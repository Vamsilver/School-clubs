﻿#pragma checksum "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "66B38B3774BBB763C495975028381522A863AA3DB192422196FA4671724521AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SchoolClubs.Pages;
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


namespace SchoolClubs.Pages {
    
    
    /// <summary>
    /// EnrollStudentToClubPage
    /// </summary>
    public partial class EnrollStudentToClubPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClassCB;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PupilCB;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClubCB;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GroupCB;
        
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
            System.Uri resourceLocater = new System.Uri("/SchoolClubs;component/pages/teacher/enrollstudenttoclubpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml"
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
            
            #line 9 "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml"
            ((SchoolClubs.Pages.EnrollStudentToClubPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.PageLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ClassCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml"
            this.ClassCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ClassCBSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PupilCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.ClubCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 58 "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml"
            this.ClubCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ClubCBSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GroupCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            
            #line 78 "..\..\..\..\Pages\Teacher\EnrollStudentToClubPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EnrollStudentToClubBtnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

