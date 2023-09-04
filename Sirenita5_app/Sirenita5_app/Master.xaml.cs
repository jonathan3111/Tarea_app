using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sirenita5_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private async void btnCrear_Clicked(object sender, EventArgs e)
        {
            App.MAsterDet.IsPresented = false;
            await App.MAsterDet.Detail.Navigation.PushAsync(new Crear());
        }

        private async void btnVer_Clicked(object sender, EventArgs e)
        {
            App.MAsterDet.IsPresented = false;
            await App.MAsterDet.Detail.Navigation.PushAsync(new Ver());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            App.MAsterDet.IsPresented = false;
            await App.MAsterDet.Detail.Navigation.PushAsync(new Actualizar());
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            App.MAsterDet.IsPresented = false;
            await App.MAsterDet.Detail.Navigation.PushAsync(new Eliminar());
        }
    }
}