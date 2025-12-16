# BlazorApexTree - Setup & Build Guide

## Prerequisites

- .NET 8.0 SDK or higher

## Project Structure

```
BlazorApexTree/
├── src/
│   ├── BlazorApexTree/              # Main library project
│   │   ├── Components/              # Razor components
│   │   ├── Models/                  # Data models
│   │   ├── Interop/                 # JS interop layer
│   │   └── wwwroot/                 # Static assets (JS, CSS)
│   └── BlazorApexTree.Sample/       # Sample WebAssembly app
├── BlazorApexTree.sln               # Solution file
├── README.md
└── LICENSE
```

## Initial Setup

### 1. Get ApexTree Library

The `apextree.min.js` file needs to be added to the project:

**via npm**

```bash
npm install apextree
cp node_modules/apextree/dist/apextree.min.js src/BlazorApexTree/wwwroot/
```

### 2. Restore Dependencies

```bash
cd BlazorApexTree
dotnet restore
```

### 3. Build the Solution

```bash
dotnet build
```

## Development

### Running the Sample App

```bash
cd src/BlazorApexTree.Sample
dotnet run
```

Then open your browser to `https://localhost:5001` (or the URL shown in console).

## Resources

- [ApexTree](https://github.com/apexcharts/apextree)
- [NuGet Documentation](https://learn.microsoft.com/en-us/nuget/)

## Support

For issues and questions:

- GitHub Issues: https://github.com/apexcharts/Blazor-ApexTree/issues
