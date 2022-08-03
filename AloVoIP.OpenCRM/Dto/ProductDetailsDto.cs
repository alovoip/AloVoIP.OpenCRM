namespace AloVoIP.OpenCRM.Dto
{
    public class ProductDetailsDto
    {
        public ProductDetailsDto(string productCode, decimal baseUnitPrice)
        {
            ProductCode = productCode;
            BaseUnitPrice = baseUnitPrice;
            FinalUnitPrice = baseUnitPrice;
            TotalUnitPrice = baseUnitPrice;
            TotalDiscount = 0;
            Count = 1;
            TotalVat = 0;
            TotalToll = 0;
            DetailDescription = string.Empty;
            Serial = string.Empty;
            InventoryName = string.Empty;
            InventoryCode = string.Empty;
            IsService = true;
            ProductName = string.Empty;
            ProductId = string.Empty;
            ProductUnitTypeName = string.Empty;
            DiscountPercent = 0;
        }
        public string ProductCode { get; set; }
        public decimal BaseUnitPrice { get; set; }
        public string DetailDescription { get; set; }
        public decimal FinalUnitPrice { get; set; }
        public int Count { get; set; }
        public decimal TotalUnitPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalToll { get; set; }
        public string InventoryName { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Serial { get; set; }
        public string InventoryCode { get; set; }
        public bool IsService { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public decimal ReturnedCount { get; set; }
        public string ProductUnitTypeName { get; set; }
    }
}
