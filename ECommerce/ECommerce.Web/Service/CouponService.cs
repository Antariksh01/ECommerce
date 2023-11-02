using ECommerce.Web.Models;
using ECommerce.Web.Service.IService;
using ECommerce.Web.Utility;

namespace ECommerce.Web.Service
{
    public class CouponService : ICouponService
    {
        private IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {

            _baseService = baseService;

        }
        public async Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
        {
            var data = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = couponDto,
                ApiUrl = SD.CouponAPIBase + "/api/CouponAPI"

            });

            return data;
        }

        public async Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            var data = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.DELETE,
                ApiUrl = SD.CouponAPIBase + "/api/CouponAPI/" + id
            });

            return data;
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            var data = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/CouponAPI"
                
            });

            return data;
        }

        public async Task<ResponseDto?> GetCouponByCodeAsync(string couponCode)
        {
            var data = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/CouponAPI/GetByCouponCode/" + couponCode
            });

            return data;
        }

        public async Task<ResponseDto?> GetCouponsByIdAsync(int id)
        {
            var data = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/CouponAPI/GetByCouponId/" + id
            }); 

            return data;
        }

        public async Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
        {
            var data = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.PUT,
                Data = couponDto,
                ApiUrl = SD.CouponAPIBase + "/api/CouponAPI"

            });

            return data;
        }
    }
}
