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

        public MainWindow()
        {
            InitializeComponent();
            getNotes();
            
        }

        private void getNotes()
        {
            Notes.Items.Clear();
            var Items = App.NoteDatabase.getNotes().Result;
            foreach (var item in Items)
            {
                Notes.Items.Add(item);
            }
        }
        public int id;
        private void Notes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (editMode)
            {
                dynamic selectedItem = Notes.SelectedItems[0];
                nameSave.Text = selectedItem.name;
                lastNameSave.Text = selectedItem.lastName;
                ageSave.Text = selectedItem.age;
                emailSave.Text = selectedItem.email;
                phoneSave.Text = selectedItem.phone;
                dateP.Text = selectedItem.date;
                noteSave.Text = selectedItem.note;
                id = selectedItem.id_note;
                Save.Content = "EDIT";
                Save.IsEnabled = true;
            }
            else
            {
                if (Notes.SelectedItems.Count != 0)
                {
                    dynamic selectedItem = Notes.SelectedItems[0];
                    App.NoteDatabase.deleteById(selectedItem.id_note);
                    getNotes();
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (editMode)
            {
                if (nameSave.Text != "" & noteSave.Text != "" & dateP.Text != "" & isNumeric(ageSave.Text))
                {
                    editMode = false;
                    Save.Content = "SAVE";
                    Save.IsEnabled = true;
                    Note note = new Note();
                    ErrorL.Content = "";
                    note.id_note = id;
                    note.name = nameSave.Text;
                    note.lastName = lastNameSave.Text;
                    note.age = ageSave.Text;
                    note.email = emailSave.Text;
                    note.phone = phoneSave.Text;
                    note.date = dateP.Text;
                    note.note = noteSave.Text;
                    if (radB1.IsChecked == true)
                    {
                        note.sex = radB1.Content.ToString();
                    }
                    else
                    {
                        note.sex = radB2.Content.ToString();
                    }
                    App.NoteDatabase.UpdateItemAsync(note);
                }
                else
                {
                    ErrorL.Content = "Zadej všechny údaje";
                }
            }
            else
            {
                if (nameSave.Text != "" & noteSave.Text != "" & dateP.Text != "" & isNumeric(ageSave.Text))
                {
                    Note note = new Note();
                    ErrorL.Content = "";
                    note.name = nameSave.Text;
                    note.lastName = lastNameSave.Text;
                    note.age = ageSave.Text;
                    note.email = emailSave.Text;
                    note.phone = phoneSave.Text;
                    note.date = dateP.Text;
                    note.note = noteSave.Text;
                    if (radB1.IsChecked == true)
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
            getNotes();
        }
        private static bool isNumeric(string number)
        {
            int isNumber;
            return int.TryParse(number, out isNumber);
        }

        private void SearchB_Click(object sender, RoutedEventArgs e)
        {

            Notes.Items.Clear();
            var Items = App.NoteDatabase.getNotesByNameAndMail(searchEmail.Text, searchName.Text).Result;
            foreach (var item in Items)
            {
                Notes.Items.Add(item);
            }
        }

        private void DeleteB_Click(object sender, RoutedEventArgs e)
        {
            App.NoteDatabase.DeleteAll();
            getNotes();
        }
        public bool editMode = false;
        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            if (editMode)
            {
                EditB.Content = "EDIT MODE";
                editMode = false;
                Save.IsEnabled = true;
                Save.Content = "SAVE";
            }
            else
            {
                EditB.Content = "DELETE MODE";
                editMode = true;
                Save.IsEnabled = false;
                Save.Content = "EDIT";
            }
        }

        private void RefreshB_Click(object sender, RoutedEventArgs e)
        {
            getNotes();
        }
    }
}
