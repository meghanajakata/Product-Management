using AutoMapper;
using Product_Services.Models;
using Product_Services.Models.DTO;
using Microsoft.Extensions.Logging;

namespace Product_Services
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var loggerFactory = LoggerFactory.Create(builder => { });
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            },
            loggerFactory);
            return mappingConfig;
        }
    }
}
