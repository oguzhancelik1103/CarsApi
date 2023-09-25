using Microsoft.AspNetCore.Http.Headers;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;

namespace CarsApi.Services.Health;

public class ApiHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
       var url = "https://airport-info.p.rapidapi.com/airport";

       var client = new RestClient(url);
       var request = new RestRequest(url, Method.Get);
       request.AddHeader("X-RapidAPI-Key", "444ded4021msh0516c573ba2a066p19b2adjsnc20affcdbd9d");
       request.AddHeader("X-RapidAPI-Host", "airport-info.p.rapidapi.com");

       var response = client.Execute(request);

       if(response.IsSuccessful){
        return Task.FromResult(HealthCheckResult.Healthy());
       }
       else{
        return Task.FromResult(HealthCheckResult.Unhealthy());
       }
    }
}