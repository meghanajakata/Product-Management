using Product.Web.Models;

namespace Product.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO> SendAsync(RequestDTO requestDTO);

    }
}
