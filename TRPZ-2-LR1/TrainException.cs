using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ_2_LR1
{
    public class TrainException : Exception
    {
        public TrainException() :base()
        {
            
        }

        public TrainException(string message):base(message)
        {
            
        }
    }
}
