using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Model
{
    public class DataResponse<T> : Response
    {
        public T Data { get; set; }
    }
}
