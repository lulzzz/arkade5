﻿using System.Numerics;

namespace Arkivverket.Arkade.Core
{
    public class TestSummary
    {
        public string NumberOfProcessedFiles { get; }
        public string NumberOfProcessedRecords { get; }
        public string NumberOfTestsRun { get; }

        public TestSummary(int numberOfProcessedFiles, int numberOfProcessedRecords, int numberOfTestsRun)
        {
            NumberOfProcessedFiles = numberOfProcessedFiles.ToString();
            NumberOfProcessedRecords = numberOfProcessedRecords.ToString();
            NumberOfTestsRun = numberOfTestsRun.ToString();
        }

    }
}