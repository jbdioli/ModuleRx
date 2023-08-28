using Newtonsoft.Json;

namespace ModuleRx.Models_Dto
{
    public class BlogDto
    {

        [JsonProperty("postId")]
        public int PostId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("body")]
        public string body { get; set; }
    }
}