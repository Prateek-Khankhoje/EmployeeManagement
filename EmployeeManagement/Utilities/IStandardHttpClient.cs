namespace EmployeeManagement.Utilities
{
    public interface IStandardHttpClient
    {
        Task<T> HttpGetAsync<T>(string url);
        Task<T> HttpPostAsync<T>(string url, Object postData);
    }
}
