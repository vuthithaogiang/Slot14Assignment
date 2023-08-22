using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Slot14Assignment.exception;

namespace Slot14Assignment.classes
{
    public class Filter : IFilter
    {
        public bool IsScoreValid(double score)
        {
           if(score < 0 || score > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
