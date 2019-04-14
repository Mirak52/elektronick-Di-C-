using elektroDiar.classes;
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

namespace elektroDiar
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Note note = new Note();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Notes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(nameSave.Text != "" & lastNameSave.Text != "" & ageSave.Text != "" & emailSave.Text != "" & dateP.Text != "" & isNumeric(ageSave.Text) & phoneSave.Text != "")
            {
                ErrorL.Content = "";
                note.name = nameSave.Text;
                note.lastName = lastNameSave.Text;
                note.age = ageSave.Text;
                note.email = emailSave.Text;
                note.phone = phoneSave.Text;
                note.date = dateP.Text;
                if(radB1.IsChecked == true)
                {
                    note.sex = radB1.Content.ToString();

                }
                else
                {
                    note.sex = radB2.Content.ToString();

                }
                App.NoteDatabase.SaveItemAsync(note);
            }
            else
            {
                ErrorL.Content = "Zadej všechny údaje";
            }
            
        }
        private static bool isNumeric(string number)
        {
            int isNumber;
            return int.TryParse(number, out isNumber);
        }
    }
}
