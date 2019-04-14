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
            return database.QueryAsync<Note>("select ID FROM [Item] where Name ='" + name + "'");
        }
        public Task<List<Note>> SelectByName(string name)
        {
            return database.QueryAsync<Note>("select * FROM [Item] where name  LIKE '%" + name + "%'");
        }
        public Task<List<Note>> QueryCustom()
        {
            return database.QueryAsync<Note>("select * FROM [Item]");
        }
        public Task<List<Note>> Add()
        {
            return database.QueryAsync<Note>("INSERT INTO [Item] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        public Task<List<Note>> DeleteAll()
        {
            return database.QueryAsync<Note>("Delete FROM [Item]");
        }
        public Task<List<Note>> ReturnPrices()
        {
            return database.QueryAsync<Note>("SELECT price FROM [Item]");
        }
        // Query
        public Task<List<Note>> GetItemsAsync()
        {
            return database.Table<Note>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Note>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Note>("SELECT * FROM [Item] WHERE [Done] = 0");
        }

        // Query using LINQ


        public Task<int> SaveItemAsync(Note item)
        {
            return database.InsertAsync(item);
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
