using Product.Web.Models;
using Product.Web.Service.IService;
using Product.Web.Utility;
using static Product.Web.Utility.StaticDetails;

namespace Product.Web.Service
{
    public class CouponService : ICouponService
    {
        readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        async Task<ResponseDTO?> ICouponService.CreateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiTypes.POST,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/",
                Data = couponDTO 
            });
        }

        async Task<ResponseDTO?> ICouponService.DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiTypes.DELETE,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/"+ id
            });
        }

        async Task<ResponseDTO?> ICouponService.GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiTypes.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/",
            });
        }

        async Task<ResponseDTO?> ICouponService.GetCouponAsync(string CouponCode)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiTypes.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/GetByCode/"+CouponCode
            });
        }

        async Task<ResponseDTO?> ICouponService.GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiTypes.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/" + id
            });
        }

        async Task<ResponseDTO?> ICouponService.UpdateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = ApiTypes.PUT,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/",
                Data = couponDTO
            });
        }
    }
}