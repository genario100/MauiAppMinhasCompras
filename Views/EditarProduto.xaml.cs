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
}