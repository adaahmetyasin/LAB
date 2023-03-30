internal class InvoiceNotificationSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Notification sent: {message}");
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}