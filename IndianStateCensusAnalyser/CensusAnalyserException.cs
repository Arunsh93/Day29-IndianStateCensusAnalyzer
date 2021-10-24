using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public enum ExcptionType
        {
            FILE_NOT_FOUND,
            INAVLID_FILE_TYPE,
            INCORRECT_DELIMETER,
            INCORRECT_HEADER,
            NO_SUCH_COUNTRY,
        }
        public ExcptionType eType;
        public CensusAnalyserException(string message, ExcptionType excptionType) : base(message)
        {
            this.eType = excptionType;
        }
    }
}
