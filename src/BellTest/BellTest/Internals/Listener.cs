using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace BellTest.Internals
{
    public class Listener : IListener, IDisposable
    {
        private readonly List<DateTime> _bells = new List<DateTime>();
        private bool disposedValue;
        private readonly Timer _timer;
        private const int _timeout = 1000;
        private const int _groupGap = 350;

        public event BellCodeEventHandler BellCodeParsed;

        public Listener()
        {
            _timer = new Timer(_timeout) { AutoReset = false };
            _timer.Elapsed += OnTimerEvent;
        }

        public IEnumerable<DateTime> GetData()
        {
            return _bells.TakeLast(10);
        }

        public void RecordPush()
        {
            _bells.Add(DateTime.Now);
            _timer.Stop();
        }

        public void RecordRelease()
        {
            _timer.Start();
        }

        private void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            BellCodeEventArgs args = new BellCodeEventArgs { CodeReceivedTime = _bells.Last(), Code = ParseBells() };
            _bells.Clear();
            BellCodeParsed?.Invoke(this, args);
        }

        private string ParseBells()
        {
            TimeSpan maxGap = new TimeSpan(0, 0, 0, 0, _groupGap);
            if (_bells.Count == 1)
            {
                return "1";
            }
            List<TimeSpan> gaps = new List<TimeSpan>(_bells.Count - 1);
            for (int i = 1; i < _bells.Count; ++i)
            {
                gaps.Add(_bells[i] - _bells[i - 1]);
            }
            var longGaps = gaps.Select((g, i) => new { Gap = g, Index = i }).Where(g => g.Gap > maxGap).Select(g => g.Index).ToList();
            if (longGaps.Count == 0)
            {
                return _bells.Count.ToString();
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
            groups.Add(_bells.Count - (longGaps.Last() + 1));
            return string.Join("-", groups.Select(g => $"{g}"));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _timer.Dispose();
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
