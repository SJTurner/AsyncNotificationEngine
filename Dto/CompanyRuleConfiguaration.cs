namespace Dto
{
    public class CompanyRuleConfiguaration
    {
        public int CompanyId { get; set; }
        public int DaysBeforeEventToSendNotification { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
