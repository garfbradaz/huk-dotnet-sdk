using System;
using System.Globalization;
using Hachette.API.SDK.Common;
using Hachette.API.SDK.Extensions;
using Hachette.API.SDK.Interfaces;
using Xunit;

namespace Unit.SDK
{
    public class BuildQueryStringUnitTests
    {
        [Fact]
        public void Should_Build_Id()
        {
            //arrange
            IHachetteCommonParameters parameters = new CommonParameters();
            parameters.Id = "9780297843320";
            string expected = "/9780297843320";

            //act
            var result = parameters.BuildQueryString();

            //assert
            Assert.True(result == expected,
                        $"Assert failed, expected {expected}, received {result}");
        }
        [Fact]
        public void Should_LowerCase_FirstLetter()
        {
            //arrange
            IHachetteCommonParameters parameters = new CommonParameters();
            var name = nameof(parameters.FilterByDivisions);

            //act
            name = Char.ToLowerInvariant(name[0]) + name.Substring(1);

            //assert
            Assert.True(name == "filterByDivisions",$"Assert failed for {name}");

        }
        [Fact]
        public void Should_Flatten_Division_To_QueryString()
        {
            //arrange 
            IHachetteCommonParameters parameters = new CommonParameters();
            string expected = "?filterByDivisions=Orion Publishing Group";

            //act
            parameters.AddDivision("Orion Publishing Group");
            var returned = parameters.BuildQueryString();

            //arrange
            Assert.True(expected == returned,$"Assert failed, received {returned}");
        }
        [Fact]
        public void Should_Flatten_Multiple_Divisions_To_QueryString()
        {
            //arrange 
            IHachetteCommonParameters parameters = new CommonParameters();
            string expected = "?filterByDivisions=Orion Publishing Group&filterByDivisions=Octopus Publishing Group";

            //act
            parameters.AddDivision("Orion Publishing Group");
            var r = parameters.AddDivision("Octopus Publishing Group");
            var returned = parameters.BuildQueryString();

            //arrange
            Assert.True(expected == returned,$"Assert failed, received {returned}");
        }
        [Fact]
        public void Should_Flatten_Imprint_To_QueryString() 
        {
            //arrange 
            IHachetteCommonParameters parameters = new CommonParameters();
            string expected = "?filterByImprints=wandn";

            //act
            parameters.AddImprint("wandn");
            var returned = parameters.BuildQueryString();

            //arrange
            Assert.True(expected == returned,$"Assert failed, received {returned}");
        }
        [Fact]
        public void Should_Flatten_Multiple_Imprints_To_QueryString()
        {
            //arrange 
            IHachetteCommonParameters parameters = new CommonParameters();
            string expected = "?filterByImprints=gollancz&filterByImprints=gateway";

            //act
            parameters.AddImprint("gollancz");
            var r = parameters.AddImprint("gateway");
            var returned = parameters.BuildQueryString();

            //arrange
            Assert.True(expected == returned,$"Assert failed, received {returned}");
        }
        [Fact]
        public void Should_Flatten_Division_And_Imprints_To_QueryString()
        {
            //arrange 
            IHachetteCommonParameters parameters = new CommonParameters();
            string expected = "?filterByDivisions=Orion Publishing Group&filterByImprints=gollancz&filterByImprints=gateway";

            //act
            parameters.AddDivision("Orion Publishing Group");
            parameters.AddImprint("gollancz");
            parameters.AddImprint("gateway");
            var returned = parameters.BuildQueryString();

            //arrange
            Assert.True(expected == returned,$"Assert failed, received {returned}");
        }
        [Fact]
        public void Should_Create_Timestamp_To_QueryString()
        {
            //arrange
            IHachetteCommonParameters parameters = new CommonParameters();
            string expected = "?filterByTimestamp=2018-07-04T09:00:00";

            //act
            var d = Convert.ToDateTime("2018-07-04T09:00:00");

            parameters.FilterByTimestamp = new DateTimeOffset(d,new TimeSpan(0,0,0));
            var returned = parameters.BuildQueryString();

            //arrange
            Assert.True(expected == returned,$"Assert failed, received {returned}");
            // 2018-07-04T09:00:00
        }
    }
}