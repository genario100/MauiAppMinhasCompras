using login.Class;
using MauiAppMinhasCompras;
using MauiAppMinhasCompras.Views;

namespace login;
public partial class Login : ContentPage
{
    private object txtUsuario;
    

    public Login()
	{
		InitializeComponent();
	}

    private async  void Button_Clicked_2(object sender, EventArgs e)
    {
try
        {
            List<DadosUsuarios> lista_Usuarios = new List<DadosUsuarios>
            {
                new DadosUsuarios() { Usuario = "Genario", Senha = "54321" },
                new DadosUsuarios() { Usuario = "Maria", Senha = "12345" },
                new DadosUsuarios() { Usuario = "Joao", Senha = "67890" },
                new DadosUsuarios() { Usuario = "Ana", Senha = "54321" },
                new DadosUsuarios() { Usuario = "Pedro", Senha = "98765" }
            };

            DadosUsuarios dados_digitados = new DadosUsuarios()
            {
                Usuario = txt_Usuarioo.Text,
                Senha = txt_Senhaa.Text
            };
            //LINQ
            if (lista_Usuarios.Any(i => 
            dados_digitados.Usuario == i.Usuario &&
            dados_digitados.Senha == i.Senha))
            {
               await SecureStorage.Default.SetAsync("Usuario_logado", dados_digitados.Usuario);
                //MainPage = new NavigationPage(new Views.EditarProduto());
                //App.Current.MainPage = new ListaProduto();

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
            else if (txt_Usuarioo.Text == null || txt_Senhaa.Text == null)
            {
               await DisplayAlert("Ops", "Preencha todos os campos", "Fechar");
                return;
            }
            else
            {
                throw new Exception("Usuario ou senha esta errado.");
            }
        }
        catch(Exception ex)
        {
            DisplayAlert("Ops", ex.Message , "Fechar");
        }
    }
}