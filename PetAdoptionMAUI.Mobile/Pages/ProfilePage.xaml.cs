using System.Threading.Tasks;

namespace PetAdoptionMAUI.Mobile.Pages;

public partial class ProfilePage : ContentPage
{
	private readonly ProfileViewModel _viewModel;

    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void ProfileOptionRow_Tapped(object sender, string optionText)
    {
        switch(optionText)
        {
            case "Моите Животни":
                await _viewModel.ShowToastAsync("Избрани са Моите Животни");
                break;
            case "Смяна на паролата":
                await _viewModel.ShowToastAsync("Избрано е смяна на паролата");
                break;
        }
    }
}