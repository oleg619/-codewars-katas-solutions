using System.Linq;
using Xunit;

namespace Kata.Solutions.Kyu4
{
    /// <summary>
    /// https://www.codewars.com/kata/55983863da40caa2c900004e
    /// </summary>
    public class NextBiggerNumberWithTheSameDigits
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(21, NextBiggerNumber(12));
            Assert.Equal(531, NextBiggerNumber(513));
            Assert.Equal(2071, NextBiggerNumber(2017));
            Assert.Equal(441, NextBiggerNumber(414));
            Assert.Equal(414, NextBiggerNumber(144));
            Assert.Equal(59884848483559, NextBiggerNumber(59884848459853));
        }

        public static long NextBiggerNumber(long n)
        {
            var digits = n.ToString().Select(ToDigit).ToArray();

            var pivotIndex = GetPivotIndex(digits);

            if (pivotIndex == -1)
            {
                return -1;
            }

            var pivot = digits[pivotIndex];

            var substitutionIndex = GetSubstitutionIndex(pivotIndex, digits, pivot);

            (digits[pivotIndex], digits[substitutionIndex]) = (digits[substitutionIndex], digits[pivotIndex]);
            
            var leftArray = digits.Take(pivotIndex + 1).ToList();
            var rightArray = digits.Skip(pivotIndex + 1).OrderBy(i => i).ToList();
            digits = leftArray.Concat(rightArray).ToArray();

            var result = long.Parse(string.Concat(digits.Select(i => i.ToString())));

            return result;
        }

        private static int GetSubstitutionIndex(int pivotIndex, int[] digits, int pivot)
        {
            int? smallestDigit = null;
            int index = -1;
            for (var i = pivotIndex + 1; i < digits.Length; i++)
            {
                var currentDigit = digits[i];
                if (currentDigit > pivot)
                {
                    if (!smallestDigit.HasValue || currentDigit < smallestDigit)
                    {
                        smallestDigit = currentDigit;
                        index = i;
                    }
                }
            }

            return index;
        }

        private static int GetPivotIndex(int[] digits)
        {
            int pivotIndex = -1;

            for (var i = digits.Length - 1; i > 0; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    pivotIndex = i - 1;
                    break;
                }
            }

            return pivotIndex;
        }

        private static int ToDigit(char c)
        {
            return c - '0';
        }
    }
}