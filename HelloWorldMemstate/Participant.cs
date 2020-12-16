namespace HelloWorldMemstate
{
    public class Participant
    {
        public Participant(int ispb, decimal balance)
        {
            Ispb = ispb;
            Balance = balance;
        }

        public int Ispb { get; }

        public decimal Balance { get; }

        public override string ToString() => $"Participant[{Ispb}] balance R$ {Balance}.";
    }
}