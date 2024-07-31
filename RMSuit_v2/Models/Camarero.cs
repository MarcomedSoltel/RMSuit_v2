using System.Text.Json.Serialization;

namespace RMSuit_v2.Models
{
    public class Camarero
    {
        [JsonPropertyName("camareroId")]
        public int CamareroId { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;
    }


    public class AddWaiterRequest
    {
        public string Nombre { get; set; } = string.Empty;

    }

    public class UpdateWaiterRequest
    {
        public int CamareroId { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

}
