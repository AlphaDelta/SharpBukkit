using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaDelta
{
    public class PropertyReaderException : FormatException
    {
        public PropertyReaderException(int line, string error)
            : base($"Line #{line}: {error}")
        { }
        public PropertyReaderException(int line, int index, string error)
            : base($"Line #{line}:{index}: {error}")
        { }
    }
}
