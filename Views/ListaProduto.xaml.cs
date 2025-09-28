using login;
namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	public ListaProduto()
	{
		InitializeComponent();

        string? usuarioLogado = null;

        Task.Run(async () =>
        {
            usuarioLogado = await SecureStorage.Default.GetAsync("Usuario_logado");
            lbl_boasvindas.Text = $"Bem vindo(a), {usuarioLogado}";
            //user_logado();

        }).Wait();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool confirmasao = await DisplayAlert("Tem certesa?", "Sair do app?", "Sim", "Não");
        if (confirmasao)
        {
            SecureStorage.Default.Remove("Usuario_logado");
            App.Current.MainPage = new Login();
        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());

        }catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK!");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            App.Current.MainPage = new EditarProduto();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK!");
        }
    }
}