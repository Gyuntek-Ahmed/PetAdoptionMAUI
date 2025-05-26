namespace PetAdoptionMAUI.Mobile.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private readonly AuthService _authService;

        public ProfileViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Initials))]
        private string _userName = "Гюнтек Ахмед";

        [ObservableProperty]
        private bool _isLoggedIn;

        public string Initials
        {
            get
            {
                var parts = UserName.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if (parts.Length == 1)                  // if there's only one part (e.g., a single name)
                    return UserName.Length == 1
                        ? UserName                      // If the name is a single character, return it as is
                        : UserName[..2];                // Username is longer than one character

                return $"{parts[0][0]}{parts[1][0]}";   // Return initials from the first two parts
            }
        }

        [RelayCommand]
        private async Task LoginLogoutAsync()
        {
            if (!IsLoggedIn)
                await GoToAsync($"//{nameof(LoginRegisterPage)}");
            else
            {
                _authService.LogOut();
                await GoToAsync($"//{nameof(HomePage)}");
            }
        }
    }
}
