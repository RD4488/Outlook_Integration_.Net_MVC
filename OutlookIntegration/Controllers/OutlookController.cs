using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using OutlookIntegration.Model;
using RestSharp;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OutlookIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutlookController : ControllerBase
    {
        readonly HttpClient client = new HttpClient();
        

        // GET: api/<OutlookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new RestClient("https://graph.microsoft.com/v1.0/me/messages");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer EwB4A8l6BAAUs5+HQn0N+h2FxWzLS31ZgQVuHsYAAS/bbXCRcp6SWhiYi0Q81qi+raLIJjIehebuRHdWakVaQTA2+NYCTgK5XtlCNvIA7nEqAbdtUby2WKQE+OAai0ccLZgEomlEgrMBZc81tTgusnHWoN0I1fELPIGV5zS8jbl3Ik2OYiSFCFCu/sGmfOcQUmzDqYDZPGDJKsUONL1Uuym/3p3xRPP8GiP0kLoXRqR0Ey8EYz9Jmqz/2Dp9YNZK6gySo14PVycQUveK1Bb7QIxe5Xc7SxuFbdCvCZ38v+ll+Qrb0g14HzQGzFQv9Rd+labpV+yLWQvHIICTzatc0vEQlZVM4oZD+G8j8OAffc5FxECxaB6HEy4XFEEjEgcDZgAACPt0cXp8ZVwwSAIA3mjpAfzgS37ySXcS7fKYxD6lJCLxUrz+FX3nEz5GyPM+3gh3SiJeqAUAVcpSRo+/wwcGRR/p+ydmMYQwCI6M/rWBCNhVAMbW9HKm80do95VeyUINvrUadM8ZWebmtR6rDeZI+jP2nQ0DveN/Ak5bMD1PTA8V+AmAt6Us1/ZwObiIwGYOJwg2khy/y/TBNNfK5CbER+AUdEx7sd6Mv814mXZn557Il777j0O6Tq4v5QdTFZmWWkZOGoeAzJxfeMXEkmwIkbgCPZfsn51jhIEwrPGuFtqt30MXkqGA2FJ1yyZoPnkb2Qp+RHgiJKfbXqQPTPtDPJ/jDlhuP+c/1B1RwDF6ZDG/6YGwj6UReI9zehn8KxWP83I8mnWlMj78NDrcV0x6vevbjtikBo3F/eU/p0vpMFX3zs5+tqZly61jQcuLnRFeoi826V0u27LJNaGl2K970+u0311zRDH8+XOXhF+ShWVe5S2FG5q6UDUQ/j1skGZZzEFCokl4QhB0jZZt5Bzsgq3YILY2SyjSE5AUELJGWjn1vGgjBs7yq/iPMgvSRgiRXG/h/tDZplrJL8QvYw2V8YaDLdQXpcLZeg1/gz2V6QRCSgvyuCfgYlEmOuomnjTTS7PJipqLSqzTOpm8E9ywSMJCYB+JmibWKEI9h4hrWMkIUE9/s06ew0b5HrPrPmgJfj0hfxZW89pnrlJmqg51MmAkefNsJFWPDotI02VmQjwQeJyBlhgA/WyIusFz5d3QwNm02yLiDOzFlkJqq+FFATo42ZIC");
            var response = client.Execute(request);
            //var jsonObject = JsonConvert.DeserializeObject<EmailModel>(response.Content);
            return Ok(response.Content);
        }

       

        // POST api/<OutlookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmailModel email)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "");
            var responce = await client.PostAsync("", new StringContent(JsonSerializer.Serialize(email), Encoding.UTF8, "application/json"));
            return Ok(responce);
        }

    }
}
