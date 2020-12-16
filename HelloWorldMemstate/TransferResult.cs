namespace HelloWorldMemstate
{
    public class TransferResult
    {
        public TransferResult(Participant sender, Participant receiver, decimal value)
        {
            Sender = sender;
            Receiver = receiver;
            Value = value;
        }

        public Participant Sender { get; }
        public Participant Receiver { get; }
        public decimal Value { get; }

        public override string ToString() => $"Sent R$ {Value} | Sender: {Sender} | Receiver: {Receiver}";
    }
}
