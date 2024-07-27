using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq; 

public class ImgurUploader
{
    private readonly string _clientId = "275a7fdcaa144a3";

    public async Task<string> UploadFileAsync(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            throw new ArgumentException("Đường dẫn tệp không hợp lệ.");
        }

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", _clientId);

            using (var form = new MultipartFormDataContent())
            {
                var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePath));
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/*");
                form.Add(fileContent, "image", System.IO.Path.GetFileName(filePath));

                var response = await client.PostAsync("https://api.imgur.com/3/image", form);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseBody);
                return json["data"]["link"].ToString();
            }
        }
    }
}
