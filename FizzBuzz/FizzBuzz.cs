using System;
using System.Reactive.Linq;
using NUnit.Framework;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public static string Generate(int max)
        {
            var result = string.Empty;
            if (max <= 0)
            {
                return result;
            }

            var observable = Observable.Range(1, max);

            var dividedByThree = observable
                .Where(i => i % 3 == 0)
                .Select(_ => "Fizz");

            var dividedByFive = observable
                .Where(i => i % 5 == 0)
                .Select(_ => "Buzz");

            var simpleNumbers = observable
               .Where(i => i % 3 != 0 && i % 5 != 0)
               .Select(i => i.ToString());

            var commaDelimiter = observable.Select(_ => ",");

            IObservable<string> specialCases = (dividedByThree).Merge(dividedByFive);
            simpleNumbers
                .Merge(specialCases)
                .Merge(commaDelimiter)
                .Subscribe(s => result += s);

            return result;
        }
    }

    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GivenNumberBelowOne_ReturnEmptyString()
        {
            var result = FizzBuzz.Generate(-1);

            Assert.That(result, Is.Empty);
        }

        [TestCase(1, Result = "1,")]
        [TestCase(2, Result = "1,2,")]
        public string GivenNumberUpTo2_ReturnNumbersCommaDelimited(int input)
        {
            return FizzBuzz.Generate(input);
        }

        [TestCase(3, Result = "1,2,Fizz,")]
        [TestCase(6, Result = "1,2,Fizz,4,Buzz,Fizz,")]
        [TestCase(9, Result = "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,")]
        public string GivenNumberDividedBy_ReturnFizzInstead(int input)
        {
            return FizzBuzz.Generate(input);
        }

        [TestCase(5, Result = "1,2,Fizz,4,Buzz,")]
        [TestCase(10, Result = "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,")]
        public string GivenNumberDividedBy5_ReturnBuzzInstead(int input)
        {
            return FizzBuzz.Generate(input);
        }

        [Test]
        public void GivenNumberDividedBy3And5_ReturnFizzBuzzInstead()
        {
            var result = FizzBuzz.Generate(15);

            Assert.That(result, Is.EqualTo("1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz,"));
        }
    }
}
