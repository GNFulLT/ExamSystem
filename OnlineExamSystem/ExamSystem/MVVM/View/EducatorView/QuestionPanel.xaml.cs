﻿using ExamSystem.MVVM.Model.Question;
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

namespace ExamSystem.MVVM.View.EducatorView
{
    /// <summary>
    /// Interaction logic for QuestionPanel.xaml
    /// </summary>
    public partial class QuestionPanel : UserControl
    {
        public QuestionPanel()
        {
            InitializeComponent();
        }
        public QuestionPanel(Question question) : base()
        {
            
        }
    }
}