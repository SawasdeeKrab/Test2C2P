using AutoMapper;
using ChoETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Test2C2P.Api.Services;
using Test2C2P.Data.Entities;

namespace Test2C2P.Api.Models
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            ConfigureDataMapping();
        }
        private static void ConfigureDataMapping()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Payment, PaymentModel>()
                    .ForMember(des => des.CurrencyCode,
                           opt => opt.MapFrom(src => Iso4217Lookup.LookupByNumber(Convert.ToInt32(src.CurrencyCode)).Code));
                cfg.CreateMap<PaymentModel, Payment>()
                    .ForMember(des => des.CurrencyCode,
                           opt => opt.MapFrom(src => Iso4217Lookup.LookupByCode(src.CurrencyCode).Number.ToString()));
                cfg.CreateMap<Payment, ResponseModel>()
                    .ForMember(des => des.Status, opt => opt.MapFrom(src => (src.Status == "Approved" ? "A" : src.Status == "Rejected" ? "R" : "D")))
                    .ForMember(des => des.Payment,
                           opt => opt.MapFrom(src => src.Amount + " " + Iso4217Lookup.LookupByNumber(Convert.ToInt32(src.CurrencyCode)).Code));

                cfg.CreateMap<List<Payment>, List<PaymentModel>>();
                cfg.CreateMap<List<PaymentModel>, List<Payment>>();
                cfg.CreateMap<List<Payment>, List<ResponseModel>>();
                cfg.CreateMap<List<ResponseModel>, List<Payment>>();
            });
        }
    }
}