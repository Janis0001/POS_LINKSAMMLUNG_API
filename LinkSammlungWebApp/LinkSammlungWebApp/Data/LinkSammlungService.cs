using System.Text.Json;
using System.Text;
using System.Diagnostics;

namespace LinkSammlungWebApp.Data
{
    public class LinkSammlungService
    {

        List<Linksammlung> allData = new List<Linksammlung>();
        public void getAllInformation()
        {
            Linksammlung link = new Linksammlung();
            try
            {
                HttpClient client = new HttpClient();
                string data = "";
                data = client.GetStringAsync("http://localhost:3002/Link").Result;
                var list = JsonSerializer.Deserialize<List<Linksammlung>>(data);



            }
            catch (Exception ex)
            {

            }
        }
        public IEnumerable<Linksammlung> DeserializeLinksammlung(string json)
        {
            // Use the System.Text.Json namespace for JSON deserialization
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Deserialize the JSON string into a collection of Linksammlung objects
            var links = JsonSerializer.Deserialize<IEnumerable<Linksammlung>>(json, options);

            return links;
        }

    }
}
