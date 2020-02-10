using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Grpc.Net.Client.Web;
using System.Net.Http;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using BlazorApp11.Shared;

namespace BlazorApp11.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(services =>
            {
                var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
                var channel = GrpcChannel.ForAddress(services.GetRequiredService<NavigationManager>().BaseUri, new GrpcChannelOptions
                {
                    HttpClient = new HttpClient(handler)
                });

                // Now we can instantiate gRPC clients for this channel
                return new tests.testsClient(channel);
            });

            await builder.Build().RunAsync();
        }
    }
}
