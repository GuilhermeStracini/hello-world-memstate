using Memstate;

namespace HelloWorldMemstate
{
    public class InitParticipantCommand : Command<AccountDb, Participant>
    {
        public InitParticipantCommand(int ispb, decimal currentBalance)
        {
            Ispb = ispb;
            CurrentBalance = currentBalance;
        }

        public int Ispb { get; }

        public decimal CurrentBalance { get; }

        public override Participant Execute(AccountDb model)
        {
            var participant = new Participant(Ispb, CurrentBalance);
            model.Participants[Ispb] = participant;
            return participant;
        }
    }
}
