
using System.Text;
//basic authentication done using username and password

var url = "https://localhost:7204";  //open JWTtoken project and run that project
var username = "Admin";             // then run this project to check basic authentication
var password = "12345";

var client = new  HttpClient(); // create new instance of http request and handle responses
client.BaseAddress = new Uri(url); // pass base url 
client.DefaultRequestHeaders.Authorization = 
    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username} : {password}")));
                            //authentication was apply using username and password
var responses = await client.GetAsync("/getUser"); //from this (route)path data will fetch from JWTtoken project   


if (responses.IsSuccessStatusCode) 
{
    var content = await responses.Content.ReadAsStringAsync(); // read content from responses
    Console.WriteLine(content);//content print on console 
}
else
{
    Console.WriteLine(responses.StatusCode.ToString());
}