using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KielApp
{
    public class DatabaseHelper
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Member>().Wait();
        }

        public Task<List<Member>> GetMembersAsync()
        {
            return _database.Table<Member>().ToListAsync();
        }

        public Task<int> SaveMemberAsync(Member member)
        {
            return member.Id != 0 ? _database.UpdateAsync(member) : _database.InsertAsync(member);
        }

        public Task<int> DeleteMemberAsync(Member member)
        {
            return _database.DeleteAsync(member);
        }
    }
}
