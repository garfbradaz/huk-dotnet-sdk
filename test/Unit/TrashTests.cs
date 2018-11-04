using System;
using Hachette.API.SDK.Common;
using Hachette.API.SDK.Utilities;
using Xunit;

namespace Unit.Utilities
{
    public class TrashTests
    {
        [Fact]
        public void Should_Throw_Null_On_String()
        {
            //arrange
            string n = null;

            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => Trashcan.IsNull(nameof(n),n));
        }

        [Fact]
        public void Should_Not_Throw_Null_On_String()
        {
            //arrange
            string n = "hello";

            //act
            var act = Record.Exception(() => Trashcan.IsNull(nameof(n),n));

            //assert 
            Assert.Null(act);
        }

        [Fact]
        public void Should_Throw_InvalidOperation_As_All_2_Are_Null()
        {
            //arrange
            string a = null;
            string b = null;

            //act
            //assert
            Assert.Throws<InvalidOperationException>(() => Trashcan.AllAreNull("All null",a,b));
        }
        [Fact]
        public void Should_Throw_InvalidOperation_As_All_3_Are_Null()
        {
            //arrange
            string a = null;
            string b = null;
            string c = null;

            //act
            //assert
            Assert.Throws<InvalidOperationException>(() => Trashcan.AllAreNull("All null",a,b,c));
        }

        [Fact]
         public void Should_Not_Throw_InvalidOperation_As_1_Is_Not_Null()
        {
            //arrange
            string a = "null";
            string b = null;
            string c = null;

            //act
            var act = Record.Exception(() => Trashcan.AllAreNull("All null",a,b,c));
            //assert
            Assert.Null(act);
        }        
        
        [Fact]
         public void Should_Not_Throw_InvalidOperation_As_2_Is_Not_Null()
        {
            //arrange
            string a = "null";
            string b = "null";
            string c = null;

            //act
            var act = Record.Exception(() => Trashcan.AllAreNull("All null",a,b,c));
            //assert
            Assert.Null(act);
        }

        [Fact]
         public void Should_Not_Throw_InvalidOperation_As_None_Are_Null()
        {
            //arrange
            string a = "null";
            string b = "null";
            string c = "null";

            //act
            var act = Record.Exception(() => Trashcan.AllAreNull("All null",a,b,c));
            //assert
            Assert.Null(act);
        }

        [Fact]
        public void Should_Throw_Null_On_CommonParameters()
        {
            //arrange 
            CommonParameters  p = null;

            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => Trashcan.IsNull(nameof(p),p));
        }


    }
}