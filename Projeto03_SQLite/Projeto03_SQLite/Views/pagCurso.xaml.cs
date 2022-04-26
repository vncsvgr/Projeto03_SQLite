using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projeto03_SQLite.Models;

namespace Projeto03_SQLite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pagCurso : ContentPage
    {
        Curso c = new Curso();

        public pagCurso()
        {
            InitializeComponent();

            lstCursos.ItemsSource = c.Listar("");
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                DisplayAlert("Atenção", "Por favor digite o nome do curso", "OK");
                return;
            }

            c = new Curso
            {
                nome = txtNome.Text,
            };

            c.Adicionar(c);
            lstCursos.ItemsSource = c.Listar("");
            txtNome.Text = String.Empty;
        }

        private void sbCurso_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstCursos.ItemsSource = c.Listar(sbCurso.Text);
        }

        async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}