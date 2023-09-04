using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sirenita5_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ver : ContentPage
    {
        public Ver()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Recuperar la lista de clientes desde la base de datos
            var clientelist = await App.SQLiteDB.GetClientesAsync();

            // Asignar la lista de clientes al ListView
            ListCliente.ItemsSource = clientelist;
        }
    }
}