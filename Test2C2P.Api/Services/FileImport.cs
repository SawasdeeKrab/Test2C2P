using AutoMapper;
using ChoETL;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Test2C2P.Api.Models;
using Test2C2P.Data.Entities;
using Test2C2P.Data.Interfaces;

namespace Test2C2P.Api.Services
{
    public class FileImport : IFileImport
    {
        private readonly IPaymentRepository paymentRepository;
        public FileImport(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }
        public void CSV(Stream fileStream)
        {
            var stream = new StreamReader(fileStream);
            using (stream)
            {
                var fileContent = "";
                while (stream.Peek() >= 0)
                {
                    var line = stream.ReadLine();
                    line = Regex.Replace(line, @"(""[^"",]+),([^""]+"")",
                        m => m.Value.Replace(",", ""));
                    line = line.Replace("\"", "");
                    fileContent += line + Environment.NewLine;
                }

                foreach (var rec in ChoCSVReader<PaymentModel>.LoadText(fileContent))
                {
                    var payment = Mapper.Map<Payment>(rec);
                    paymentRepository.Insert(payment);
                }
            }
        }

        public void XML(Stream fileStream)
        {
            var stream = new StreamReader(fileStream);
            using (stream)
            {
                using (var parser = new ChoXmlReader(stream))
                {
                    dynamic row;
                    while ((row = parser.Read()) != null)
                    {
                        var paymentDto = new PaymentModel()
                        {
                            Id = row.Id,
                            TransactionDate = Convert.ToDateTime(row.TransactionDate),
                            Amount = Convert.ToDecimal(row.PaymentDetails.Amount),
                            CurrencyCode = row.PaymentDetails.CurrencyCode,
                            Status = row.Status
                        };
                        var payment = Mapper.Map<Payment>(paymentDto);
                        paymentRepository.Insert(payment);
                    }
                }
            }
        }

    }
}