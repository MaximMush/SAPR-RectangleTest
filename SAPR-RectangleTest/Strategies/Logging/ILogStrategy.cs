using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_RectangleTest.Strategies.Logging
{
    public interface ILogStrategy
    {
        void Log();
    }
    public abstract class LogStrategy : ILogStrategy
    {
        public abstract string LogMessage { get; set; }
        public abstract void Log();
    }
}
