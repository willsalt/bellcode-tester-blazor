using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BellTest.UnitTests.TestHelpers
{
    public static class RandomExtensions
    {
        public static string NextBellCode(this Random rnd)
        {
            if (rnd is null)
            {
                throw new NullReferenceException();
            }
            int[] content = new int[rnd.Next(4) + 1];
            for (int i = 0; i < content.Length; ++i)
            {
                content[i] = rnd.Next(9) + 1;
            }
            return string.Join('-', content.Select(c => c.ToString(CultureInfo.InvariantCulture)));
        }

        private const string theAlphabet = "abdefghjiklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ    ";

        public static string NextString(this Random rnd, int? length = null)
        {
            if (rnd is null)
            {
                throw new NullReferenceException();
            }
            if (!length.HasValue)
            {
                length = rnd.Next(60);
            }
            if (length.Value == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length.Value; ++i)
            {
                sb.Append(theAlphabet[rnd.Next(theAlphabet.Length)]);
            }
            return sb.ToString();
        }

        public static DateTime NextDateTime(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            long ticks = NextLong(random, DateTime.MaxValue.Ticks);
            return new DateTime().AddTicks(ticks);
        }

        public static long NextLong(this Random random, long max)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (max < uint.MaxValue)
            {
                return random.NextUInt((uint)max);
            }
            return random.NextUInt() | (long)random.Next((int)(max >> 32)) << 32;
        }

        public static uint NextUInt(this Random random)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (random.Next(2) == 0)
            {
                return (uint)random.Next();
            }
            return int.MaxValue + (uint)random.Next();
        }

        public static uint NextUInt(this Random random, uint max)
        {
            if (random is null)
            {
                throw new NullReferenceException();
            }
            if (max < int.MaxValue)
            {
                return (uint)random.Next((int)max);
            }
            return unchecked((uint)random.Next((int)(max >> 1)) << 1) | (uint)random.Next(2);
        }
    }
}
