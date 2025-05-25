#pragma warning disable MVVMTK0045
#pragma warning disable CS8618
#pragma warning disable CA1416

namespace PetAdoptionMAUI.Mobile.ViewModels
{
    [QueryProperty(nameof(IsFirstTime), nameof(IsFirstTime))]
    public partial class LoginRegisterViewModel : BaseViewModel
    {
        private readonly AuthService _authService;

        public LoginRegisterViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [ObservableProperty]
        private bool _isRegistrationMode;

        [ObservableProperty]
        private LoginRegisterModel _model = new();

        [ObservableProperty]
        private bool _isFirstTime;

        partial void OnIsFirstTimeChanged(bool value)
        {
            if (value)
                IsRegistrationMode = true;
        }

        [RelayCommand]
        private void ToggleMode() => IsRegistrationMode = !IsRegistrationMode;

        [RelayCommand]
        private async Task SkipForNow() => await GoToAsync($"//{nameof(HomePage)}");

        [RelayCommand]
        private async Task Submit()
        {
            if(!Model.Validate(IsRegistrationMode))
            {
                await ShowToastAsync("Всички полета са задължителни");
                return;
            }

            IsBusy = true;

            // Make Api call to register or login user
            var status = await _authService.LoginRegisterAsync(Model);
            if(status)
                await SkipForNow();

            IsBusy = false;
        }
    }
}
