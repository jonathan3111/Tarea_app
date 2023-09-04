using Sirenita5_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sirenita5_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actualizar : ContentPage
    {
        public Actualizar()
        {
            InitializeComponent();
        }

        public bool validarDatos()
        {
            bool respuesta;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellidoPaterno.Text) || string.IsNullOrEmpty(txtApellidoMaterno.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                respuesta = false;
            }
            else if (!int.TryParse(txtEdad.Text, out int edad) || (edad < 18 || edad > 120))
            {
                respuesta = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }
        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int clienteId))
            {
                // Busca el cliente por el Id ingresado
                var cliente = await App.SQLiteDB.GetClienteByIdAsync(clienteId);

                if (cliente != null)
                {
                    // Si se encontró un cliente, llenar los campos de edición
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
                await DisplayAlert("Error", "Id no válido", "OK");
            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int clienteId))
            {
                if (validarDatos())
                {
                    var cliente = new Cliente
                    {
                        Id = clienteId,
                        Nombre = txtNombre.Text,
                        ApellidoPaterno = txtApellidoPaterno.Text,
                        ApellidoMaterno = txtApellidoMaterno.Text,
                        Edad = int.Parse(txtEdad.Text),
                        Email = txtEmail.Text
                    };

                    try
                    {
                        // Intentar actualizar el cliente en la base de datos
                        int filasAfectadas = await App.SQLiteDB.UpdateClienteAsync(cliente);

                        if (filasAfectadas > 0)
                        {
                            txtId.Text = "";
                            txtNombre.Text = "";
                            txtApellidoPaterno.Text = "";
                            txtApellidoMaterno.Text = "";
                            txtEdad.Text = "";
                            txtEmail.Text = "";
                            await DisplayAlert("Éxito", "Cliente actualizado con éxito", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", "No se pudo actualizar el cliente", "OK");
                        }
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "Ingrese correctamente los datos", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Id no válido", "OK");
            }
        }
    }
}