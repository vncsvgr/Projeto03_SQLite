using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projeto03_SQLite.Models;

namespace Projeto03_SQLite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pagAluno : ContentPage
    {
        Curso c = new Curso();
        Cidade ci = new Cidade();
        Aluno a = new Aluno();

        public pagAluno()
        {
            InitializeComponent();

            pckCurso.ItemsSource = c.Listar("");
            pckCidade.ItemsSource = ci.Listar("");
            lstAlunos.ItemsSource = a.Listar("");
            
        }

        void limpar()
        {
            txtId.Text = String.Empty;
            txtNome.Text = String.Empty;
            pckCurso.SelectedIndex = -1;
            pckCidade.SelectedIndex = -1;
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                DisplayAlert("Atenção", "Por favor digite o nome do curso", "OK");
                return;
            }

            a = new Aluno
            {
                nome = txtNome.Text,
                curso = pckCurso.Items[pckCurso.SelectedIndex].ToString(),
                cidade = pckCidade.Items[pckCidade.SelectedIndex].ToString()
            };

            a.Adicionar(a);
            lstAlunos.ItemsSource = a.Listar("");
            limpar();
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                DisplayAlert("Atenção", "Informe o ID do aluno", "OK");
                return;
            }

            a = new Aluno
            {
                id = int.Parse(txtId.Text),
                nome = txtNome.Text,
                curso = pckCurso.Items[pckCurso.SelectedIndex].ToString(),
                cidade = pckCidade.Items[pckCidade.SelectedIndex].ToString()
            };

            a.Adicionar(a);
            lstAlunos.ItemsSource = a.Listar("");
            limpar();
        }

        async void btnExcluir_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                await DisplayAlert("Atenção", "Informe o ID do aluno", "OK");
                return;
            }

            var resp = await DisplayAlert("Exclusão", "Deseja excluir o aluno?", "SIM", "NÃO");

            if (resp)
            {
                a = new Aluno
                {
                    id = int.Parse(txtId.Text)
                };
                a.Excluir(a);
                lstAlunos.ItemsSource = a.Listar("");
                limpar();
            }
        }

        private void sbAluno_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstAlunos.ItemsSource = a.Listar(sbAluno.Text);
        }

        private void lstAlunos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            a = e.SelectedItem as Aluno;

            txtId.Text = a.id.ToString();
            txtNome.Text = a.nome;

            c = c.Consultar(a.curso);
            pckCurso.SelectedIndex = c.id - 1;

            ci = ci.Consultar(a.cidade);
            pckCidade.SelectedIndex = ci.id - 1;
        }

        async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}