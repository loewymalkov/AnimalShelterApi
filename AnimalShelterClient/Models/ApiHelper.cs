using System.Threading.Tasks;
using RestSharp;

namespace AnimalShelterClient.Models
{
    class ApiHelper
    {
        public static async Task<string> ApiCall()
        {
            RestClient client = new RestClient("http://localhost:5000/api/animals");
            RestRequest request = new RestRequest("/", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiCallAnimalList(string animals)
        {
            RestClient client = new RestClient("http://localhost:5000/api/animals");
            RestRequest request = new RestRequest($"?animalList={animals}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiPost(Animal animal)
        {
            RestClient client = new RestClient("http://localhost:5000/api/animals");
            RestRequest request = new RestRequest("/", Method.POST);
            request.AddJsonBody(animal);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> ApiPut(int id, Animal animal)
        {
            RestClient client = new RestClient("http://localhost:5000/api/animals");
            RestRequest request = new RestRequest($"/{id}", Method.PUT);
            request.AddJsonBody(animal);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}