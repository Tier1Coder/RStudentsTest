using Newtonsoft.Json;
using RestSharp;
using RStudents.Tests;

namespace RStudentsTest.APITests
{
    [TestFixture]
    public class GroupsApiControllerTests
    {
        private RestClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(Urls.BaseUrl + "/api/");
        }

        [Test]
        public void Test_GetGroups()
        {
            var request = new RestRequest("GroupsApi", Method.Get);
            var response = _client.Execute(request);

            Assert.IsTrue(response.IsSuccessful, "GET request failed");

            Console.WriteLine("Response content:");
            Console.WriteLine(response.Content);
        }

        [Test]
        public void Test_AddGroup()
        {
            var request = new RestRequest("GroupsApi", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                groupName = "TestGrupa"
            });

            var response = _client.Execute(request);

            Assert.IsTrue(response.IsSuccessful, "POST request failed");

            Console.WriteLine("Response content:");
            Console.WriteLine(response.Content);
        }

        [Test]
        public void Test_DeleteGroup()
        {
            var request = new RestRequest("GroupsApi", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                groupName = "TestGrupaDelete"
            });

            var response = _client.Execute(request);
            Assert.IsTrue(response.IsSuccessful, "POST request failed");

            dynamic responseData = JsonConvert.DeserializeObject(response.Content);
            int groupId = responseData.id;

            request = new RestRequest($"GroupsApi/{groupId}", Method.Delete);
            response = _client.Execute(request);
            Assert.IsTrue(response.IsSuccessful, "DELETE request failed");

            Console.WriteLine($"Group with ID {groupId} deleted successfully");
        }
    }
}
