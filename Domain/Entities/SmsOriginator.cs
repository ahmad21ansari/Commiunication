using Domain.Enums;

namespace Domain.Entities
{
    public class SmsOriginator : BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public SmsAggregatorType AggregatorType { get; set; }

    }
}
