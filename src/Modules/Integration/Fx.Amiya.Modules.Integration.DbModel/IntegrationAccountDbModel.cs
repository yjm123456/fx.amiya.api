using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.DbModel
{
    public class IntegrationAccountDbModel
    {
        public string CustomerId { get; set; }
        public decimal Balance { get; set; }
        public int Version { get; set; }
    }
}
