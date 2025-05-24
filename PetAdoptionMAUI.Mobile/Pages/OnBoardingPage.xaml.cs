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
		await Shell.Current.GoToAsync($"//{nameof(LoginRegisterPage)}");
    }
}