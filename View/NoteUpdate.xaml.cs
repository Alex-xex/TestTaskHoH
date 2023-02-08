﻿using System;
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
using View.ViewModel;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для NoteUpdate.xaml
    /// </summary>
    public partial class NoteUpdate : Window
    {
        public NoteUpdate()
        {
            InitializeComponent();
            DataContext = new NoteVM(new Model.Note { });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListNotes listNotes = new ListNotes();
            listNotes.Show();
            this.Close();
        }
    }
}
