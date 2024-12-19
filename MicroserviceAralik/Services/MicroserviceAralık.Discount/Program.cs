using MicroserviceAral�k.Discount.Context;
using MicroserviceAral�k.Discount.Mappings;
using MicroserviceAral�k.Discount.Services;
using MicroserviceAral�k.Discount.Services.CouponRedemptionServices;
using MicroserviceAral�k.Discount.Services.CouponServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "ResourceDiscount";
    options.RequireHttpsMetadata = false;
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DiscountReadAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "DiscountReadPermission", "DiscountFullPermission");
    });
    options.AddPolicy("DiscountFullAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "DiscountFullPermission");
    });
});

builder.Services.AddScoped<IDiscountCouponService, DiscountCouponService>();
builder.Services.AddScoped<IDiscountCouponRedemptionService, DiscountCouponRedemptionService>();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));

builder.Services.AddGrpc().AddJsonTranscoding();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CouponsService>();
app.MapGrpcService<CouponRedemptionsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.UseAuthentication();
app.UseAuthorization();
app.Run();
