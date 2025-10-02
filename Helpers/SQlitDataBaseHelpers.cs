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
        private readonly SQLiteAsyncConnection _connn;

        public SQLiteDataBaseHelpers(string dbPath)
        {
            _connn = new SQLiteAsyncConnection(dbPath);
            _connn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
           return _connn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao = ?, Preco = ?, Quantidade = ? WHERE Id = ?";

            return _connn.QueryAsync<Produto>(
                sql, p.Descricao, p.Preco, p.Quantidade, p.Id
            );
        }

        public Task<int> Delete(int id)
        {
          return  _connn.Table<Produto>().DeleteAsync(i=> i.Id == id);
        }

        public Task<List<Produto>> GetAll()
        {
           return _connn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + q + "%'";

            return _connn.QueryAsync<Produto>(sql);
        }

    }
}
