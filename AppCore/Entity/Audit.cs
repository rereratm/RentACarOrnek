using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entity
{
    public abstract class Audit
    {
        public DateTime CDate { get; set; } = DateTime.Now;
        public DateTime ?MDate { get; set; }
    }
}
