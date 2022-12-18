namespace StudentCURDService.ServiceClient
{
    public class ServiceClientHelper
    {
        private readonly HttpClient _httpClient;

        public ServiceClientHelper (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetStudentFee(int id)
        {
            string result = string.Empty;

            var handler = new HttpClientHandler();

            handler.ClientCertificateOptions = ClientCertificateOption.Manual;

            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            using (var client = new HttpClient(handler))
            {
                try
                {
                    string url = "https://localhost:8081/StudentFee";

                    url = url + "?Id=" + id;

                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,

                        RequestUri = new Uri(url),
                    };

                    var postTask = await client.SendAsync(request);


                    string apiResponse = await postTask.Content.ReadAsStringAsync();

                    result = apiResponse;
                }
                catch (Exception ex)
                {

                }
            }

            return result;
        }
    }
}
