using Design.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Design
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        Dictionary<string, Type> routes = new Dictionary<string, Type>();

        public ICommand NavigateCommand => new Command(Navigate);
        public ICommand SettingsCommand => new Command(async () => await PushPage(new SettingsPage()));

        private async Task PushPage(Page page)
        {
            await Shell.Current.Navigation.PushAsync(page);
            Shell.Current.FlyoutIsPresented = false;
        }

        private async void Navigate(object route)
        {
            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"{state.Location}/{route.ToString()}");
            Shell.Current.FlyoutIsPresented = false;
        }

        void RegisterRoutes()
        {
            routes.Add("Catalog", typeof(CatalogPage));
            routes.Add("Category", typeof(CategoryPage));
            routes.Add("Collection", typeof(CollectionPage));
            routes.Add("Products", typeof(ProductsPage));
            
            routes.Add("Wishlist", typeof(WishlistPage));
            routes.Add("OurBlog", typeof(OurBlogPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}