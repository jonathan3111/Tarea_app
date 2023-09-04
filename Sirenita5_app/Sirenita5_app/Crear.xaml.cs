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
    public partial class Crear : ContentPage
    {
        public Crear()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Cliente cli = new Cliente
                {
                    Nombre = txtNombre.Text,
                    ApellidoPaterno = txtApellidoPaterno.Text,
                    ApellidoMaterno = txtApellidoMaterno.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Email = txtEmail.Text,
                };
                await App.SQLiteDB.SaveClienteAsync(cli);
                txtNombre.Text = "";
                txtApellidoPaterno.Text = "";
                txtApellidoMaterno.Text = "";
                txtEdad.Text = "";
                txtEmail.Text = "";
                await DisplayAlert("Registro", "Se guardo de manera exitosa el cliente", "OK");

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingrese correctamente los datos", "OK");
            }
        }
        public bool validarDatos()
        {
            bool respuesta;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellidoPaterno.Text) || string.IsNullOrEmpty(txtApellidoMaterno.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                respuesta = false;
            }
            else if (!int.TryParse(txtEdad.Text, out int edad) || (edad < 0 || edad > 120 || edad < 18))
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
    }
}