namespace KielApp;

public partial class MemberDetailPage : ContentPage
{
    private DatabaseHelper _database;
    private Member _member;

    public MemberDetailPage(Member member)
    {
        InitializeComponent();
        _database = new DatabaseHelper(Path.Combine(FileSystem.AppDataDirectory, "Members.db3"));
        BindingContext = _member = member;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        await _database.SaveMemberAsync(_member);
        await Navigation.PopAsync();
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        await _database.DeleteMemberAsync(_member);
        await Navigation.PopAsync();
    }
}