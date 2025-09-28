
using MauiAppMinhasCompras.Helpers;

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

            MainPage = new NavigationPage(new Views.TelaInicial());

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = "Minhas Compras";
            window.Width = 400;
            window.Height = 900;
            return window;
        }
    }
}