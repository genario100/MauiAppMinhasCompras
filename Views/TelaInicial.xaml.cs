using MauiAppMinhasCompras.Models;
using login;

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
            //App.Current.MainPage = new Login();
			await Navigation.PushAsync(new Login());

        }
        catch(Exception ex)
		{
			await DisplayAlert("Erro", ex.Message, "OK!");
		}
    }
}