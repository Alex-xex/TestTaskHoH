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
using View.ViewModel;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для NotePage.xaml
    /// </summary>
    public partial class NotePage : Window
    {
        public NotePage()
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
