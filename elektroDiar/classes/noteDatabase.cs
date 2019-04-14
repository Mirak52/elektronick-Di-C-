using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elektroDiar.classes
{
    public class NoteDatabase
    {
        public SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
        }
        public Task<List<Note>> QueryCustomExist(string name)
        {
            return database.QueryAsync<Note>("select ID FROM [Note] where Name ='" + name + "'");
        }
        public Task<List<Note>> SelectByName(string name)
        {
            return database.QueryAsync<Note>("select * FROM [Note] where name  LIKE '%" + name + "%'");
        }
        public Task<List<Note>> QueryCustom()
        {
            return database.QueryAsync<Note>("select * FROM [Note]");
        }
        public Task<List<Note>> Add()
        {
            return database.QueryAsync<Note>("INSERT INTO [Note] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        public Task<List<Note>> DeleteAll()
        {
            return database.QueryAsync<Note>("Delete FROM [Note]");
        }
        public Task<List<Note>> deleteById(int id)
        {
            return database.QueryAsync<Note>("Delete FROM [Note] where id_note ='" + id + "'");
        }
        public Task<List<Note>> getById(int id)
        {
            return database.QueryAsync<Note>("select * FROM [Note] where id_note ='" + id + "'");
        }
        public Task<List<Note>> getNotes()
        {
            return database.QueryAsync<Note>("select * FROM [Note]");
        }
        public Task<List<Note>> getNotesByNameAndMail(string mail,string name)
        {
            return database.QueryAsync<Note>("select * FROM [Note] where name  LIKE '%" + name + "%' OR email LIKE '%" + mail + "%'");
        }
        // Query
        public Task<List<Note>> GetItemsAsync()
        {
            return database.Table<Note>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Note>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Note>("SELECT * FROM [Note] WHERE [Done] = 0");
        }

        // Query using LINQ


        public Task<int> SaveItemAsync(Note item)
        {
            return database.InsertAsync(item);
        }
        public Task<int> UpdateItemAsync(Note item)
        {
            return database.UpdateAsync(item);
        }
        public Task<int> SaveList(List<Note> items)
        {
            return database.InsertAllAsync(items);
        }
        public Task<int> DeleteItemAsync(Note item)
        {
            return database.DeleteAsync(item);
        }
    }
}
