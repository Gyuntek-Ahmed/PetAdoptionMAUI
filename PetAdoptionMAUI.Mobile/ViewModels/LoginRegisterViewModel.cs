#pragma warning disable MVVMTK0045
#pragma warning disable CS8618
#pragma warning disable CA1416

namespace PetAdoptionMAUI.Mobile.ViewModels
{
    [QueryProperty(nameof(IsFirstTime), nameof(IsFirstTime))]
    public partial class LoginRegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isRegistrationMode;

        [ObservableProperty]
        private LoginRegisterModel _model = new();

        [ObservableProperty]
        private bool _isFirstTime;

        [ObservableProperty]
        private bool _isBusy;

        public void Initialize()
        {
            if (IsFirstTime)
                IsRegistrationMode = true;
        }

        [RelayCommand]
        private void ToggleMode() => IsRegistrationMode = !IsRegistrationMode;

        [RelayCommand]
        private async Task SkipForNow()
                    => await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

        [RelayCommand]
        private async Task Submit()
        {
            if(!Model.Validate(IsRegistrationMode))
            {
                await Toast.Make("Всички полета са задължителни!").Show();
                return;
            }

            IsBusy = true;
            // Make Api call to register or login user
            await Task.Delay(1000); // Simulate API call delay
            await SkipForNow();
            IsBusy = false;
        }
    }
}
