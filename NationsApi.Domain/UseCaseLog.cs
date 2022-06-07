using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.Domain
{
    public class UseCaseLog
    {
        public int Id { get; set; }
        public string Actor { get; set; }
        public  string UseCaseName { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }

    }
}
