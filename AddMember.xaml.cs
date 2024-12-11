namespace KielApp;

public partial class AddMember : ContentPage
{
    private DatabaseHelper _database;
    private string _selectedImagePath; 

    public AddMember()
    {
        InitializeComponent();
        _database = new DatabaseHelper(Path.Combine(FileSystem.AppDataDirectory, "Members.db3"));
    }

    private async void OnChooseImageClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select an Image",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                _selectedImagePath = result.FullPath;

                SelectedImage.Source = ImageSource.FromFile(_selectedImagePath);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to pick image: {ex.Message}", "OK");
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrEmpty(_selectedImagePath))
        {
            await DisplayAlert("Validation Error", "Name and Image are required.", "OK");
            return;
        }

        var newMember = new Member
        {
            Name = NameEntry.Text,
            ImageSource = _selectedImagePath, 
            Bio = BioEntry.Text,
            Hometown = HometownEntry.Text,
            Birthday = BirthdayEntry.Text,
            ZodiacSign = ZodiacEntry.Text
        };

        await _database.SaveMemberAsync(newMember);
        await DisplayAlert("Success", "Member saved successfully!", "OK");
        await Navigation.PopAsync();
    }
}