using System.Linq;
using Arkivverket.Arkade.Core;
using Arkivverket.Arkade.Tests.Noark5;
using FluentAssertions;
using Xunit;

namespace Arkivverket.Arkade.Test.Tests.Noark5
{
    public class NumberOfArchivePartsTests
    {
        [Fact]
        public void ShouldFindTwoArchiveparts()
        {
            XmlElementHelper helper = new XmlElementHelper()
                .Add("arkiv", new XmlElementHelper()
                    .Add("systemID", "someArchiveSystemId_1")
                    .Add("arkivdel", string.Empty)
                    .Add("arkivdel", string.Empty)
                );

            TestRun testRun = helper.RunEventsOnTest(new NumberOfArchiveParts());

            testRun.Results.First().Message.Should().Be("Antall arkivdeler: 2");
        }

        [Fact]
        public void ShouldFindThreeArchivepartsInTwoArchives()
        {
            XmlElementHelper helper = new XmlElementHelper()
                .Add("arkiv", new XmlElementHelper()
                    .Add("systemID", "someArchiveSystemId_1")
                    .Add("arkivdel", string.Empty)
                    .Add("arkivdel", string.Empty))
                .Add("arkiv", new XmlElementHelper()
                    .Add("systemID", "someArchiveSystemId_2")
                    .Add("arkivdel", string.Empty));

            TestRun testRun = helper.RunEventsOnTest(new NumberOfArchiveParts());

            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Antall arkivdeler: 3"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Antall arkivdeler i arkiv (systemID) someArchiveSystemId_1: 2"));
            testRun.Results.Should().Contain(r =>
                r.Message.Equals("Antall arkivdeler i arkiv (systemID) someArchiveSystemId_2: 1"));
        }
    }
}
