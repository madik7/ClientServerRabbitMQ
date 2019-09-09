using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Server.Domain
{
    public class Job
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Precision { get; set; }
        public string Result { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();
        public bool InProgress; 
    }
}
