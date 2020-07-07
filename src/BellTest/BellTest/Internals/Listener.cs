using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Timers;

namespace BellTest.Internals
{
    public class Listener : IListener, IDisposable
    {
        private readonly List<DateTime> bells = new List<DateTime>();
        private bool disposedValue;
        private readonly Timer timer;
        private const int codeEndTimeout = 1000;
        private const int groupGapTimeout = 350;

        public event BellCodeEventHandler BellCodeParsed;

        public Listener()
        {
            timer = new Timer(codeEndTimeout) { AutoReset = false };
            timer.Elapsed += OnTimerEvent;
        }

        public IEnumerable<DateTime> GetData()
        {
            return bells.TakeLast(10);
        }

        public void RecordPush()
        {
            bells.Add(DateTime.Now);
            timer.Stop();
        }

        public void RecordRelease()
        {
            timer.Start();
        }

        private void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            BellCodeEventArgs args = new BellCodeEventArgs(bells.Last(), ParseBells());
            bells.Clear();
            BellCodeParsed?.Invoke(this, args);
        }

        private string ParseBells()
        {
            TimeSpan maxGap = new TimeSpan(0, 0, 0, 0, groupGapTimeout);
            if (bells.Count == 1)
            {
                return "1";
            }
            List<TimeSpan> gaps = new List<TimeSpan>(bells.Count - 1);
            for (int i = 1; i < bells.Count; ++i)
            {
                gaps.Add(bells[i] - bells[i - 1]);
            }
            var longGaps = gaps.Select((g, i) => new { Gap = g, Index = i }).Where(g => g.Gap > maxGap).Select(g => g.Index).ToList();
            if (longGaps.Count == 0)
            {
                return bells.Count.ToString(CultureInfo.CurrentCulture);
            }
            List<int> groups = new List<int>(longGaps.Count + 1);
            for (int i = 0; i < longGaps.Count; ++i)
            {
                if (i == 0)
                {
                    groups.Add(longGaps[0] + 1);
                }
                else
                {
                    groups.Add(longGaps[i] - longGaps[i - 1]);
                }
            }
            groups.Add(bells.Count - (longGaps.Last() + 1));
            return string.Join("-", groups.Select(g => $"{g}"));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    timer.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
