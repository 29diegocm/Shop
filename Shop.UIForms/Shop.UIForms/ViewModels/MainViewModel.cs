

namespace Shop.UIForms.ViewModels
{

    using Shop.Common.Models;
    class MainViewModel
    {
        public TokenResponse Token { get; set; }

        private static MainViewModel instance;
        public LoginViewModel Login { get; set; }

        public ProductsViewModel Products { get; set; }

        public MainViewModel()
        {
            instance = this;                     
        }

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }

    }
}
