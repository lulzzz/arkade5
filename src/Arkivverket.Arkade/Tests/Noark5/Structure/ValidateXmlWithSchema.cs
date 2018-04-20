using System;
using System.Collections.Generic;
using System.IO;
using Arkivverket.Arkade.Core;
using Arkivverket.Arkade.Core.Noark5;
using Arkivverket.Arkade.Resources;
using Arkivverket.Arkade.Util;

namespace Arkivverket.Arkade.Tests.Noark5.Structure
{
    public class ValidateXmlWithSchema : Noark5StructureBaseTest
    {
        private readonly TestId _id = new TestId(TestId.TestKind.Noark5, 3);

        private readonly List<TestResult> _testResults = new List<TestResult>();

        public override void Test(Archive archive)
        {
            ValidateXml(archive.AddmlFile,
                GetStructureDescriptionXmlSchemaStream(archive));

            ValidateXml(archive.ArchiveStructureFile,
                GetContentDescriptionXmlSchemaStream(archive),
                GetMetadataCatalogXmlSchemaStream(archive));

            if (Noark5TestHelper.FileIsDescribed(ArkadeConstants.PublicJournalXmlFileName, archive))
                ValidateXml(archive.PublicJournalFile,
                    GetPublicJournalXmlSchemaStream(archive),
                    GetMetadataCatalogXmlSchemaStream(archive));

            if (Noark5TestHelper.FileIsDescribed(ArkadeConstants.RunningJournalXmlFileName, archive))
                ValidateXml(archive.RunningJournalFile,
                    GetRunningJournalXmlSchemaStream(archive),
                    GetMetadataCatalogXmlSchemaStream(archive));
        }

        private void ValidateXml(ArkadeFile xmlFile, params Stream[] xsdResources)
        {
            string fileName = xmlFile.Name;

            // Use the Noark 5 archive filename for testresults:
            if (fileName.Equals(ArkadeConstants.AddmlXmlFileName)) 
                fileName = ArkadeConstants.ArkivuttrekkXmlFileName;

            try
            {
                foreach (string validationErrorMessage in new XmlValidator().Validate(xmlFile.AsStream(), xsdResources))
                    _testResults.Add(new TestResult(ResultType.Error, new Location(fileName), validationErrorMessage));
            }
            catch (Exception e)
            {
                string message = string.Format(Noark5Messages.ExceptionDuringXmlValidation, fileName, e.Message);
                throw new ArkadeException(message, e);
            }
        }

        private Stream GetStructureDescriptionXmlSchemaStream(Archive archive)
        {
            if (archive.AddmlSchemaFile.Exists)
                return archive.AddmlSchemaFile.AsStream();

            // Fallback on internal addml.xsd:

            _testResults.Add(new TestResult(ResultType.Error, new Location(string.Empty),
                // TODO: Consider ResultType.Warning (if it becomes supported)
                string.Format(Noark5Messages.InternalSchemaFileIsUsed, ArkadeConstants.AddmlXsdFileName)));

            return ResourceUtil.GetResourceAsStream(ArkadeConstants.AddmlXsdResource);
        }

        private Stream GetContentDescriptionXmlSchemaStream(Archive archive)
        {
            if (archive.ArchiveStructureSchemaFile.Exists)
                return archive.ArchiveStructureSchemaFile.AsStream();

            // Fallback on internal arkivstruktur.xsd:

            _testResults.Add(new TestResult(ResultType.Error, new Location(string.Empty),
                // TODO: Consider ResultType.Warning (if it becomes supported)
                string.Format(Noark5Messages.InternalSchemaFileIsUsed, ArkadeConstants.ArkivstrukturXsdFileName)));

            return ResourceUtil.GetResourceAsStream(ArkadeConstants.ArkivstrukturXsdResource);
        }

        private Stream GetMetadataCatalogXmlSchemaStream(Archive archive)
        {
            if (archive.MetadataCatalogSchemaFile.Exists)
                return archive.MetadataCatalogSchemaFile.AsStream();

            // Fallback on internal metadatakatalog.xsd:

            _testResults.Add(new TestResult(ResultType.Error, new Location(string.Empty),
                // TODO: Consider ResultType.Warning (if it becomes supported)
                string.Format(Noark5Messages.InternalSchemaFileIsUsed, ArkadeConstants.MetadatakatalogXsdFileName)));

            return ResourceUtil.GetResourceAsStream(ArkadeConstants.MetadatakatalogXsdResource);
        }

        private Stream GetPublicJournalXmlSchemaStream(Archive archive)
        {
            if (archive.PublicJournalSchemaFile.Exists)
                return archive.PublicJournalSchemaFile.AsStream();

            // Fallback on internal schema for public journal:

            _testResults.Add(new TestResult(ResultType.Error, new Location(string.Empty),
                // TODO: Consider ResultType.Warning (if it becomes supported)
                string.Format(Noark5Messages.InternalSchemaFileIsUsed, ArkadeConstants.PublicJournalXsdFileName)));

            return ResourceUtil.GetResourceAsStream(ArkadeConstants.PublicJournalXsdResource);
        }

        private Stream GetRunningJournalXmlSchemaStream(Archive archive)
        {
            if (archive.RunningJournalSchemaFile.Exists)
                return archive.RunningJournalSchemaFile.AsStream();

            // Fallback on internal schema for running journal:

            _testResults.Add(new TestResult(ResultType.Error, new Location(string.Empty),
                // TODO: Consider ResultType.Warning (if it becomes supported)
                string.Format(Noark5Messages.InternalSchemaFileIsUsed, ArkadeConstants.RunningJournalXsdFileName)));

            return ResourceUtil.GetResourceAsStream(ArkadeConstants.RunningJournalXsdResource);
        }

        public override TestId GetId()
        {
            return _id;
        }

        public override string GetName()
        {
            return Noark5TestNames.ValidateXmlWithSchema;
        }

        public override TestType GetTestType()
        {
            return TestType.StructureControl;
        }

        protected override List<TestResult> GetTestResults()
        {
            return _testResults;
        }
    }
}