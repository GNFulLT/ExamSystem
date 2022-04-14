﻿using ExamSystem.MVVM.Model.Question;
using ExamSystem.MVVM.ViewModel.EducatorViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ExamSystem.MVVM.View.EducatorView
{
    /// <summary>
    /// Interaction logic for EducatorMainWindow.xaml
    /// </summary>
    public partial class EducatorMainWindow : Window
    {


        public EducatorMainWindow()
        {
            
            InitializeComponent();

        }

        private void showCreatedQuestion(object sender)
        {
            Question s = new Question();
            s.Unit = new Unit();
            s.Unit.UnitName = "Biyoloji";
        }

        
    }
}
