using System;
using System.Collections.Generic;

namespace AloVoIP.OpenCRM.Dto
{
    public class CreateSalesInvoiceDto
    {
        public CreateSalesInvoiceDto()
        {
            ExtendedProperties = new List<ExtendedPropertiesDto>();
            ProductDetails = new List<ProductDetailsDto>();
        }
        public string CrmId { get; set; }
        public string CrmObjectTypeCode { get; set; }
        public string RefId { get; set; }
        public string IdentityId { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public decimal FinalValue { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public decimal Toll { get; set; }
        public decimal AdditionalCosts { get; set; }
        public decimal TotalValue { get; set; }
        public decimal VatPercent { get; set; }
        public decimal TollPercent { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal TotalDiscountPercent { get; set; }
        public List<ExtendedPropertiesDto> ExtendedProperties { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public List<ProductDetailsDto> ProductDetails { get; set; }
    }
}
