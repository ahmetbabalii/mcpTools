# mcpTools

This repository contains a .NET 8 solution with two main projects: a console application named Client and a utility project named RestArchitectureTools (which acts as an MCP server).

## Project Structure

```
mcpTools
├── mcpTools.sln
├── Client
│   ├── Client.csproj
│   └── Program.cs
├── RestArchitectureTools
│   ├── RestArchitectureTools.csproj
│   ├── Program.cs
│   └── ...
└── README.md
```

## Reference

This project is inspired by and references the official [Model Context Protocol C# SDK](https://github.com/modelcontextprotocol/csharp-sdk).

You can explore the SDK for more advanced usage, integration patterns, and up-to-date protocol implementations.

## Getting Started

To build and run the solution, follow these steps:

1. **Clone the repository:**
   ```
   git clone https://github.com/ahmetbabalii/mcpTools.git
   cd mcpTools
   ```

2. **Open the solution:**
   Open `mcpTools.sln` in your preferred IDE or editor.

3. **Restore dependencies:**
   ```
   dotnet restore
   ```

4. **Build the projects:**
   ```
   dotnet build
   ```

5. **Run the console application:**
   ```
   dotnet run --project Client/Client.csproj
   ```

## Testing MCP Tools with MCP Inspector

You can test the tools provided by the RestArchitectureTools project (MCP server) using the [MCP Inspector](https://www.npmjs.com/package/@modelcontextprotocol/inspector), a web-based UI for interacting with MCP servers.

### Steps:

1. **Install Node.js** (if not already installed):
   - Download and install from [https://nodejs.org/](https://nodejs.org/)

2. **Navigate to the RestArchitectureTools directory:**
   ```
   cd RestArchitectureTools
   ```

3. **Start the MCP Inspector and the server:**
   ```
   npx @modelcontextprotocol/inspector dotnet run
   ```
   This command will build and launch the RestArchitectureTools MCP server and open the Inspector UI in your browser.

4. **Connect and test tools:**
   - In the Inspector UI, click the `Connect` button.
   - Go to the `List Tools` tab to see all available tools.
   - Select and test each tool interactively.

> The Inspector allows you to send parameters, execute tools, and observe responses in real time—similar to how Postman is used for REST APIs.

## Contributing

Feel free to fork the repository and submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.