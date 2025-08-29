namespace Domain.Enums
{
    public enum State
    {
        Initiat = 1,
        ReadyToSend = 2,
        NeedToRetry = 3,
        Send = 4,
        Failed = 5
    }
}
