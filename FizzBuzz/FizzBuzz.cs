using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public static string Generate(int max)
        {
            var result = string.Empty;

            if (max > 0)
            {
                Observable.Range(1, max)
                    .Subscribe(i => result += i + ",");
            }

            return result;
        }
    }

    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GivenNumberBelowOne_ReturnEmptyString()
        {
            var result = FizzBuzz.Generate(0);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Given1_Return1()
        {
            var result = FizzBuzz.Generate(1);

            Assert.That(result, Is.EqualTo("1,"));
        }

        [Test]
        public void Given2_Return12()
        {
            var result = FizzBuzz.Generate(2);

            Assert.That(result, Is.EqualTo("1,2,"));
        }
    }
}
