using MauiAppMinhasCompras.Models;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        Produto p = new Produto
        {
            Descricao = txt_descricao.Text,
            Quantidade = Convert.ToDouble(txt_Quantidade.Text),
            Preco = Convert.ToDouble(txt_preco_unitario.Text)
        };

        try
        {
            await App.Db.Insert(p);
            await DisplayAlert("Sucesso!", "Registro inserido ", "OK!");
            await Navigation.PopAsync();  
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops!", ex.Message, "OK!");
        }
    }
}