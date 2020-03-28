using System.Linq;
using Xunit;

namespace Kata.Solutions.Kyu6
{
    /// <summary>
    /// https://www.codewars.com/kata/515de9ae9dcfc28eb6000001
    /// </summary>
    public class ArrayDiff
    {
        [Fact]
        public void SampleTest()
        {
            Assert.Equal(new[] {2}, Kata.ArrayDiff(new[] {1, 2}, new[] {1}));
            Assert.Equal(new[] {2, 2}, Kata.ArrayDiff(new[] {1, 2, 2}, new[] {1}));
            Assert.Equal(new[] {1}, Kata.ArrayDiff(new[] {1, 2, 2}, new[] {2}));
            Assert.Equal(new[] {1, 2, 2}, Kata.ArrayDiff(new[] {1, 2, 2}, new int[] { }));
            Assert.Equal(new int[] { }, Kata.ArrayDiff(new int[] { }, new[] {1, 2}));
        }
    }

    public class Kata
    {
        public static int[] ArrayDiff(int[] a, int[] b) => a.Where(i => !b.Contains(i)).ToArray();
    }
}