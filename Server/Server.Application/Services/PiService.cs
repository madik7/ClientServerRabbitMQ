using Rationals;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Server.Application.Services
{
    public class PiService : IPiService
    {
        private readonly BigInteger FOUR = new BigInteger(4);
        private readonly BigInteger SEVEN = new BigInteger(7);
        private readonly BigInteger TEN = new BigInteger(10);
        private readonly BigInteger THREE = new BigInteger(3);
        private readonly BigInteger TWO = new BigInteger(2);

        private BigInteger k = BigInteger.One;
        private BigInteger l = new BigInteger(3);
        private BigInteger n = new BigInteger(3);
        private BigInteger q = BigInteger.One;
        private BigInteger r = BigInteger.Zero;
        private BigInteger t = BigInteger.One;

        public Rational Calculate(int precision, CancellationToken cancellationToken)
        {
            /*
            //Chudnovsky algorithm
            var K = new Rational(6);
            var M = new Rational(1);
            var L = new Rational(13591409);
            var X = new Rational(1);
            var S = new Rational(13591409);

            for (var k = 1; k <= precision; k++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                M = M * (Rational.Pow(K, 3) - (16 * K)) / Rational.Pow(k, 3);
                L += 545140134;
                X *= -262537412640768000;
                S += M * L / X;
                K += 12;
            }
            */



            BigInteger nn, nr;
            bool first = true;
            while (true)
            {
                if ((FOUR * q + r - t).CompareTo(n * t) == -1)
                {
                    Console.Write(n);
                    if (first)
                    {
                        Console.Write(".");
                        first = false;
                    }
                    nr = TEN * (r - (n * t));
                    n = TEN * (THREE * q + r) / t - (TEN * n);
                    q *= TEN;
                    r = nr;
                }
                else
                {
                    nr = (TWO * q + r) * l;
                    nn = (q * (SEVEN * k) + TWO + r * l) / (t * l);
                    q *= k;
                    t *= l;
                    l += TWO;
                    k += BigInteger.One;
                    n = nn;
                    r = nr;
                }
            }

            return new Rational(426880) * Rational.RationalRoot(new Rational(10005),2) / S;
        }
    }
}
