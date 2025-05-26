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
            case "����� �������":
                await _viewModel.ShowToastAsync("������� �� ����� �������");
                break;
            case "����� �� ��������":
                await _viewModel.ShowToastAsync("������� � ����� �� ��������");
                break;
        }
    }
}