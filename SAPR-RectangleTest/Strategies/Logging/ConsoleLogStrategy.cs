using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_RectangleTest.Strategies.Logging
{
    public class ConsoleLogStrategy : LogStrategy
    {
        protected string logMessage = string.Empty;
        public override string LogMessage
        {
            get { return logMessage; }
            set { logMessage = value; }
        }

        public override void Log()
        {
            Console.WriteLine(logMessage);
        }
    }
}
