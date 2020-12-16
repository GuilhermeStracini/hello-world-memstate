using Memstate;

namespace HelloWorldMemstate
{
    public class DepositCommand : Command<AccountDb, Participant>
    {
        public DepositCommand(int ispb, decimal depositValue)
        {
            Ispb = ispb;
            DepositValue = depositValue;
        }

        public int Ispb { get; }

        public decimal DepositValue { get; set; }

        public override Participant Execute(AccountDb model)
        {
            var participant = model.Participants[Ispb];

            var newBalance = participant.Balance + DepositValue;
            var participantWithNewBalance = new Participant(Ispb, newBalance);
            model.Participants[Ispb] = participantWithNewBalance;

            return participantWithNewBalance;
        }
    }
}
