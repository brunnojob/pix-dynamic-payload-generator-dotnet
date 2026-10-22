using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Extentions;
using System;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Calendario : CalendarioBase
    {
        [JsonProperty("criacao")]
        public DateTime Criacao { get; set; }

        [JsonIgnore]
        public string CriacaoDisplay => Criacao.ToDisplay();
    }

    public class CalendarioBase
    {

        [JsonProperty("expiracao")]
        public int Expiracao { get; set; }
    }
}
