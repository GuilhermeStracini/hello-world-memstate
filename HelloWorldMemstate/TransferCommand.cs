using Memstate;
using System;

namespace HelloWorldMemstate
{
    class TransferCommand : Command<AccountDb, TransferResult>
    {
        public TransferCommand(int senderIspb, int receiverIspb, decimal value)
        {
            if (senderIspb == receiverIspb)
                throw new InvalidOperationException("Sender and receiver cannot be the same");

            SenderIspb = senderIspb;
            ReceiverIspb = receiverIspb;
            Value = value;
        }

        public int SenderIspb { get; }

        public int ReceiverIspb { get; }

        public decimal Value { get; }

        public override TransferResult Execute(AccountDb model)
        {
            var sender = model.Participants[SenderIspb];
            var receiver = model.Participants[ReceiverIspb];

            if (sender.Balance < Value)
                throw new InvalidOperationException($"Invalid balance of participant {SenderIspb}");

            var newSender = new Participant(sender.Ispb, sender.Balance - Value);
            var newReceiver = new Participant(receiver.Ispb, receiver.Balance + Value);

            model.Participants[SenderIspb] = newSender;
            model.Participants[ReceiverIspb] = newReceiver;

            return new TransferResult(newSender, newReceiver, Value);
        }
    }
}
