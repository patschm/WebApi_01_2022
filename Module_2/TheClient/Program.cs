

using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TheClient;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5214/api/");


Person px = new Person { Name = "Marieke"};
string jcontent = JsonConvert.SerializeObject(px);
StringContent content2 = new StringContent(jcontent);
content2.Headers.ContentType = new MediaTypeHeaderValue("application/json");
var response1 = await client.PostAsync("test", content2);
if (response1.StatusCode == HttpStatusCode.Created)
{
    System.Console.WriteLine(response1.Headers.Location);
}


client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
var response = await client.GetAsync("test/0");
if (response.StatusCode == HttpStatusCode.OK)
{
    System.Console.WriteLine(response.Content.Headers.ContentType);
    string content = await response.Content.ReadAsStringAsync();
    //System.Console.WriteLine(content);
    Person? p = JsonConvert.DeserializeObject<Person>(content);
    System.Console.WriteLine(p!.Name);
}
