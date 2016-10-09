using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoREST
{
    public class MusicInstrument
    {
        public string ID { get; set; }
        
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        
        public string Version { get; set; }

        public int ItemID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string EmbedURL { get; set; }
        
        public string URL { get; set; }

        public string ImageAPI { get; set; }
        
        public bool Deleted { get; set; }
    }
}
