﻿using Arkivverket.Arkade.Core;
using Arkivverket.Arkade.ExternalModels.TestSessionLog;
using Arkivverket.Arkade.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Arkivverket.Arkade.Tests;
using System.Text;
using Serilog;

namespace Arkivverket.Arkade.Logging
{
    public class TestSessionXmlGenerator
    {
        public static void GenerateXmlAndSaveToFile(TestSession testSession)
        {
            string xml = GenerateXml(testSession);
            DirectoryInfo workingDirectory = testSession.Archive.WorkingDirectory;
            string pathToLogFile = workingDirectory.FullName + "\\arkade-log.xml";
            Log.Information("Writing xml log file to {LogFile}", pathToLogFile);
            File.WriteAllText(pathToLogFile, xml);
        }

        public static string GenerateXml(TestSession testSession)
        {
            testSessionLog log = new testSessionLog();
            log.timestamp = DateTime.Now;
            log.arkadeVersion = ArkadeVersion.Version;

            log.archiveType = testSession?.Archive?.ArchiveType.ToString();
            log.archiveUuid = testSession?.Archive?.Uuid?.GetValue();

            log.logEntries = GetLogEntries(testSession);
            log.testResults = GetTestResults(testSession);

            return CreateXml(log);
        }

        private static testResultsTestResult[] GetTestResults(TestSession testSession)
        {
            var xmlTestResults = new List<testResultsTestResult>();
            foreach (TestRun testRun in testSession.TestSuite.TestRuns)
            {
                var testResult = new testResultsTestResult();
                testResult.testName = testRun.TestName;
                testResult.testCategory = testRun.TestCategory;
                testResult.durationMillis = testRun.TestDuration.ToString();
                testResult.testDescription = testRun.TestDescription;
                testResult.status = testRun.IsSuccess() ? "SUCCESS" : "ERROR";
                testResult.message = ConcatMessages(testRun.Results);
                xmlTestResults.Add(testResult);
            }
            return xmlTestResults.Count == 0 ? null : xmlTestResults.ToArray();
        }

        private static string ConcatMessages(List<TestResult> results)
        {
            StringBuilder sb = new StringBuilder("");
            foreach (var result in results)
            {
                sb.AppendLine(result.Message);
            }

            return sb.ToString().TrimEnd();
        }

        private static logEntriesLogEntry[] GetLogEntries(TestSession testSession)
        {
            var xmlLogEntries = new List<logEntriesLogEntry>();
            foreach (LogEntry logEntry in testSession.GetLogEntries())
            {
                var xmlLogEntry = new logEntriesLogEntry();
                xmlLogEntry.timestamp = logEntry.Timestamp;
                xmlLogEntry.message = logEntry.Message;
                xmlLogEntries.Add(xmlLogEntry);
            }
            return xmlLogEntries.Count == 0 ? null : xmlLogEntries.ToArray();
        }

        private static string CreateXml(testSessionLog log)
        {
            StringWriter sw = new StringWriter();
            XmlSerializer xml = new XmlSerializer(typeof(testSessionLog));
            xml.Serialize(sw, log);
            return sw.ToString();
        }

    }
}
