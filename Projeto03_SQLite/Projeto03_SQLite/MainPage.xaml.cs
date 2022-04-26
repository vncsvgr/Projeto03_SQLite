using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Projeto03_SQLite.Views;

namespace Projeto03_SQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnCursos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pagCurso());
        }

        async void btnCidades_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pagCidade());
        }

        async void btnAlunos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pagAluno());
        }

        private void btnFechar_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
