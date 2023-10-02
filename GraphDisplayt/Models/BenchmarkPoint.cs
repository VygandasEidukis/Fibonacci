using System;

namespace GraphDisplayt.Models
{
    public class BenchmarkPoint
    {
        public int Itteration { get; set; }
        public TimeSpan Duration { get; set; }
        public ulong Result { get; set; }
        public CalculationType Type { get; set; }
    }
}
