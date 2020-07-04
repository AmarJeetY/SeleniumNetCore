﻿using System;
using System.Collections.Generic;
using System.IO;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Utilities.CSV
{
    class TestData : ITestData
    {
        private readonly ITestCaseParser _testCaseRepository;
        private readonly IDataReader _dataReader;

        public TestData(IDataReader dataReader, ITestCaseParser testCaseRepository)
        {
            _testCaseRepository = testCaseRepository ?? throw new ArgumentNullException(nameof(testCaseRepository));
            _dataReader = dataReader ?? throw new ArgumentNullException(nameof(dataReader));
        }

        public Dictionary<string, string> GetTestParameters(string testCase)
        {
            var csvFilePath = Path.Combine(@"./Features/TestData.csv");
            var testData = _dataReader.ReadData(csvFilePath);

            var parameters = _testCaseRepository.GetTestParameters(testData, testCase);
            return parameters;
        }
    }
}

