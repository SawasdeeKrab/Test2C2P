using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test2C2P.Api.Models;
using Test2C2P.Api.Services;
using Test2C2P.Data.Entities;
using Test2C2P.Data.Interfaces;

namespace Test2C2P.Api.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : BaseController
    {
        private readonly IPaymentRepository paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll()
        {
            var result = paymentRepository.GetAll();
            var response = Mapper.Map<IEnumerable<Payment>, IEnumerable<ResponseModel>>(result);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("GetByCurrency")]
        public HttpResponseMessage GetByCurrency(string currency)
        {
            var currentcyNumber = Iso4217Lookup.LookupByCode(currency).Number.ToString();
            var result = paymentRepository.Query(x => x.CurrencyCode == currentcyNumber);
            var response = Mapper.Map<IEnumerable<Payment>, IEnumerable<ResponseModel>>(result);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("GetByDateRange")]
        public HttpResponseMessage GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var result = paymentRepository.Query(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate);
            var response = Mapper.Map<IEnumerable<Payment>, IEnumerable<ResponseModel>>(result);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("GetByStatus")]
        public HttpResponseMessage GetByStatus(string status)
        {
            var result = paymentRepository.Query(x => x.Status == status);
            var response = Mapper.Map<IEnumerable<Payment>, IEnumerable<ResponseModel>>(result);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(response));
        }

    }
}
