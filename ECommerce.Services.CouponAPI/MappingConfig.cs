using AutoMapper;
using ECommerce.Services.CouponAPI.Models;
using ECommerce.Services.CouponAPI.Models.Dto;

namespace ECommerce.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {

                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            
            return mappingConfig;
        }
    }
}
