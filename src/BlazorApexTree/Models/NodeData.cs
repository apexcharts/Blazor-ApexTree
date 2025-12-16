using System.Text.Json.Serialization;

namespace BlazorApexTree.Models;

/// <summary>
/// represents a node in the tree hierarchy
/// </summary>
public class NodeData
{
    /// <summary>
    /// unique identifier for the node
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// display name/content of the node
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// child nodes of this node
    /// </summary>
    [JsonPropertyName("children")]
    public List<NodeData>? Children { get; set; }
    
    /// <summary>
    /// additional data associated with the node (for custom templates)
    /// </summary>
    [JsonPropertyName("data")]
    public object? Data { get; set; }
    
    /// <summary>
    /// node-specific options that override global options
    /// </summary>
    [JsonPropertyName("options")]
    public NodeOptions? Options { get; set; }
}
