using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Sirenita5_app.Models;

using Xamarin.Forms;

namespace Sirenita5_app.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Cliente>().Wait();
        }
        public Task<int> SaveClienteAsync(Cliente cli)
        {
            if (cli.Id == 0)
            {
                return db.InsertAsync(cli);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Recuperar todos los clientes
        /// </summary>
        /// <returns></returns>
        public Task<List<Cliente>> GetClientesAsync()
        {
            return db.Table<Cliente>().ToListAsync();
        }
        /// <summary>
        /// Recuperar clientes por id
        /// </summary>
        /// <param name="id">Id del cliente que se requiere</param>
        /// <returns></returns>
        public Task<Cliente> GetClienteByIdAsync(int id)
        {
            return db.Table<Cliente>().Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        /// <summary>
        /// Actualiza un cliente en la base de datos.
        /// </summary>
        /// <param name="cli">El cliente actualizado.</param>
        /// <returns>El número de filas afectadas (debe ser 1 si la actualización fue exitosa).</returns>
        public Task<int> UpdateClienteAsync(Cliente cli)
        {
            if (cli.Id != 0)
            {
                // Realiza la actualización en la base de datos
                return db.UpdateAsync(cli);
            }
            else
            {
                throw new ArgumentException("El cliente no tiene un ID válido");
            }
        }
        public Task<int> DeleteClienteAsync(int id)
        {
            return db.DeleteAsync<Cliente>(id);
        }
    }
}