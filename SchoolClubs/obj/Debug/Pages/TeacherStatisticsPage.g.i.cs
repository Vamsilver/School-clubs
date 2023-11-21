﻿#pragma checksum "..\..\..\Pages\TeacherStatisticsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B78394E274D20735D37D25334B913BF450FEFE26BF8587917884BB724DE5E800"
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
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
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
    /// TeacherStatisticsPage
    /// </summary>
    public partial class TeacherStatisticsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Pages\TeacherStatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TeacherNameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Pages\TeacherStatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClubsComboBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Pages\TeacherStatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateStartDataPicker;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\TeacherStatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateEndDataPicker;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Pages\TeacherStatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView StudentAttendanceListView;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\Pages\TeacherStatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.Chart ClassAttendanceChart;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\Pages\TeacherStatisticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.Chart LessonsTaughtChart;
        
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
            System.Uri resourceLocater = new System.Uri("/SchoolClubs;component/pages/teacherstatisticspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\TeacherStatisticsPage.xaml"
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
            this.TeacherNameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ClubsComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.DateStartDataPicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.DateEndDataPicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.StudentAttendanceListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.ClassAttendanceChart = ((System.Windows.Controls.DataVisualization.Charting.Chart)(target));
            return;
            case 7:
            this.LessonsTaughtChart = ((System.Windows.Controls.DataVisualization.Charting.Chart)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
