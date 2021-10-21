using IndianStateCensusAnalyzer.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyzer.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"E:\ASP.NET\Day29-IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongDataFilePath = @"E:\ASP.NET\Day29-IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\IndianData.csv";
        static string IndianStateCensus = @"E:\ASP.NET\Day29-IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\IndiaStateCensus.txt";
        static string wrongIndianStateCensusFileHeader = @"E:\ASP.NET\Day29-IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string IndianStateCesusFilePathWithWrongDelimeter = @"E:\ASP.NET\Day29-IndianStateCensusAnalyzer\CensusAnalyserTest\CSVFiles\IndiaStateCensusDelimeter.csv";
        IndianStateCensusAnalyzer.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyzer.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeader);
            Assert.AreEqual(5, totalRecord.Count);
        }
    }
}