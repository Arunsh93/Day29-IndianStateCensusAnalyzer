using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeader = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"E:\ASP.NET\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongDataFilePath = @"E:\ASP.NET\CensusAnalyserTest\CSVFiles\IndianData.csv";
        static string IndianStateCensus = @"E:\ASP.NET\CensusAnalyserTest\CSVFiles\IndiaStateCensus.txt";
        static string wrongIndianStateCensusFileHeader = @"E:\ASP.NET\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string IndianStateCesusFilePathWithWrongDelimeter = @"E:\ASP.NET\CensusAnalyserTest\CSVFiles\IndianStateCesusDelimeter.csv";
        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeader);
            Assert.AreEqual(5, totalRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnWrongFileNotFoundCustomExcption()
        {
            var censusExcption = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDataFilePath, Country.INDIA, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExcptionType.FILE_NOT_FOUND, censusExcption.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnWrongFileTypeCustomExcption()
        {
            var censusExcption = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensus, Country.INDIA, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExcptionType.INAVLID_FILE_TYPE, censusExcption.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnWrongDelimeterCustomExcption()
        {
            var censusExcption = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCesusFilePathWithWrongDelimeter, Country.INDIA, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExcptionType.INCORRECT_DELIMETER, censusExcption.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnWrongHeaderCustomExcption()
        {
            var censusExcption = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileHeader, Country.INDIA, indianStateCensusHeader));
            Assert.AreEqual(CensusAnalyserException.ExcptionType.INCORRECT_HEADER, censusExcption.eType);
        }
    }
}

