using System.IO;

namespace PatternDepInjectAutofacExample2
{
    class PrintingNotifier : IMemoDueNotifier
    {
        readonly TextWriter _writer;

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
