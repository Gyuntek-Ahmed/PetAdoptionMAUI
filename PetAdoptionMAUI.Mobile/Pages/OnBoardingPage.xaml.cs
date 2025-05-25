using System.Threading.Tasks;

namespace PetAdoptionMAUI.Mobile.Pages;

public partial class OnBoardingPage : ContentPage
{
	public OnBoardingPage()
	{
		InitializeComponent();

		Preferences.Default.Set(UIConstants.OnboardingShown, string.Empty);
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var parameters = new Dictionary<string, object>
        {
            [ nameof(LoginRegisterViewModel.IsFirstTime)] = true
        };

        await Shell.Current.GoToAsync($"//{nameof(LoginRegisterPage)}", parameters);
    }
}