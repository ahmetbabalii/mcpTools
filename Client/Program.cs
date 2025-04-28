
using ModelContextProtocol;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;


Console.WriteLine("MCP sunucusuna bağlantı sağlanıyor...");

IMcpClient client = await McpClientFactory.CreateAsync(serverConfig: new McpServerConfig()
{
    Id = "MCPServer",
    Name = "MCP Server",
    TransportType = TransportTypes.StdIo,
    TransportOptions = new()
    {
        ["command"] = "H:\\PersonalProject\\MCP\\Model_Context_Protocol_Example\\RestArchitectureTools\\bin\\Debug\\net9.0\\RestArchitectureTools.exe"
    }
});

Console.WriteLine("MCP sunucusuna bağlantı sağlandı...");

var tools = await client.ListToolsAsync();
foreach (var tool in tools.Select((tool, index) => new { Tool = tool, Index = index }))
{
    Console.WriteLine($"\tTool {tool.Index + 1} : {tool.Tool.Name} ({tool.Tool.Description})");
}

var result = await client.CallToolAsync(
    "Echo",
    new Dictionary<string, object?>() { ["message"] = "Merhaba, naaptın müdür?" });

Console.WriteLine($"Result : {result.Content.First(c => c.Type == "text").Text}");

Console.Read();
await client.DisposeAsync();