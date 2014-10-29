﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E90E6B4F4126CB98B9C4634DB6FF5900"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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


namespace ImageBoard {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgToSend;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBrowse;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas imgCanvas;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse _blackPalette;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse _redPalette;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse _bluePalette;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse _pinkPalette;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider _brushSlider;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _clearButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _exportButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas _drawingCanvas;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SendOrientationButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CalibrateButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtBoardInView;
        
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
            System.Uri resourceLocater = new System.Uri("/ImageBoard;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 5 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Grid_TouchDown);
            
            #line default
            #line hidden
            
            #line 5 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).TouchMove += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.Grid_TouchMove);
            
            #line default
            #line hidden
            return;
            case 2:
            this.imgToSend = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            
            #line 8 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Browse_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtBrowse = ((System.Windows.Controls.TextBox)(target));
            
            #line 9 "..\..\MainWindow.xaml"
            this.txtBrowse.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FileTextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.imgCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this._blackPalette = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 12 "..\..\MainWindow.xaml"
            this._blackPalette.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnBlackSelect);
            
            #line default
            #line hidden
            return;
            case 7:
            this._redPalette = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this._redPalette.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnCrimsonSelect);
            
            #line default
            #line hidden
            return;
            case 8:
            this._bluePalette = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 14 "..\..\MainWindow.xaml"
            this._bluePalette.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnBlueSelect);
            
            #line default
            #line hidden
            return;
            case 9:
            this._pinkPalette = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 15 "..\..\MainWindow.xaml"
            this._pinkPalette.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OnPinkSelect);
            
            #line default
            #line hidden
            return;
            case 10:
            this._brushSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 11:
            this._clearButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\MainWindow.xaml"
            this._clearButton.Click += new System.Windows.RoutedEventHandler(this._clearButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this._exportButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\MainWindow.xaml"
            this._exportButton.Click += new System.Windows.RoutedEventHandler(this.CreateFile_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this._drawingCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this._drawingCanvas.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this._drawingCanvas_MouseDown);
            
            #line default
            #line hidden
            
            #line 21 "..\..\MainWindow.xaml"
            this._drawingCanvas.MouseMove += new System.Windows.Input.MouseEventHandler(this._drawingCanvas_MouseMove);
            
            #line default
            #line hidden
            return;
            case 14:
            this.SendOrientationButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MainWindow.xaml"
            this.SendOrientationButton.Click += new System.Windows.RoutedEventHandler(this.Send_Orientation_Button_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.CalibrateButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\MainWindow.xaml"
            this.CalibrateButton.Click += new System.Windows.RoutedEventHandler(this.Calibration_Button_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.txtBoardInView = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

