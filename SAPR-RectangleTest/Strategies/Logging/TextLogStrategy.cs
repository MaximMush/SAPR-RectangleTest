using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_RectangleTest.Strategies.Logging
{
    public class TextLogStrategy : LogStrategy
    {
        public TextLogStrategy(string _filePath)
        {
            filePath = _filePath;
        }
        protected string logMessage = string.Empty;
        public override string LogMessage
        {
            get { return logMessage; }
            set { logMessage = value; }
        }

        protected string filePath = string.Empty;

        public override void Log()
        {
            Console.WriteLine(logMessage);
        }
    }
}
