using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace uRAT.ManagersClientPlugin.ProcessManager.Tools
{
    public static class ProcessesHelper
    {
        public class HighLevelProcess
        {
            public string ProcessName { get; set; }
            public int Pid { get; set; }
            public bool IsThis { get; set; }
            public long MemUsage { get; set; }

            public HighLevelProcess()
            {
            }

            public HighLevelProcess(string processName, int pid, bool isThis, long memUsage)
            {
                ProcessName = processName;
                Pid = pid;
                IsThis = isThis;
                MemUsage = memUsage;
            }
        }

        public static void KillProcessByPid(int pid)
        {
            try
            {
                Process.GetProcessById(pid).Kill();
            }
            catch
            {
                
            }
        }

        public static List<HighLevelProcess> GetRunningProcesses()
        {
            return GetRunningProcessesImpl().ToList();
        }

        private static IEnumerable<HighLevelProcess> GetRunningProcessesImpl()
        {
            foreach (var proc in Process.GetProcesses())
            {
               
                yield return new HighLevelProcess(
                    proc.ProcessName + ".exe",
                    proc.Id,
                    proc.Id == Process.GetCurrentProcess().Id,
                    proc.WorkingSet64
                    );
            }
        }
    }
}
