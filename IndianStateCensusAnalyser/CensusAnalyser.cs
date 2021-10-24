using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, USA, BRAZIL
        }

        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, Country country, string dataHeader)
        {
            dataMap = new CsvAdapterFactory().LoadCsvData(country, csvFilePath, dataHeader);
            return dataMap;
        }
    }
}
