namespace AloVoIP.OpenCRM.Dto
{
    public class CardtableResultDto : OperationResultDto
    {
        public int TotalItemsCount { get; set; }
        public CardtableItemDto[] CardtableItems { get; set; }
    }
}
