using System.Collections.Generic;

namespace HelloWorldMemstate
{
    public class AccountDb
    {
        public AccountDb()
        { }

        public IDictionary<int, Participant> Participants { get; } = new Dictionary<int, Participant>();
    }
}
