using MTechSytem.Models;
using System.Net;

namespace MTechSytem.Data
{
    public class EmployeeService
    {
        readonly HttpClient _httpClient = new HttpClient();
        readonly IConfiguration _configuration;
        private const string _urlResource = "api/employee";

        public EmployeeService(IConfiguration configuration)
        {
            _configuration=configuration;
            var baseAdressAPI = _configuration.GetValue<string>("baseUrlApi");

            _httpClient.BaseAddress = new Uri(baseAdressAPI);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        public async Task<List<Employee>> GetEmployees(string name = null)
        {
            var requestUri = _urlResource + (string.IsNullOrWhiteSpace(name) ? "" : $"/{name}");
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            var results = await response.Content.ReadFromJsonAsync<List<Employee>>();
            return results;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_urlResource}/{id}");
            var results = await response.Content.ReadFromJsonAsync<Employee>();
            return results;
        }

        public async Task<HttpStatusCode> DeleteEmployee(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_urlResource}/{id}");
            return response.StatusCode;
        }

        public async Task<int> CreateEmailAsync(Employee employee)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_urlResource, employee);
            return (int)response.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateEmail(int id, Employee employee)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_urlResource}/{id}", employee);
            return response.StatusCode;
        }
    }
}
