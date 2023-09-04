using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Sirenita5_app.Models
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string ApellidoPaterno { get; set; }
        [MaxLength(50)]
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
    }
}