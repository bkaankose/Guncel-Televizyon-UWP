using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public int StreamInformationId { get; set; }
        public string Name { get; set; }
        public string StreamUrl { get; set; }
        public bool IsPrivate { get; set; }
        
    }
}
