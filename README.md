# mcpTools

This repository contains a .NET 8 solution with two main projects: a console application named Client and a utility project named RestArchitectureTools.

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

## Contributing

Feel free to fork the repository and submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.