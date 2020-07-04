using System.Collections.Generic;

namespace BellTest.Internals
{
    public interface ICodeList
    {
        BellCode GetRandomCode();

        IEnumerable<BellCode> GetAllCodes();
    }
}
