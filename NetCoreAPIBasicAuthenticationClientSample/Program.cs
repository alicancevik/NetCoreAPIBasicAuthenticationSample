using System.Text;

using var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://localhost:5171/api/auth/profile");

string credentials = "user1:1234";
string credentialBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {credentialBase64}");

var result = await httpClient.GetAsync("");


if (result.IsSuccessStatusCode)
{
    Console.WriteLine("Başarılı...");
}
else
{
    Console.WriteLine($"Başarısız! > Hata Kodu: {result.StatusCode}");
}

Console.ReadLine();