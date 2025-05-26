namespace PetAdoptionMAUI.Mobile.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly IPetsApi _petsApi;

        public HomeViewModel(IPetsApi petsApi)
        {
            _petsApi = petsApi;
        }

        [ObservableProperty]
        private IEnumerable<PetListDto> _newlyAdded = Enumerable.Empty<PetListDto>();

        [ObservableProperty]
        private IEnumerable<PetListDto> _popular = Enumerable.Empty<PetListDto>();

        [ObservableProperty]
        private IEnumerable<PetListDto> _random = Enumerable.Empty<PetListDto>();

        [ObservableProperty]
        private string _userName = "Непознат";

        private bool _isInitialized;

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            IsBusy = true;

            try
            {
                var newlyAddedTask = _petsApi.GetNewlyAddedPetsAsync(10);
                var popularPetsTask = _petsApi.GetPopularPetsAsync(15);
                var randomPetsTask = _petsApi.GetRandomPetsAsync(20);

                NewlyAdded = (await newlyAddedTask).Data;
                Popular = (await popularPetsTask).Data;
                Random = (await randomPetsTask).Data;

                _isInitialized = true;
            }
            catch (Refit.ApiException ex)
            {
                await ShowAlertAsync("Грешка", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToDetailsPage(int petId)
            => await GoToAsync($"{nameof(DetailsPage)}?{nameof(DetailsViewModel.PetId)}={petId}");
    }
}
