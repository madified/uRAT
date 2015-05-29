using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uRAT.Server.Builder
{
    internal enum InstallationPath
    {
        Default,
        AppData,
        ProgramFiles
    }

    internal struct BuildSettings
    {
        public string Hostname;
        public int Port;
        public string Filename;
        public InstallationPath InstallationPath;

        public BuildSettings(string hostname, int port, string filename, InstallationPath installationPath)
        {
            Hostname = hostname;
            Port = port;
            Filename = filename;
            InstallationPath = installationPath;
        }
    }
}
