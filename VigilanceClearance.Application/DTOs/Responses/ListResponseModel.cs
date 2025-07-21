using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Application.DTOs.Responses
{
    public class ListResponseModel
    {
        public ListResponseModel() {

            Data = new object();
        }
        public Object Data { get; set; }
        public int Count { get; set; }
    }
}
