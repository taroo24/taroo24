namespace KielApp;

public partial class homePage : ContentPage
{
    private DatabaseHelper _database;

    public homePage()
    {
        InitializeComponent();
        _database = new DatabaseHelper(Path.Combine(FileSystem.AppDataDirectory, "Members.db3"));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        MemberList.ItemsSource = await _database.GetMembersAsync();
    }

    private async void OnAddMemberClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddMember());
    }

    private async void OnMemberSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Member selectedMember)
        {
            await Navigation.PushAsync(new MemberDetailPage(selectedMember));
        }
    }

    private async void OnGroupImageTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new IntroductionPage());
    }
    private async void OnImageTapped(object sender, EventArgs e)
    {
        if (sender is Image image && image.BindingContext is Member selectedMember)
        {
            await Navigation.PushAsync(new MemberDetailPage(selectedMember));
        }
    }
}