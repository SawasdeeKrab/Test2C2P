namespace Test2C2P.Data.Entities
{
    using GenericRepository.Entities;
    using GenericRepository.Interface;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Payment")]
    public partial class Payment : Entity, IAggregateRoot
    {

        public decimal Amount { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrencyCode { get; set; }

        public DateTime TransactionDate { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }
    }
}
