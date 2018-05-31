namespace GiftAidCalculator.TestConsole.EventSupplement
{
    public class Running : ISupplementEventType
    {
        public string EventName { get => "running"; }

        public decimal Percentage { get => 5m; }
    }
}
