using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuncelTelevizyonUWP.Models
{
    public class Channel
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string URL { get; set; }
        [JsonProperty(PropertyName = "category")]
        public ChannelCategory Category { get; set; }
        [JsonProperty(PropertyName = "streaminformationsuffix")]
        public string StreamInformationSuffix { get; set; }
        [JsonProperty(PropertyName = "isspecial")]
        public bool IsSpecial { get; set; }
        [JsonProperty(PropertyName = "isactive")]
        public bool IsActive { get; set; }

    }
}
