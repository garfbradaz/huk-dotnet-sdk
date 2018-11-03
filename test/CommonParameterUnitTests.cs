using System.Linq;
using Hachette.API.SDK.Common;
using Xunit;

namespace Tests.SDK
{
    public class CommonParameterUnitTests
    {
        [Fact]
        public void Imprint_Should_Be_Added()
        {
            //arrange
            var parameters = new CommonParameters();
            string imprint = "Gollancz";
            //act
            (bool added, ValidationAddStatus status) = parameters.AddImprint(imprint);
            //assert
            Assert.True(parameters.FilterByImprints.Contains(imprint),$"Assert, {imprint} is not found");
            Assert.True(added,$"Assert failed {added}");
            Assert.True(status == ValidationAddStatus.Success, $"Assert failed, returned {status}");
        }

        [Fact]
        public void Imprint_Should_Not_Be_Added_Because_It_Is_A_Duplicate()
        {
            //arrange
            var parameters = new CommonParameters();
            string imprint = "Gollancz";
            //act
            parameters.AddImprint(imprint);
            parameters.AddImprint(imprint);
            //assert
            Assert.True(parameters.FilterByImprints.Where(i => i == imprint).Count() == 1,$"Assert, more than one division, shouldnt have duplicates");
        }

        [Fact]
        public void Division_Should_Be_Added()
        {
            //arrange
            var parameters = new CommonParameters();
            string division = "Orion Publishing Group";
            //act
            (bool added, ValidationAddStatus status) = parameters.AddDivision(division);
            //assert
            Assert.True(added,$"Assert failed and division {division} not added");
            Assert.True(status == ValidationAddStatus.Success,$"Assert failed, {status} returned instead");
            Assert.True(parameters.FilterByDivisions.Contains(division),$"Assert, {division} is not found");
        }
 
        [Fact]
        public void Division_Should_Not_Be_Added_Because_It_Is_A_Duplicate()
        {
            //arrange
            var parameters = new CommonParameters();
            string division = "Orion Publishing Group";
            //act
            parameters.AddDivision(division);
            (bool added, ValidationAddStatus status) = parameters.AddDivision(division);
            //assert
            Assert.True(parameters.FilterByDivisions.Where(i => i == division).Count() == 1,$"Assert, more than one division, shouldnt have duplicates");
            Assert.True(status == ValidationAddStatus.FailedDuplicateValue,$"Assert failed, should have {ValidationAddStatus.FailedDuplicateValue}, received {status}");
        }    

        [Fact] 
        public void Should_Remove_Division()
        {
            //arrange
            var parameters = new CommonParameters();
            string division  = "Orion";

            //act
            parameters.AddDivision(division);
            parameters.RemoveDivision(division);

            //assert
            Assert.True(parameters.FilterByDivisions.Where(i => i == division).Count() == 0,$"Assert, shouldnt have any divisions");
        }

        [Fact]
        public void Should_Remove_Imprint()
        {
            //arrange
            var parameters = new CommonParameters();
            string  imprint = "w&n";

            //act
            parameters.AddImprint(imprint);
            parameters.RemoveImprint(imprint);

            //assert
             Assert.True(parameters.FilterByImprints.Where(i => i == imprint).Count() == 0,$"Assert, shouldnt have any imprints");
        }
   
        [Fact]
        public void Should_Fail_On_Empty_Division()
        {
            //arrange
            string division = string.Empty;
            var parameters = new CommonParameters();

            //act
            (bool added, ValidationAddStatus status) = parameters.AddDivision(division);

            //assert
            Assert.True(!added,"Assert failed, shouldnt add a empty value");
            Assert.True(status == ValidationAddStatus.FailedEmptyValue,$"Assert failed, received {status}");
        }
        [Fact]
        public void Should_Fail_On_Empty_Imprint()
        {
            //arrange
            string imprint = string.Empty;
            var parameters = new CommonParameters();

            //act
            (bool added, ValidationAddStatus status) = parameters.AddImprint(imprint);

            //assert
            Assert.True(!added,"Assert failed, shouldnt add a empty value");
            Assert.True(status == ValidationAddStatus.FailedEmptyValue,$"Assert failed, received {status}");
        }
    }
}