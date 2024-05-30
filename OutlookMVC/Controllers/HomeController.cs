using Microsoft.AspNetCore.Mvc;
using OutlookMVC.Models;
using RestSharp;
using System.Diagnostics;
using System.Text.Json;

namespace OutlookMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly string token = "Bearer EwDIA8l6BAAUbDba3x2OMJElkF7gJ4z/VbCPEz0AAbWIcRkiY6TymqJ0R7VRgGEiktyNpG1PP7dckbnKZJU6Uikmif29E7e8rqWa8BSjJF3nMw3ZD08XCDm0lVu3H/5qj7BJWdV+aqBrmKNbuRfnLjtFjFfyVT4E8kBU2ku6qWYFbTWOLEyIp+v5XyZbZs5cq6v3bQy25YmEA3CT6jlnf2SFBEUXrOB1b/D1wL2BVWWAicgAFkBaOiEJfCQ6XCMCxA4Jf7SJL7VVgt1mGwEMik1KSS9pfEuqWc/tVDP1KmT8VBfEVTwS2tQGVkpRolatjdKBGrGo5ExYiSbNPrcOz6DBwf5NZdtaRAZiE7HuZxOaYfFMO9dgW5q73Fiu900DZgAACJ2FVuqfMEsxmAK3jAWYa0xU0Y7m+YRvGmk7D/x7jkSJxYQME+SFwZVpp4Ijk5H3g3TBPtLRtB3f0ispW2reCaZLKK+zdqnZRDXinrK+10VoyaweMT8b3hK0xOBSIJ8BEJ1oM0XxHK7gdFvv9jNIUZ+TyKrmfs4g+CHp4/FyKXQ0bh5nIgu/sBOapZcstbuDRsg5qPnHaz8YLtOynG7RA39ycSqhW9H5jV87HTwSKXsbj9s7zYn9SxliDLdHzYmiql5G4KdfHr4hDNGouJq+9Hfhk5LlMO9o+e6M8k/oZeRPfV9Yj7uwQXkGPDOck43SIiy3zLhU3IibvDVlhfxjRvodcpzNNabQsEthPnpj/3m9aeCO5PbC9OoNha6Z/3biqnTovuCYbJmYCnZirXe/vnY/02vSqDDr3LP9+ZFBTzObEpK60RQLkj/K1AF9H3itcsh6QnfsATNSjK7l01Dqq16pwSeLropFI3EoJ5mHRkbkaPr3wpOE1whbAUzRYiAZ6Cc5wLSwoN8WzGJE2WfxKdXmi9r40lKlj7+LO/+53rsmO6ZIuaw5qTsJ8mF65AiXd3TVxgtdsDzej7Q1CoQsT2Hz3LMD4a23VkryCE9kZfq2uFLpbqbd2swDzMIZBGWtVJVyMOUj0hmb2+pr9OXfyZ2sSSZCOnCP6/MmbOyZo1/UOrUCwqB4XZrK7++9aJdZT0nJ3cC6HyJcTWD8BOzy87fNEde6vF6mB6cHsQymcWMyb0K3gRQ+r9XD6q2Vo23kr8b7SKI2GVutoGNwMH85XPI0iKfKM/Idt9gGdl8lqoHIRpIRNLqCTwSIDu28M8BUSV5r7Zu34OgynhcA0pKFOA5irVBYM9dlB5n0NOx/KCZ+quxbkfN44DXNiL+2B31lTDt21wI=";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public object GetMails()
        {
            var client = new RestClient("https://graph.microsoft.com/v1.0/me/messages");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", token);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                try
                {
                    var email = JsonSerializer.Deserialize<EmailModel>(response.Content);
                    return email;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Deserialization error: {ex.Message}");
                    return null;
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.Content}");
                return null;
            }
        }
        public object GetInboxMails()
        {
            var client = new RestClient("https://graph.microsoft.com/v1.0/me/mailfolders/inbox/messages");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", token);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                try
                {
                    var email = JsonSerializer.Deserialize<EmailModel>(response.Content);
                    return email;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Deserialization error: {ex.Message}");
                    return null;
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.Content}");
                return null;
            }
        }
        public string SendMail(SendEmailModel sendEmail)
        {
            var client = new RestClient("https://graph.microsoft.com/v1.0/me/sendMail");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", token);
            request.AddParameter("application/json", sendEmail, ParameterType.RequestBody);
            var response = client.Execute(request);
            return "Mail Send successfully";
        }
    }
}
