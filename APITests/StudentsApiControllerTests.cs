using Newtonsoft.Json;
using RStudents.Tests;
using System.Net;
using System.Text;

namespace RStudentsTest.APITests
{
    [TestFixture]
    public class ProductsControllerTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Urls.BaseUrl + "/api/");
        }

        [Test]
        public async Task Test_GetStudents()
        {
            HttpResponseMessage response = await _client.GetAsync("StudentsApi");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task Test_AddStudent()
        {
            var product = new { firstName = "Test", lastName = "Test", age = 22, groupId = 1 };

            HttpResponseMessage response = await _client.PostAsync("StudentsApi",
                new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public async Task Test_DeleteStudent()
        {
            var product = new { firstName = "Test", lastName = "Test", age = 22, groupId = 1 };

            HttpResponseMessage response = await _client.PostAsync("StudentsApi",
                new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var createdStudent = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
            int productIdToDelete = createdStudent.id;

            response = await _client.DeleteAsync($"StudentsApi/{productIdToDelete}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}