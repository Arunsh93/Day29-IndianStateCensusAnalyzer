using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyzer
{
    public abstract class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            if(!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("FIle No Found", CensusAnalyserException.ExcptionType.FILE_NOT_FOUND);
            }
            if(Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExcptionType.INAVLID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if(censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect Header in Data", CensusAnalyserException.ExcptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
