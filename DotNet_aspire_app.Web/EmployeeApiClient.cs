using DotNet_aspire_app.ApiService.models;
 
namespace DotNet_aspire_app.Web
{
    public class EmployeeApiClient
    {
        private readonly HttpClient _httpClient;
         public EmployeeApiClient(HttpClient httpClient) { 

           _httpClient = httpClient;
        }

        public async Task<EmployeeModel> AddEmployeeAsync(EmployeeModel employee, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/emp/add", employee, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<EmployeeModel>(cancellationToken: cancellationToken);

            return result;
         
        }
        public async Task<List<EmployeeModel>> GetEmployeeAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetFromJsonAsync<List<EmployeeModel>>("/api/emp", cancellationToken);
            return response ?? new List<EmployeeModel>();
        }

       public async Task<bool> DeleteEmployee(int id ,CancellationToken cancellationToken = default)
        {
            var res = await _httpClient.DeleteAsync($"/api/emp/Delete/{id}" ,cancellationToken);

            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

          public async Task<EmployeeModel> UpdateEmployee(int id , EmployeeModel employee, CancellationToken cancellationToken = default)
        {
            var res = await _httpClient.PutAsJsonAsync($"/api/emp/Update/{id}" , employee, cancellationToken);

           res.EnsureSuccessStatusCode();

            var result = await res.Content.ReadFromJsonAsync<EmployeeModel>(cancellationToken: cancellationToken);

            return result;
        }

   }   

}
