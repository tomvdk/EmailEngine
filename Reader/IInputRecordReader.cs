using System;
using System.Collections.Generic;

namespace EmailEngine.Reader
{
    public interface IInputRecordReader
    {
        IList<InputRecord> ReadAllInputRecords();
    }
}
