using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<HelloReply> SecondHello(HelloRequest request1, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello from second Hello"
            });
        }

        public override async Task HellStreaming(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            for(int i=1; i <= 10;i++)
            {
                await Task.Delay(1000);
                HelloReply response = new HelloReply()
                {
                    Message = request.Name + " " + i,
                };
                await responseStream.WriteAsync(response);
            }
            //return base.HellStreaming(request, responseStream, context);
        }


        public override async Task<HelloReply> HeavenStreaming(IAsyncStreamReader<HelloRequest> requestStream, ServerCallContext context)
        {

            await foreach(HelloRequest request in requestStream.ReadAllAsync())
            {
                Debug.WriteLine(request.Name);
            }
            return new HelloReply { Message = "end of client streaming" };
        }
    }
}
