using PetAdoptionMAUI.Shared.Dtos.Request;
using PetAdoptionMAUI.Shared.Dtos.Response;

namespace PetAdoptionMAUI.Mobile.Services
{
    public class AuthService
    {
        private readonly CommonService _commonService;
        private readonly IAuthApi _authApi;

        public AuthService(CommonService commonService, IAuthApi authApi)
        {
            _commonService = commonService;
            _authApi = authApi;
        }

        public async Task<bool> LoginRegisterAsync(LoginRegisterModel model)
        {
            ApiResponse<AuthResponseDto> apiResponse = null!;

            try
            {
                if (model.IsNewUser)
                    apiResponse = await _authApi.RegisterAsync(new RegisterRequestDto
                    {
                        Email = model.Email,
                        Name = model.Name,
                        Password = model.Password
                    });
                else
                    apiResponse = await _authApi.LoginAsync(new LoginRequestDto
                    {
                        Email = model.Email,
                        Password = model.Password
                    });
            }
            catch (Refit.ApiException)
            {
                await App.Current!.Windows!.First()!.Page!.DisplayAlert("Грешка", "Невалиден имейл адрес", "OK");
                return false;
            }

            if (!apiResponse.IsSuccess)
            {
                await App.Current!.Windows!.First()!.Page!.DisplayAlert("Грешка", apiResponse.Message, "OK");
                return false;
            }

            var user = new LoggedInUser(apiResponse.Data.UserId, apiResponse.Data.Name, apiResponse.Data.Token);
            SetUser(user);

            _commonService.SetToken(apiResponse.Data.Token);

            return true;
        }

        private void SetUser(LoggedInUser user) => Preferences.Default.Set(UIConstants.UserInfo, user.ToJson());

        public async Task LogOut()
        {
            _commonService.SetToken(string.Empty);
            Preferences.Default.Remove(UIConstants.UserInfo);
        }

        public LoggedInUser GetUser()
        {
            var userJson = Preferences.Default.Get(UIConstants.UserInfo, string.Empty);

            return LoggedInUser.LoadFromJson(userJson)!;
        }

        public bool IsLoggedIn => Preferences.Default.ContainsKey(UIConstants.UserInfo);
    }
}
