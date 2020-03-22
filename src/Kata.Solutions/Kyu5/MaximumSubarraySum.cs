using System.Linq;
using FluentAssertions;
using Xunit;

namespace Kata.Solutions.Kyu5
{
    /// <summary>
    /// https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c
    /// </summary>
    public class MaximumSubarraySum
    {
        [Fact]
        public void Test0()
        {
            MaxSequence(new int[0]).Should().Be(0);
        }

        [Fact]
        public void Test1()
        {
            MaxSequence(new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}).Should().Be(6);
        }

        public static int MaxSequence(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }

            return Enumerable.Range(0, arr.Length).Select(index =>
            {
                return Enumerable.Range(index, arr.Length - index)
                    .Select((i, x) => arr.Skip(index).Take(x + 1).Sum())
                    .Max();
            }).Max();
        }
    }
}