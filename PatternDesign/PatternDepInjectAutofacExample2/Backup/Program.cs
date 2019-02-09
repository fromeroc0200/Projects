using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Builder;
using System.IO;

namespace Remember
{
    class Program
    {
        static void Main(string[] args)
        {
            var memos = new List<Memo>() {
                new Memo { Title = "Release Autofac 1.1", DueAt = DateTime.Now },
                new Memo { Title = "Write CodeProject Article", DueAt = DateTime.Now },
                new Memo { Title = "Release Autofac 1.2", DueAt = new DateTime(2008, 07, 01) }
            }.AsQueryable();

            var builder = new ContainerBuilder();
            builder.Register(c => new MemoChecker(c.Resolve<IQueryable<Memo>>(), c.Resolve<IMemoDueNotifier>()));
            builder.Register(c => new PrintingNotifier(c.Resolve<TextWriter>())).As<IMemoDueNotifier>();
            builder.Register(memos);
            builder.Register(Console.Out).As<TextWriter>().ExternallyOwned();

            using (var container = builder.Build())
            {
                container.Resolve<MemoChecker>().CheckNow();
            }

            Console.WriteLine("Done! Press any key.");
            Console.ReadKey();
        }
    }
}
