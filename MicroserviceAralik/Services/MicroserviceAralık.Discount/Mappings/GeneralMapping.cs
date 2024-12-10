using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using MicroserviceAralık.Discount.Entities;
using MicroserviceAralık.Discount.Protos;

namespace MicroserviceAralık.Discount.Mappings;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Coupon, GetCouponResponse>().ReverseMap();
        CreateMap<CouponRedemption, GetCouponRedemptionResponses>().ReverseMap();

        CreateMap<Timestamp, DateTime>().ConvertUsing(p => p == null ? default : p.ToDateTime());

        CreateMap<DateTime, Timestamp>().ConvertUsing(c => Timestamp.FromDateTime(c.ToUniversalTime()));


    }
}
