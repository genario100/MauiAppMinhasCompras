using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new ListaProduto());
            //App.Current.MainPage = new ListaProduto();

            //await Navigation.PushAsync(new EditarProduto());

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK!");
        }
    }

    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        Produto produto_anexida = BindingContext as Produto;
        Produto p = new Produto
        {
            Id = produto_anexida.Id,
            Descricao = txt_descricao.Text,
            Quantidade = Convert.ToDouble(txt_Quantidade.Text),
            Preco = Convert.ToDouble(txt_preco_unitario.Text)
        };

        try
        {
            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro atualizado ", "OK!");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops!", ex.Message, "OK!");
        }
    }
}