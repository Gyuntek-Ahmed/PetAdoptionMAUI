namespace PetAdoptionMAUI.Mobile.ViewModels
{
    [QueryProperty(nameof(PetId), nameof(PetId))]
    public partial class DetailsViewModel : BaseViewModel
    {
        private readonly IPetsApi _petsApi;

        public DetailsViewModel(IPetsApi petsApi)
        {
            _petsApi = petsApi;
        }

        [ObservableProperty]
        private int _petId;

        [ObservableProperty]
        private PetDetailsDto _petDetails = new();

        async partial void OnPetIdChanging(int value)
        {
            IsBusy = true;

            try
            {
                var apiResponse = await _petsApi.GetPetDetailsAsync(value);

                if (apiResponse.IsSuccess)
                    PetDetails = apiResponse.Data;
                else
                    await ShowAlertAsync("грешка при извличането на детайли за домашен любимец", apiResponse.Message!);
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("грешка при извличането на детайли за домашен любимец", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoBack() => await GoToAsync("..");
    }
}
