# BlazorApexTree

A Blazor wrapper component for [ApexTree](https://github.com/apexcharts/tree) - Create beautiful organizational and hierarchical charts in your Blazor applications.

[![NuGet](https://img.shields.io/nuget/v/BlazorApexTree.svg)](https://www.nuget.org/packages/BlazorApexTree/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## 📦 Installation

Install the package via NuGet:

```bash
dotnet add package BlazorApexTree
```

Or via Package Manager:

```
Install-Package BlazorApexTree
```

## 🚀 Quick Start

### 1. Set License (if you have a commercial license)

In your `Program.cs`:

```csharp
using BlazorApexTree;

// if you have a commercial ApexTree license
ApexTreeLicense.SetLicense("your-license-key-here");
```

### 2. Add the component to your page

```razor
@page "/orgchart"
@using BlazorApexTree
@using BlazorApexTree.Models

<ApexTree Options="@options" Data="@data" OnNodeClick="HandleNodeClick" />

@code {
    private TreeOptions options = new()
    {
        Width = 800,
        Height = 600,
        Direction = TreeDirection.Top,
        NodeWidth = 150,
        NodeHeight = 80,
        EnableToolbar = true,
        EnableTooltip = true,
        TooltipFontColor = "#ffffff",
        TooltipBGColor = "#2d3748",
        TooltipFontSize = "14px",
        TooltipPadding = 12
    };

    private NodeData data = new()
    {
        Id = "1",
        Name = "CEO",
        Children = new List<NodeData>
        {
            new() { Id = "2", Name = "CTO" },
            new() { Id = "3", Name = "CFO" }
        }
    };

    private void HandleNodeClick(NodeClickEventArgs args)
    {
        Console.WriteLine($"Clicked node: {args.NodeId}");
    }
}
```

## 📖 Documentation

### Tree Options

| Property           | Type          | Default   | Description                                      |
| ------------------ | ------------- | --------- | ------------------------------------------------ |
| Width              | int/string    | 400       | Width of the tree container                      |
| Height             | int/string    | 400       | Height of the tree container                     |
| Direction          | TreeDirection | Top       | Tree layout direction (Top, Bottom, Left, Right) |
| NodeWidth          | int           | 50        | Width of each node                               |
| NodeHeight         | int           | 30        | Height of each node                              |
| ChildrenSpacing    | int           | 50        | Spacing between parent and children              |
| SiblingSpacing     | int           | 50        | Spacing between sibling nodes                    |
| EnableToolbar      | bool          | false     | Show zoom/export toolbar                         |
| HighlightOnHover   | bool          | true      | Highlight nodes on hover                         |
| GroupLeafNodes     | bool          | false     | Stack leaf nodes together                        |
| EnableTooltip      | bool          | false     | Enable/disable tooltips                          |
| TooltipFontColor   | string        | "#000000" | Text color inside tooltips                       |
| TooltipFontSize    | string        | "12px"    | Font size for tooltip text                       |
| TooltipFontFamily  | string        | null      | Font family for tooltips                         |
| TooltipPadding     | int           | 8         | Internal spacing (0 for custom templates)        |
| TooltipOffset      | int           | 10        | Distance from cursor to tooltip                  |
| TooltipMaxWidth    | int           | 300       | Maximum tooltip width                            |
| TooltipMinWidth    | int           | 100       | Minimum tooltip width                            |
| TooltipBGColor     | string        | "#FFFFFF" | Background color                                 |
| TooltipBorderColor | string        | "#BCBCBC" | Border color                                     |
| TooltipTemplate    | string        | null      | Custom HTML template function (JavaScript)       |

See [TreeOptions.cs](src/BlazorApexTree/Models/TreeOptions.cs) for all available options.

### Custom Tooltip Templates

Create rich tooltips with custom HTML templates:

```csharp
private TreeOptions options = new()
{
    EnableTooltip = true,
    TooltipPadding = 0,  // set to 0 when using custom template
    TooltipTemplate = @"(content) => {
        const data = typeof content === 'object' ? content : { name: content };
        return `
            <div style='padding: 12px;'>
                <div style='font-weight: bold; color: #1e40af;'>
                    ${data.name || content}
                </div>
                ${data.department ? `<div style='font-size: 12px;'>
                    📂 ${data.department}
                </div>` : ''}
                ${data.email ? `<div style='font-size: 12px;'>
                    ✉️ ${data.email}
                </div>` : ''}
            </div>
        `;
    }"
};

private NodeData data = new()
{
    Id = "1",
    Name = "Sarah Johnson",
    Data = new
    {
        name = "Sarah Johnson",
        department = "Engineering",
        email = "sarah@company.com"
    }
};
```

### Node Data Structure

```csharp
public class NodeData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<NodeData> Children { get; set; }
    public NodeOptions? Options { get; set; }  // per-node styling
    public object? Data { get; set; }
}
```

### Events

- `OnNodeClick` - Fired when a node is clicked
- `OnNodeHover` - Fired when hovering over a node
- `OnLayoutChange` - Fired when layout direction changes

### Component Methods

```csharp
// change layout direction dynamically
await treeRef.ChangeLayoutAsync(TreeDirection.Left);

// expand/collapse nodes
await treeRef.ExpandAsync("nodeId");
await treeRef.CollapseAsync("nodeId");

// fit tree to screen
await treeRef.FitScreenAsync();
```

## 🎨 Examples

Check out the [sample project](src/BlazorApexTree.Sample/) for comprehensive examples

## 📄 License

ApexTree is licensed under the Dual License Model.

See [ApexTree License](https://apexcharts.com/license) for details.

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 🙏 Acknowledgments

- [ApexTree](https://github.com/apexcharts/tree) - The amazing charting library this wrapper is built on
- Blazor community for inspiration and support

## 📞 Support

- 🐛 [Report issues](https://github.com/apexcharts/Blazor-ApexTree/issues)
- 💡 [Request features](https://github.com/apexcharts/Blazor-ApexTree/issues)
- 📧 Contact: your-email@example.com
