namespace WebApp.Services;

public interface IApiService
{
    Task<TResponse> GetAsync<TResponse>(string endpoint);
    Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request);
    Task PutAsync<TRequest>(string endpoint, TRequest request);
    Task DeleteAsync(string endpoint);
    Task<TResponse> PatchAsync<TRequest, TResponse>(string endpoint, TRequest request);
    
}