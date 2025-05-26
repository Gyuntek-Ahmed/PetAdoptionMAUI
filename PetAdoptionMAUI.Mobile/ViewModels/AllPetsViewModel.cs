namespace PetAdoptionMAUI.Mobile.ViewModels
{
    public partial class AllPetsViewModel : BaseViewModel
    {
        private readonly IPetsApi _petsApi;

        public AllPetsViewModel(IPetsApi petsApi)
        {
            _petsApi = petsApi;
        }

        private IEnumerable<PetListDto> _pets = Enumerable.Empty<PetListDto>();

        [ObservableProperty]
        private bool _isRefreshing;

        private bool _isInitialized;

        public async Task InizializeAsync()
        {
            if(_isInitialized)
                return;

            await LoadAllPets();
        }

        private async Task LoadAllPets()
        {
            IsBusy = true;

            try
            {
                var apiResponse = await _petsApi.GetAllPetsAsync();

                if (apiResponse.IsSuccess)
                    Pets = apiResponse.Data;
                
                else
                {
                    await ShowAlertAsync("грешка при зареждане на всички животни", apiResponse.Message!);
                }
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("грешка при зареждане на всички животни", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
