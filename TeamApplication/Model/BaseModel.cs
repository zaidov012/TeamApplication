using Newtonsoft.Json;

namespace TeamApplication.Model
{
    public class BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("name")]
        public string Password { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("mail")]
        public string Mail { get; set; }
    }
}