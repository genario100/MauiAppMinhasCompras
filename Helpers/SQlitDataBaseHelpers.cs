using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDataBaseHelpers
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteDataBaseHelpers(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Produto>().Wait();
        }

        public Task<List<Produto>> GetProdutosAsync()
        {
            return _database.Table<Produto>().ToListAsync();
        }

        public Task<Produto> GetProdutoAsync(int id)
        {
            return _database.Table<Produto>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveProdutoAsync(Produto produto)
        {
            if (produto.Id != 0)
            {
                return _database.UpdateAsync(produto);
            }
            else
            {
                return _database.InsertAsync(produto);
            }
        }

        public Task<int> DeleteProdutoAsync(Produto produto)
        {
            return _database.DeleteAsync(produto);
        }
    }
}
