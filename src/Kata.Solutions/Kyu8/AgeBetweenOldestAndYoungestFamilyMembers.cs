using Xunit;

namespace Kata.Solutions.Kuy8
{
    public class AgeBetweenOldestAndYoungestFamilyMembers
    {
        [Fact]
        public void SampleTest()
        {
            Assert.Equal(new int[] {6, 82, 76}, DifferenceInAges(new int[] {82, 15, 6, 38, 35}));
            Assert.Equal(new int[] {14, 99, 85}, DifferenceInAges(new int[] {57, 99, 14, 32}));
        }

        public static int[] DifferenceInAges(int[] ages)
        {
            var minAge = ages[0];
            var maxAge = ages[0];
            for (var i = ages.Length - 1; i >= 0; i--)
            {
                var currentAge = ages[i];
                if (currentAge > maxAge)
                {
                    maxAge = currentAge;
                }

                if (currentAge < minAge)
                {
                    minAge = currentAge;
                }
            }

            return new[] {minAge, maxAge, maxAge - minAge};
        }
    }
}