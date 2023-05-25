// See https://aka.ms/new-console-template for more information
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Text;
using System;
using System.Xml.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using (var content = new MultipartFormDataContent())
{
    // Read the PDF file content
    byte[] pdfBytes = File.ReadAllBytes(@"C:\Users\Aramy\Downloads\sample.pdf");
    
    var pdfContent = new ByteArrayContent(pdfBytes);
    pdfContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
    pdfContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
    pdfContent.Headers.ContentDisposition.Name = "pdfFile";
    pdfContent.Headers.ContentDisposition.FileName = "file.pdf";

    // Create the XML payload
    string xmlPayload = "<root><data>Hello, XML!</data></root>";
    var xmlContent = new StringContent(xmlPayload, Encoding.UTF8, "application/xml");

    // Add the PDF and XML content to the multipart form data
    content.Add(pdfContent);
    content.Add(xmlContent, "payload");

    HttpClient client = new HttpClient();

    // Send the POST request
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "c308b48335fd48daa0e5f78c6099d280");
    client.DefaultRequestHeaders.Authorization =
   new AuthenticationHeaderValue("Bearer", "eyJraWQiOiJzdWZibFRUUExGdHc1N0VEdU05bWZEMXV3aU5nTUVKNUFRa3k5SjhWVXBZIiwiYWxnIjoiUlMyNTYifQ.eyJ2ZXIiOjEsImp0aSI6IkFULkFuWWlrczF2a2hlUExGT1Q2TXhYWC0zeGVyZW5kOWF2d2h1ejAybkplbXMiLCJpc3MiOiJodHRwczovL3Nzby10ZXN0LmRhaGwubm8vb2F1dGgyL2RlZmF1bHQiLCJhdWQiOiJhcGk6Ly9kZWZhdWx0IiwiaWF0IjoxNjg1MDEzOTA2LCJleHAiOjE2ODUwMTc1MDYsImNpZCI6IlMxYWlvUW5kR1JCT1BwVEdPdTlIIiwic2NwIjpbInJvbGVzIl0sInN1YiI6IlMxYWlvUW5kR1JCT1BwVEdPdTlIIn0.Pa80wIjKj7gLlk0pMvXQ0VuoOlJxKiIEBNyYsMsJJIBnhR2hvbj2shwN3QBUjDi6AlDbJquPnbGJhOTN6JbSK9JU8yk6P8gA347kbR79lcKq_9kJNx08MkQpaNNhH12Vm0ljkCdu7cihjYsmLdkf8DRjIAQji_CvByVXpa2Vw9cx7hovAJITWjN2uOc8zvu9WTywarDJ1ysUurcK53jiqdIiflQpRpsb1xqMo4iZgB3skTHy1Gm7mo8olspKz9ZIV4MXpWnMwgplnfpaRqIbyrgwaCOAlZ7gUGD0-wt8dtOnJ5S_Gy9ZMEj2GCD-p-PES-ugLqDD7wIJzE75CmgQGA");


    // var response = await client.PostAsync("http://localhost:7162/api/Function1", content);

    //  var response = await client.PostAsync("https://apim-don-dip-dev.azure-api.net/invoice/V1/ehf/supplierinvoice", content);
    var response = await client.PostAsync("https://func-int088-LogiqToMedusAndDSP-d.azurewebsites.net/api/Receive_EHF_Supplierinvoices?code=VpfUcQVd-YIY_DyE2p2Ek1zhoJ17Gro17xadE5JeYd25AzFug7_QoA==", content);

    


    Console.WriteLine(response.RequestMessage);

    Console.WriteLine(response.ReasonPhrase);


    if (response.IsSuccessStatusCode)
    {

    }

}













































testClass tc = new testClass()
{
    MyProperty = 3,
    Name = "Name",
};



Transform(tc);


















string invalidXml = "9A \u0001\u0003";
string validXml = $"<root>{invalidXml}</root>";

validXml = validXml.Replace("<root>", "").Replace("</root>", "");
validXml = System.Security.SecurityElement.Escape(validXml);

Console.WriteLine(validXml);

Console.WriteLine("Hello, World!");

// Create a BlobServiceClient object using the connection string
var blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=storint060t;AccountKey=8x3F6W6RtYXRWI21WuJjDW2pop8cnsF4x4LU8PItXUF0HPZHVnOn8IUs6aIWCQc03rGBC+5WGI1V+ASt/Uz0cg==;EndpointSuffix=core.windows.net");

// Get a reference to the container
var _containerClient = blobServiceClient.GetBlobContainerClient("customer-messages");


await foreach (BlobItem blobItem in _containerClient.GetBlobsAsync(prefix: $"Quote/OPTtestatoppoln"))
    Console.WriteLine( blobItem.Name);




    string[] jsonFiles = Directory.GetFiles(@"C:\Repo\Kubernetes\Authorization", "*.yml");

foreach (string file in jsonFiles)
{
    string directoryPath = @"C:\Repo\Kubernetes\Authorization\ErrorDirectory";

    string fileName = Path.GetFileName(file);

    string filePath = Path.Combine(directoryPath, fileName);

    if (!Directory.Exists(directoryPath))
        Directory.CreateDirectory(directoryPath);

    // Check if the file exists
    if (!File.Exists(filePath))
    {
        // If the file doesn't exist, create it and write the header row
        using (StreamWriter sw = File.CreateText(filePath))
        {
            sw.WriteLine("test|data");
        }
    }
    else
    {
        // If the file exists, append the data to it
        using (StreamWriter sw = File.AppendText(filePath))
        {
            // Append the data to the file
            sw.WriteLine("new|data");
        }
    }
}


void Transform(ItestClass item)
{
    Console.WriteLine(item.Name);

    testClass tc = item as testClass;

    Console.WriteLine(tc.MyProperty);
}
public class testClass : ItestClass
{
    public int MyProperty { get; set; }
    public string Name { get; set; }
} 

public interface ItestClass
{
    public string Name { get; set; }

}

