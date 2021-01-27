using NUnit.Framework;

namespace FizzBuzzTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GivenNumberBelowOne_ReturnEmptyString()
        {
            var result = FizzBuzz.FizzBuzz.Generate(-1);

            Assert.That(result, Is.Empty);
        }

        [TestCase(1, "1,")]
        [TestCase(2, "1,2,")]
        public void GivenNumberUpTo2_ReturnNumbersCommaDelimited(int input, string expected)
        {
            var actual = FizzBuzz.FizzBuzz.Generate(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(3, "1,2,Fizz,")]
        [TestCase(6, "1,2,Fizz,4,Buzz,Fizz,")]
        [TestCase(9, "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,")]
        public void GivenNumberDividedBy_ReturnFizzInstead(int input, string expected)
        {
            var actual = FizzBuzz.FizzBuzz.Generate(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(5, "1,2,Fizz,4,Buzz,")]
        [TestCase(10, "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,")]
        public void GivenNumberDividedBy5_ReturnBuzzInstead(int input, string expected)
        {
            var actual = FizzBuzz.FizzBuzz.Generate(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenNumberDividedBy3And5_ReturnFizzBuzzInstead()
        {
            var result = FizzBuzz.FizzBuzz.Generate(15);

            Assert.That(result, Is.EqualTo("1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz,"));
        }
    }

}
