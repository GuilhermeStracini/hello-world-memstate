using Memstate;
using System;

namespace HelloWorldMemstate
{
    public class WithdrawalCommand : Command<AccountDb, Participant>
    {
        public WithdrawalCommand(int ispb, decimal withdrawalValue)
        {
            Ispb = ispb;
            WithdrawalValue = withdrawalValue;
        }

        public int Ispb { get; }

        public decimal WithdrawalValue { get; }

        public override Participant Execute(AccountDb model)
        {
            var participant = model.Participants[Ispb];

            if (participant.Balance < WithdrawalValue)
                throw new InvalidOperationException($"Invalid new balance for the participant {Ispb}");

            var newBalance = participant.Balance - WithdrawalValue;
            var participantWithNewBalance = new Participant(Ispb, newBalance);
            model.Participants[Ispb] = participantWithNewBalance;

            return participantWithNewBalance;
        }
    }
}
