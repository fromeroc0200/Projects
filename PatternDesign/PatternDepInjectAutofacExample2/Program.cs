using System;
using System.Collections.Generic;
using Autofac;
using System.IO;

namespace PatternDepInjectAutofacExample2
{
    class Program
    {
        static void Main()
        {
            var memos = new List<Memo> {
                new Memo { Title = "Release Autofac 1.1", DueAt = new DateTime(2007, 03, 12) },
                new Memo { Title = "Update CodeProject Article", DueAt = DateTime.Now },
                new Memo { Title = "Release Autofac 3", DueAt = new DateTime(2011, 07, 01) }
            };

            var builder = new ContainerBuilder();
            builder.RegisterType<MemoChecker>();
            //builder.Register(c => new MemoChecker(c.Resolve<IList<Memo>>(), c.Resolve<IMemoDueNotifier>()));
            builder.RegisterType<PrintingNotifier>().As<IMemoDueNotifier>();
            builder.RegisterInstance(memos).As<IList<Memo>>();
            builder.RegisterInstance(Console.Out).As<TextWriter>().ExternallyOwned();

            using (var container = builder.Build())
            {
                container.Resolve<MemoChecker>().CheckNow();
            }

            Console.WriteLine("Done! Press any key.");
            Console.ReadKey();
        }
    }
}
