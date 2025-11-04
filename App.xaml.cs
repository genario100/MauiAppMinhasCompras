
using login;
using MauiAppMinhasCompras.Helpers;
using MauiAppMinhasCompras.Views;
using System.Globalization;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelpers _db;

        public static SQLiteDataBaseHelpers Db
        {
            get
            {
                if (_db == null)
                {
                      _db = new SQLiteDataBaseHelpers(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco_sqlite_compras.db3"));
}
                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("pt_BR");

            MainPage = new NavigationPage(new Login());

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = "Minhas Compras";
            window.Width = 500;
            window.Height = 1000;
            return window;
        }
    }
}