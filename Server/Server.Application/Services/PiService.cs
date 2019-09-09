using System.Numerics;
using System.Text;
using System.Threading;

namespace Server.Application.Services
{
    public class PiService : IPiService
    {
        private readonly BigInteger _four = new BigInteger(4);
        private readonly BigInteger _seven = new BigInteger(7);
        private readonly BigInteger _ten = new BigInteger(10);
        private readonly BigInteger _three = new BigInteger(3);
        private readonly BigInteger _two = new BigInteger(2);



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
                if ((_four * q + r - t).CompareTo(n * t) == -1)
                {
                    resultBuilder.Append(n);
                    if (--precision == 0)
                        break;
                    if (first)
                    {
                        resultBuilder.Append(".");
                        first = false;
                    }
                    nr = _ten * (r - (n * t));
                    n = _ten * (_three * q + r) / t - (_ten * n);
                    q *= _ten;
                    r = nr;
                }
                else
                {
                    nr = (_two * q + r) * l;
                    nn = (q * (_seven * k) + _two + r * l) / (t * l);
                    q *= k;
                    t *= l;
                    l += _two;
                    k += BigInteger.One;
                    n = nn;
                    r = nr;
                }
            }

            return resultBuilder.ToString();
        }
    }
}
