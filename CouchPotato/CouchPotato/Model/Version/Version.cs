using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Model
{
    public class Version
    {
        public string OS { get; set; }

        public string Type { get; set; }

        public string Commit { get; set; }

        public string Release { get; set; }

        public override string ToString()
        {
            return Commit;
        }
    }
}
