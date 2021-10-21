using IndianStateCensusAnalyzer.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyzer
{
    public class CsvAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeader)
        {
            switch(country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeader);
         
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExcptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
