using System.Linq;
using FluentAssertions;
using Xunit;

namespace Kata.Solutions.Kyu6
{
    /// <summary>
    /// https://www.codewars.com/kata/515de9ae9dcfc28eb6000001
    /// </summary>
    public class SplitString
    {
        [Fact]
        public void BasicTests()
        {
            Solution("abc").Should().BeEquivalentTo("ab", "c_");
            Solution("abcdef").Should().BeEquivalentTo("ab", "cd", "ef");
        }

        public static string[] Solution(string str)
        {
            var letterLength = 2;
            str = str.Length % 2 == 0 ? str : str + "_";

            return Enumerable.Range(0, str.Length / letterLength)
                .Select(index => str.Substring(letterLength * index, letterLength))
                .ToArray();
        }
    }
}