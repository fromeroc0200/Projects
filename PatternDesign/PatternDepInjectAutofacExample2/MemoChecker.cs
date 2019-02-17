using System;
using System.Collections.Generic;
using System.Linq;

namespace PatternDepInjectAutofacExample2
{
    class MemoChecker
    {
        readonly IList<Memo> _memos;
        readonly IMemoDueNotifier _notifier;

        public MemoChecker(IList<Memo> memos, IMemoDueNotifier notifier)
        {
            _memos = memos;
            _notifier = notifier;
        }

        public void CheckNow()
        {
            var overdueMemos = _memos.Where(memo => memo.DueAt < DateTime.Now);

            foreach (var memo in overdueMemos)
                _notifier.MemoIsDue(memo);
        }
    }
}
