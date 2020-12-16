using Memstate;
using System;
using System.Threading.Tasks;

namespace HelloWorldMemstate
{
    class Program
    {

        private const int Gbs = 34291019;

        private const int EdI = 05944298;

        private const int Fk1 = 78154982;

        private const int Fk2 = 45803597;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var engine = await Engine.Start<AccountDb>().ConfigureAwait(false);
            await engine.Execute(new InitParticipantCommand(Gbs, 1000M)).ConfigureAwait(false);
            await engine.Execute(new InitParticipantCommand(EdI, 1000M)).ConfigureAwait(false);
            await engine.Execute(new InitParticipantCommand(Fk1, 100000000M)).ConfigureAwait(false);
            await engine.Execute(new InitParticipantCommand(Fk2, 10000000M)).ConfigureAwait(false);

            var transfer = await engine.Execute(new TransferCommand(Gbs, EdI, 1000M)).ConfigureAwait(false);

            Console.WriteLine($"Transfer done: {transfer}");
        }
    }
}
