using ECommerce.Web.Models;
using ECommerce.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace ECommerce.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult?> CouponIndex()
        {
            List<CouponDto> list = null;
            ResponseDto? responseDto = await _couponService.GetAllCouponsAsync();
            if (responseDto != null)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Response));
            }
            return View(list);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CouponCreate(CouponDto model)
		{
            if (ModelState.IsValid)
            {
				List<CouponDto> list = null;
				ResponseDto? responseDto = await _couponService.CreateCouponsAsync(model);
				if (responseDto != null)
				{
					return RedirectToAction(nameof(CouponIndex));
				}
                
			}
			return View(model);
		}

        
        public async Task<IActionResult> CouponDelete(int couponId)
        {
			
			ResponseDto? responseDto = await _couponService.GetCouponsByIdAsync(couponId);
			if (responseDto != null)
			{
				CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseDto.Response));
                return View(model);
			}
			return NotFound();

		}

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {

            ResponseDto? responseDto = await _couponService.DeleteCouponsAsync(couponDto.CouponId);
            if (responseDto != null)
            {
                return RedirectToAction(nameof(CouponIndex));
            }
            return View(couponDto);

        }
    }
}
