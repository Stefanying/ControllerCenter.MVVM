﻿using ControllerCenter.MVVM.ViewModel.DataBitModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControllerCenter.MVVM.View.DataBitModel
{
    /// <summary>
    /// List.xaml 的交互逻辑
    /// </summary>
    public partial class List : UserControl
    {
        public List()
        {
            InitializeComponent();
            this.ViewModel = new ListViewModel();
            this.ViewModel.View = this;
        }
        public ListViewModel ViewModel
        {
            get
            {
                return this.DataContext as ListViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
