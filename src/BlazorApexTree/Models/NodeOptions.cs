using System.Text.Json.Serialization;

namespace BlazorApexTree.Models;

/// <summary>
/// styling options that can be applied to individual nodes
/// </summary>
public class NodeOptions
{
    // ========== Node Appearance ==========
    
    /// <summary>
    /// background color for this node
    /// </summary>
    [JsonPropertyName("nodeBGColor")]
    public string? NodeBGColor { get; set; }
    
    /// <summary>
    /// background color on hover for this node
    /// </summary>
    [JsonPropertyName("nodeBGColorHover")]
    public string? NodeBGColorHover { get; set; }
    
    /// <summary>
    /// border color for this node
    /// </summary>
    [JsonPropertyName("borderColor")]
    public string? BorderColor { get; set; }
    
    /// <summary>
    /// border color on hover for this node
    /// </summary>
    [JsonPropertyName("borderColorHover")]
    public string? BorderColorHover { get; set; }
    
    /// <summary>
    /// border width for this node (in pixels)
    /// </summary>
    [JsonPropertyName("borderWidth")]
    public int? BorderWidth { get; set; }
    
    /// <summary>
    /// border style for this node (solid, dashed, dotted, etc.)
    /// </summary>
    [JsonPropertyName("borderStyle")]
    public string? BorderStyle { get; set; }
    
    /// <summary>
    /// border radius for this node (e.g., "5px")
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public string? BorderRadius { get; set; }
    
    // ========== Font Options ==========
    
    /// <summary>
    /// font size for this node (e.g., "14px")
    /// </summary>
    [JsonPropertyName("fontSize")]
    public string? FontSize { get; set; }
    
    /// <summary>
    /// font family for this node
    /// </summary>
    [JsonPropertyName("fontFamily")]
    public string? FontFamily { get; set; }
    
    /// <summary>
    /// font weight for this node (e.g., "400", "bold")
    /// </summary>
    [JsonPropertyName("fontWeight")]
    public string? FontWeight { get; set; }
    
    /// <summary>
    /// font color for this node
    /// </summary>
    [JsonPropertyName("fontColor")]
    public string? FontColor { get; set; }
    
    // ========== Node Size ==========
    
    /// <summary>
    /// width for this node (in pixels)
    /// </summary>
    [JsonPropertyName("nodeWidth")]
    public int? NodeWidth { get; set; }
    
    /// <summary>
    /// height for this node (in pixels)
    /// </summary>
    [JsonPropertyName("nodeHeight")]
    public int? NodeHeight { get; set; }
    
    // ========== Custom Styling ==========
    
    /// <summary>
    /// custom CSS class for this node
    /// </summary>
    [JsonPropertyName("nodeClassName")]
    public string? NodeClassName { get; set; }
    
    /// <summary>
    /// custom inline styles for this node
    /// </summary>
    [JsonPropertyName("nodeStyle")]
    public string? NodeStyle { get; set; }
}
