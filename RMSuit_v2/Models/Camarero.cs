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
        public string Nombre { get; set; }

    }

    public class UpdateWaiterRequest
    {
        public string Nombre { get; set; }
    }

}
