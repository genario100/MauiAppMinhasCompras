using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class TelaInicial : ContentPage
{
	public TelaInicial()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
            App.Current.MainPage = new ListaProduto();

        }
        catch(Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK!");
		}
    }
}