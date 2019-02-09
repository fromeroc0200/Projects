using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remember
{
    class MemoChecker
    {
        IQueryable<Memo> _memos;
        IMemoDueNotifier _notifier;

        public MemoChecker(IQueryable<Memo> memos, IMemoDueNotifier notifier)
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
