using MicroserviceAralık.Discount.Entities;

namespace MicroserviceAralık.Discount.Services.CouponRedemptionServices;

public interface IDiscountCouponRedemptionService
{
    Task<List<CouponRedemption>> GetCouponRedemptions();
    Task<CouponRedemption> GetCouponRedemptionById(int id);
    Task<CouponRedemption> CreateCouponRedemtion(CouponRedemption couponRedemption);
    Task<CouponRedemption> UpdateCouponRedemtion(CouponRedemption couponRedemption);
    Task<bool> DeleteCouponRedemption(int id);
}
