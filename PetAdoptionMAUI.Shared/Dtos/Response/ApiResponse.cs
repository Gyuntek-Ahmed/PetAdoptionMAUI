namespace PetAdoptionMAUI.Shared.Dtos.Response
{
    public record ApiResponse(bool IsSuccess, string? Message = null)
    {
        public static ApiResponse Success(string? message = null) => new(true, message);
        public static ApiResponse Fail(string? message = null) => new(false, message);
    }

    public record ApiResponse<TData>(bool IsSuccess, TData Data, string? Message)
    {
        public static ApiResponse<TData> Success(TData data) => new(true, data, null);
        public static ApiResponse<TData> Fail(string? message) => new(false, default!, message);
    }
}
