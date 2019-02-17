using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Remember
{
    class PrintingNotifier : IMemoDueNotifier
    {
        TextWriter _writer;

        public PrintingNotifier(TextWriter writer)
        {
            _writer = writer;
        }

        public void MemoIsDue(Memo memo)
        {
            _writer.WriteLine("Memo '{0}' is due!", memo.Title);
        }
    }
}
