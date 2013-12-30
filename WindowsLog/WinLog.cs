using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLog
{

    interface ILog
    {
         IEnumerable<EventLogEntry> GetLogMessages();
         IEnumerable<EventLogEntry> GetAllMessagesFromSource(String sourceName, IEnumerable<EventLogEntry> logs);
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

        public IEnumerable<EventLogEntry> GetAllMessagesFromSource(String sourceName,IEnumerable<EventLogEntry> logs)
        {
            try
            {
                var filterLog = logs.Where(l => l.Source.Equals(sourceName)).ToList();
                return filterLog;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new List<EventLogEntry>();
        }

        public IEnumerable<EventLogEntry> GetLogMessages()
        {
            return _EventLog.Entries.Cast<EventLogEntry>().ToList();
        }
    }
}
