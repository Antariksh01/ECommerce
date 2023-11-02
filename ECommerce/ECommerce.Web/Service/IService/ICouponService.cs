using ECommerce.Web.Models;

namespace ECommerce.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponByCodeAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponsByIdAsync(int id);
        Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponsAsync(int id);
    }
}
