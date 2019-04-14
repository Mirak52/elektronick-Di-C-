using elektroDiar.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace elektroDiar
{
    /// <summary>
    /// Interakční logika pro App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NoteDatabase _Note;

        public static NoteDatabase NoteDatabase
        {
            get
            {
                if (_Note == null)
                {
                    var fileHelper = new FileHelper();
                    _Note = new NoteDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _Note;
            }
        }
    }
}
