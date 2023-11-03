using AutoMapper;
using ECommerce.Services.CouponAPI.Data;
using ECommerce.Services.CouponAPI.Models;
using ECommerce.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPI : ControllerBase
    {
        private AppDbContext _context;
        private ResponseDto _responseDto;
        private IMapper _mapper;
        public CouponAPI(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            var result = _context.Coupons.ToList();
            _responseDto.Response = _mapper.Map<IEnumerable<CouponDto>>(result);
            return _responseDto;
        }

        [HttpGet("GetByCouponId/{id}")]
        public ResponseDto GetByID(int id)
        {
            var obj = _context.Coupons.FirstOrDefault(x => x.CouponId == id);
            _responseDto.Response =  _mapper.Map<CouponDto>(obj);
            if (obj == null)
            {
                _responseDto.Success = false;
                _responseDto.Message = "Sorry there is no such coupon with the id " + id;
                return _responseDto;
                //return NotFound("Sorry there is no such coupon with the id " + id);
            }
            return _responseDto;
        }

        [HttpGet("GetByCouponCode/{code}")]
        public ResponseDto GetByCouponCode(string couponCode)
        {
            var obj = _context.Coupons.FirstOrDefault(x => x.CouponCode == couponCode);
            _responseDto.Response = _mapper.Map<CouponDto>(obj);
            if (obj == null)
            {
                _responseDto.Success = false;
                _responseDto.Message = "Sorry there is no such coupon";
                return _responseDto;
                //return NotFound("Sorry there is no such coupon with the id " + id);
            }
            return _responseDto;
        }

        [HttpPost]
        public ResponseDto AddCoupon([FromBody] CouponDto couponDto)
        {
            Coupon coupon = _mapper.Map<Coupon>(couponDto);
            _context.Coupons.Add(coupon);
            _context.SaveChanges();

            _responseDto.Response = _mapper.Map<CouponDto>(coupon);          
            
            return _responseDto;
        }

        [HttpPut]
        public ResponseDto UpdateCoupon([FromBody] CouponDto couponDto)
        {
            Coupon coupon = _mapper.Map<Coupon>(couponDto);
            _context.Coupons.Update(coupon);
            _context.SaveChanges();

            _responseDto.Response = _mapper.Map<CouponDto>(coupon);

            return _responseDto;
        }

        [HttpDelete("{id}")]
        public ResponseDto DeleteCoupon(int id)
        {
            Coupon coupon = _context.Coupons.First(x=>x.CouponId == id);
            _context.Coupons.Remove(coupon);
            _context.SaveChanges();

            //_responseDto.Response = _mapper.Map<CouponDto>(coupon);

            return _responseDto;
        }
    }
}
