﻿#pragma checksum "..\..\..\PageArtikel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A01654FCADB928CD72121F9478D90C4B8A118D2B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Allinox;
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


namespace Allinox {
    
    
    /// <summary>
    /// PageArtikel
    /// </summary>
    public partial class PageArtikel : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSearchArtikel;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSearch;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgArtikel;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblArtikelnr;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbArtikelNr;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbArtikelOmschrijving;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblArtikelPrio;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgArtikelPrio;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\PageArtikel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPallet;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Allinox;component/pageartikel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PageArtikel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lblSearchArtikel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.txbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\PageArtikel.xaml"
            this.txbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxbSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dgArtikel = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\..\PageArtikel.xaml"
            this.dgArtikel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgArtikel_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblArtikelnr = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txbArtikelNr = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txbArtikelOmschrijving = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lblArtikelPrio = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.dgArtikelPrio = ((System.Windows.Controls.DataGrid)(target));
            
            #line 51 "..\..\..\PageArtikel.xaml"
            this.dgArtikelPrio.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgArtikelPrio_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnReset = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\PageArtikel.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.BtnReset_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\PageArtikel.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnPallet = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\PageArtikel.xaml"
            this.btnPallet.Click += new System.Windows.RoutedEventHandler(this.BtnPallet_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

