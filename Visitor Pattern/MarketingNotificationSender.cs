internal class MarketingNotificationSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Marketing notification sent: {message}");
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}