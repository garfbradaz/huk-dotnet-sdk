using Hachette.API.SDK.Validation;
using Xunit;

namespace Unit.SDK
{
    public class ValidationUnitTests
    {
        [Fact]
        public void Should_Validate_WandN_1()
        {
            //arrange
            var validate = Imprints.Create();
            string imprint = "W&N";

            //act
            var validated = Imprints.OneOf(imprint);

            //assert
            Assert.True(validated,$"Assert failed for {imprint} ");
        }
        [Fact]
        public void Should_Validate_WandN_2()
        {
            //arrange
            var validate = Imprints.Create();
            string imprint = "wandn";

            //act
            var validated = Imprints.OneOf(imprint);

            //assert
            Assert.True(validated,$"Assert failed for {imprint} ");
        }
        [Fact]
        public void Should_Validate_Gollancz()
        {
             //arrange
            var validate = Imprints.Create();
            string imprint = "Gollancz";

            //act
            var validated = Imprints.OneOf(imprint);

            //assert
            Assert.True(validated,$"Assert failed for {imprint} ");           
        }
        [Fact]
        public void Should_Validate_Gateway()
        {
            //arrange
            string imprint = "gateway";

            //act
            var validated = Imprints.OneOf(imprint);

            //assert
            Assert.True(validated,$"Assert failed for {imprint} ");
        }
        [Fact]
        public void Should_Validate_Orion()
        {
            //arrange
            string division = "orion publishing group";

            //act
            var validated = Divisions.OneOf(division);

            //assert
            Assert.True(validated,$"Assert failed for {division} ");
        }
        [Fact]
        public void Validation_Should_Fail_For_Imprint()
        {
            //arrange
            string imprint = "waandn";
            //act
            var validated = Imprints.OneOf(imprint);
            //assert
            Assert.False(validated,$"Assert failed, validation should of failed or {imprint}");

        }
        [Fact]
        public void Validation_Should_Fail_For_Division()
        {
            //arrange
            string division = "orion";
            //act
            var validated = Imprints.OneOf(division);
            //assert
            Assert.False(validated,$"Assert failed, validation should of failed or {division}");
        }
        [Fact]
        public void Enum_Should_Equal_WandN_Value()
        {
            //arrange
            var imprints = Imprints.Create();
            string expected = "wandn,w&n";

            //act
            //assert
            Assert.True(imprints.WAndN == expected, 
            $"Assert failed, expected {expected} and found {imprints.WAndN} ");
        }
        [Fact]
        public void Enum_Should_Equal_Gollancz_Value()
        {
            //arrange
            var imprints = Imprints.Create();
            string expected = "gollancz";

            //act
            //assert
            Assert.True(imprints.Gollancz == expected, 
            $"Assert failed, expected {expected} and found {imprints.Gollancz} ");
        }
        [Fact]
        public void Enum_Should_Equal_Gateway_Value()
        {
            //arrange
            var imprints = Imprints.Create();
            string expected = "gateway";

            //act
            //assert
            Assert.True(imprints.SciFiGateway == expected, 
            $"Assert failed, expected {expected} and found {imprints.SciFiGateway} ");
        }
        [Fact]
        public void Enum_Should_Equal_Orion_Value()
        {
            //arrange
            var divisions = Divisions.Create();
            string expected = "Orion Publishing Group";

            //act
            //assert
            Assert.True(divisions.Orion == expected, 
            $"Assert failed, expected {expected} and found {divisions.Orion} ");
        }
   

    }
}