using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot14Assignment.exception
{
    public class InvalidScoreException : Exception
    {
        public double InvalidScore { get; set; }
        public InvalidScoreException() : base() { }
        public InvalidScoreException(string message) : base(message) { }
        public InvalidScoreException(string message, Exception innerException) : base(message, innerException) { }
        public InvalidScoreException(string message, double score) : base(message)
        {
            InvalidScore = score;
        }

        public override string ToString()
        {
            return base.ToString() + "\nScore is invalid: " + InvalidScore;
        }
    }
}
