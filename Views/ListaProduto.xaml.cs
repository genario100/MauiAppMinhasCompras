using login;
using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;
using System;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
    public ListaProduto()
	{
		InitializeComponent();

        lst_produtos.ItemsSource = lista;

        string? usuarioLogado = null;

        Task.Run(async () =>
        {
            usuarioLogado = await SecureStorage.Default.GetAsync("Usuario_logado");
            lbl_boasvindas.Text = $"Bem vindo(a), {usuarioLogado}";
            //user_logado();

        }).Wait();
    }

    protected override async void OnAppearing()
    {
        lista.Clear();

        List<Produto> tmp = await App.Db.GetAll();

        tmp.ForEach(i => lista.Add(i));
        {
            
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool confirmasao = await DisplayAlert("Tem certesa?", "Sair do app?", "Sim", "Não");
        if (confirmasao)
        {
            SecureStorage.Default.Remove("Usuario_logado");
            try
            {
                await Navigation.PushAsync(new Login());

            }
            catch (Exception ex)
            {
                DisplayAlert("Ops!", ex.Message, "OK!");
            }
        }
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
          await  Navigation.PushAsync(new NovoProduto());

        }catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK!");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new Views.NovoProduto());

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK!");
        }
    }

    // Adicione este método para tratar o evento do MenuItem "Remover"
    private void OnRemoverClicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var produto = menuItem?.CommandParameter;
        // Implemente aqui a lógica para remover o produto da lista
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;


        lista.Clear();

        List<Produto> tmp = await App.Db.Search(q);

        tmp.ForEach(i => lista.Add(i));
        
        
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        try
        { 
        double soma = lista.Sum(i => i.Total);
        string msg = $"O total é {soma:C}";
        DisplayAlert("Total dos produtos", msg, "OK");
        }catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK!");
        }
        
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            var menuItem = sender as MenuItem;
        if (menuItem?.CommandParameter is int id)
        {
            Produto p = lista.FirstOrDefault(i => i.Id == id);
                bool confirma = await DisplayAlert("Atenção", $"Confirma a exclusão do produto {p.Descricao}?", "Sim", "Não");
                if (p != null)
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }
        }
        }catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK");
        }
        
    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto p = e.SelectedItem as Produto;

            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p
            });
            

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK");
        }
    }
}