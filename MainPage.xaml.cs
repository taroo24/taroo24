namespace KielApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnProceedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new homePage());
        }

    }

}
