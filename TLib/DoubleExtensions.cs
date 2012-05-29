using System;
using System.Collections.Generic;
using System.Text;

namespace TLib
{
    public static class DoubleExtensions
    {
        // Adapted from Bruce Dawson's "Comparing Floating Point Numbers"
        public static bool AlmostEqual2sComplement(this double A, double B, long maxUlps)
        {
            // Make sure maxUlps is non-negative and small enough that the
            // default NAN won't compare as equal to anything.
            System.Diagnostics.Debug.Assert(maxUlps > 0 && maxUlps < 2L * 1024 * 1024 * 1024 * 1024 * 1024); // 2 ^ 51 = Double.NaN - Double.MinValue - 1

            double negZero = 0;
            negZero = -negZero;
            long negZeroLong = BitConverter.DoubleToInt64Bits(negZero);

            long aLong = BitConverter.DoubleToInt64Bits(A);
            // Make aLong lexicographically ordered as a twos-complement long.
            if (aLong < 0)
            {
                aLong = negZeroLong - aLong;
            }

            // Make bLong lexicographically ordered as a twos-complement long.
            long bLong = BitConverter.DoubleToInt64Bits(B);
            if (bLong < 0)
            {
                bLong = negZeroLong - bLong;
            }

            long longDiff = Math.Abs(aLong - bLong);
            if (longDiff <= maxUlps)
            {
                return true;
            }
            return false;
        }
    }
}
