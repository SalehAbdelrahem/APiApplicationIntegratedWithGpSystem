namespace IntegratorWithGp.Core.DTO.ResponseApi
{
    public class ApiResponse<T> : GeneralResponceApi
    {
        public T Data { get; set; }
    }
}
