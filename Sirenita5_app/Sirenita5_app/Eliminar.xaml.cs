using Sirenita5_app.Models;
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
    public partial class Eliminar : ContentPage
    {
        public Eliminar()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdEliminar.Text, out int clienteId))
            {
                bool confirmacion = await DisplayAlert("Confirmación", "¿Estás seguro de que deseas eliminar este cliente?", "Sí", "No");

                if (confirmacion)
                {
                    int filasAfectadas = await App.SQLiteDB.DeleteClienteAsync(clienteId);
                    if (filasAfectadas > 0)
                    {
                        txtIdEliminar.Text = "";
                        txtNombre.Text = "";
                        txtApellidoPaterno.Text = "";
                        txtApellidoMaterno.Text = "";
                        txtEdad.Text = "";
                        txtEmail.Text = "";
                        await DisplayAlert("Éxito", "Cliente eliminado con éxito", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo eliminar el cliente", "OK");
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "Id no válido", "OK");
            }
        }

        private async void btnCargar_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdEliminar.Text, out int clienteId))
            {
                Cliente cliente = await App.SQLiteDB.GetClienteByIdAsync(clienteId);

                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtApellidoPaterno.Text = cliente.ApellidoPaterno;
                    txtApellidoMaterno.Text = cliente.ApellidoMaterno;
                    txtEdad.Text = cliente.Edad.ToString();
                    txtEmail.Text = cliente.Email;
                }
                else
                {
                    await DisplayAlert("Error", "Cliente no encontrado", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "ID de cliente no válido", "OK");
            }
        }
    }
}