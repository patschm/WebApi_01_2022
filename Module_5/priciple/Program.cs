using System.Net.Http.Headers;
using Microsoft.Identity.Client;

var app = PublicClientApplicationBuilder
    .Create("c618c181-dcde-4d5a-a630-f797e8d0887c")
    .WithAuthority(AzureCloudInstance.AzurePublic, "030b09d5-7f0f-40b0-8c01-03ac319b2d71")
    .WithRedirectUri("http://localhost:9999")
    .Build();

var result = app.AcquireTokenInteractive(new string[]{"api://c618c181-dcde-4d5a-a630-f797e8d0887c/Reader"});


var autRes = await result.ExecuteAsync();
System.Console.WriteLine(autRes.AccessToken);

HttpClient client = new HttpClient {BaseAddress = new Uri("https://localhost:7190/")};
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autRes.AccessToken);

var res = await client.GetAsync("weatherforecast");
System.Console.WriteLine(res.StatusCode);

    
//Microsoft.Identity.Client.ConfidentialClientApplicationBuilder