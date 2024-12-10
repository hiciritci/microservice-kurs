using MicroserviceAralık.Discount.Context;
using MicroserviceAralık.Discount.Entities;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace MicroserviceAralık.Discount.Services.CouponRedemptionServices;

public class DiscountCouponRedemtionService(AppDbContext _context) : IDiscountCouponRedemptionService
{
    public async Task<CouponRedemption> CreateCouponRedemtion(CouponRedemption couponRedemption)
    {
        var result = await _context.CouponRedemptions.AddAsync(couponRedemption);
        await _context.SaveChangesAsync();
        return result.Entity;

    }

    public async Task<bool> DeleteCouponRedemption(int id)
    {
        var redemption = await _context.CouponRedemptions.FindAsync(id);
        var result = _context.CouponRedemptions.Remove(redemption);
        await _context.SaveChangesAsync();
        return result != null ? true : false;
    }

    public async Task<CouponRedemption> GetCouponRedemptionById(int id)
    {
        return await _context.CouponRedemptions.FindAsync(id);
    }

    public async Task<List<CouponRedemption>> GetCouponRedemptions()
    {
        return await _context.CouponRedemptions.ToListAsync();
    }

    public async Task<CouponRedemption> UpdateCouponRedemtion(CouponRedemption couponRedemption)
    {
        var result = _context.CouponRedemptions.Update(couponRedemption);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
}
