using BlazorApp11.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;

namespace BlazorApp11.Server.Services
{
    public class TestService : BlazorApp11.Shared.tests.testsBase
    {
        public override Task<TestReply> GetTests(Empty request, ServerCallContext context)
        {
            var reply = new TestReply();
            var t = new Test();
            t.Value = "THIS MESSAGE IS IRRELEVANT!";
            reply.Tests.Add(t);
            return Task.FromResult(reply);
        }
    }
}
