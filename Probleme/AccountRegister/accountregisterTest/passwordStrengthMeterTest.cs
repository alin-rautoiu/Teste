using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountRegister_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accountregisterTest
{
    [TestClass]
    public class PasswordStrengthMeterTest
    {
        [TestMethod]
        public void GivenAnEmptyPasswordWhenPSMIsCalledThenResultIs0()
        { 
            //arrange
            String password = "";
            int expectedResult = 0;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAnPasswordWith8LowerCaseLettersWhenPSMIsCalledThenResultIs2() 
        { 
            //arange 
            String password = "abcdefgh";
            int expectedResult = 2;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAnPasswordWithLessThan8LowerCaseLettersWhenPSMIsCalledThenResultIs1()
        {
            //arange 
            String password = "abcd";
            int expectedResult = 1;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAnPasswordWithMoreThan7LettersWithLowerAndUpperCaseandNumberWhenPSMIsCalledThenResultIs4()
        {
            //arange 
            String password = "aBcD1234";
            int expectedResult = 4;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAnPasswordWith7LettersWithLowerAndUpperCaseandASpecialCharWhenPSMIsCalledThenResultIs3()
        {
            //arange 
            String password = "aBcDeF%";
            int expectedResult = 3;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenANullPasswordWhenPSMIsCalledThenResultIs0()
        {
            //arange 
            String password = null;
            int expectedResult = 0;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAPasswordWithASingelSpecialCharWhenPSMIsCalledThenResultIs1()
        {
            //arange 
            String password = "?";
            int expectedResult = 1;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAPasswordOfLenght8WithSpecialCharactersLowerCaseUpperCaseLettersAndNumberWhenPSMIsCalledThenResultIs5()
        {
            //arrange
            String password = "AbCd123$";
            int expectedResult = 5;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAPasswordOfLenght8WithOnlyNumbersWhenPSMIsCalledThenResultIs2()
        {
            //arrange
            String password = "12345678";
            int expectedResult = 2;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAPasswordOfLenght7WithOnlyNumbersWhenPSMIsCalledThenResultIs1()
        {
            //arrange
            String password = "1234567";
            int expectedResult = 1;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAPasswordOfLenght8WithOnlySpecialCharactersWhenPSMIsCalledThenResultIs2()
        {
            //arrange
            String password = "!@#$%^&*";
            int expectedResult = 2;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAPasswordOfLenght7WithOnlySpecialCharactersWhenPSMIsCalledThenResultIs1()
        {
            //arrange
            String password = "!@#$%^&";
            int expectedResult = 1;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
