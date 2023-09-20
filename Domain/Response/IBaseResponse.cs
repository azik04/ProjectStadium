using Domain.Enums;

namespace Domain.Response;
public interface IBaseResponse<T>
{
    string Description { get; set; }
    T Data { get; set; }
    StatusCode StatusCode { get; }
}