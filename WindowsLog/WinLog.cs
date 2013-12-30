using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLog
{

    interface ILog
    {
         List<string> GetLogMessages();
    }

    class WinLog:ILog
    {
        private EventLog _EventLog;

        public WinLog(String logName)
        {
            try
            {
                _EventLog = new EventLog(logName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public WinLog(String logName, String remoteMachine)
        {
            try
            {
                _EventLog = new EventLog(logName, remoteMachine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
       

        public IEnumerable<EventLogEntry> GetLogMessages()
        {
            List<EventLogEntry> log = new List<EventLogEntry>();
            foreach (System.Diagnostics.EventLogEntry entry in _EventLog.Entries)
            {            
                log.Add(entry);
                
            }
            return log;
        }
    }
}
