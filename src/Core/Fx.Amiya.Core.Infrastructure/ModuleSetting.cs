using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Core.Infrastructure
{
   public class ModuleSetting
    {
        public ModuleSetting()
        {
            //ReadDbConnectionString = new string[0];
        }
        public string Name { get; set; }
        public string DbConnectionString { get; set; }
        public string[] ReadDbConnectionStrings { get; set; }
        public FxDBType DBType { get; set; }
    }
}
