using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HealthAPILibrary
{
    public class HealthModel
    {
        public string[] NctId { get; set; }

        public string[] BriefTitle { get; set; }

        public string[] Condition { get; set; }

        public string[] BriefSummary { get; set; }
    }
}
