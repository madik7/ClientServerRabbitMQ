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



        public string Calculate(int precision, CancellationToken cancellationToken)
        {
            var k = BigInteger.One;
            var l = new BigInteger(3);
            var n = new BigInteger(3);
            var q = BigInteger.One;
            var r = BigInteger.Zero;
            var t = BigInteger.One;

            var resultBuilder = new StringBuilder();

            BigInteger nn, nr;
            bool first = true;
            while (!cancellationToken.IsCancellationRequested)
            {
                if ((FOUR * q + r - t).CompareTo(n * t) == -1)
                {
                    resultBuilder.Append(n);
                    if (--precision == 0)
                        break;
                    if (first)
                    {
                        resultBuilder.Append(".");
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

            return resultBuilder.ToString();
        }
    }
}
