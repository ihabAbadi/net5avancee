using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "toto" });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Product product)
        {
            using GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Product.ProductClient(channel);
            var r = new RequestProduct { Title = product.Title, Price = (double)product.Price };
            ResponseProduct response = await client.SendProductAsync(r);
            return Ok(response);
        }
    }
}
