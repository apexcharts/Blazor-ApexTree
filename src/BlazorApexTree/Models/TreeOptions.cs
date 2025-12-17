using System.Text.Json.Serialization;

namespace BlazorApexTree.Models;

/// <summary>
/// configuration options for the ApexTree component
/// </summary>
public class TreeOptions
{
    // ========== Layout Options ==========
    
    /// <summary>
    /// width of the tree container (in pixels or as string like "100%")
    /// </summary>
    [JsonPropertyName("width")]
    public object Width { get; set; } = 800;
    
    /// <summary>
    /// height of the tree container (in pixels or as string like "100%")
    /// </summary>
    [JsonPropertyName("height")]
    public object Height { get; set; } = 600;
    
    /// <summary>
    /// direction in which the tree flows
    /// </summary>
    [JsonPropertyName("direction")]
    public string Direction { get; set; } = "top";
    
    /// <summary>
    /// spacing between parent and children nodes (in pixels)
    /// </summary>
    [JsonPropertyName("childrenSpacing")]
    public int ChildrenSpacing { get; set; } = 50;
    
    /// <summary>
    /// spacing between sibling nodes (in pixels)
    /// </summary>
    [JsonPropertyName("siblingSpacing")]
    public int SiblingSpacing { get; set; } = 50;
    
    // ========== Node Options ==========
    
    /// <summary>
    /// width of each node (in pixels)
    /// </summary>
    [JsonPropertyName("nodeWidth")]
    public int NodeWidth { get; set; } = 120;
    
    /// <summary>
    /// height of each node (in pixels)
    /// </summary>
    [JsonPropertyName("nodeHeight")]
    public int NodeHeight { get; set; } = 60;
    
    /// <summary>
    /// background color of nodes
    /// </summary>
    [JsonPropertyName("nodeBGColor")]
    public string NodeBGColor { get; set; } = "#FFFFFF";
    
    /// <summary>
    /// background color of nodes on hover
    /// </summary>
    [JsonPropertyName("nodeBGColorHover")]
    public string NodeBGColorHover { get; set; } = "#FFFFFF";
    
    /// <summary>
    /// border width of nodes (in pixels)
    /// </summary>
    [JsonPropertyName("borderWidth")]
    public int BorderWidth { get; set; } = 1;
    
    /// <summary>
    /// border style of nodes (solid, dashed, dotted, etc.)
    /// </summary>
    [JsonPropertyName("borderStyle")]
    public string BorderStyle { get; set; } = "solid";
    
    /// <summary>
    /// border radius of nodes (e.g., "5px")
    /// </summary>
    [JsonPropertyName("borderRadius")]
    public string BorderRadius { get; set; } = "5px";
    
    /// <summary>
    /// border color of nodes
    /// </summary>
    [JsonPropertyName("borderColor")]
    public string BorderColor { get; set; } = "#BCBCBC";
    
    /// <summary>
    /// border color of nodes on hover
    /// </summary>
    [JsonPropertyName("borderColorHover")]
    public string BorderColorHover { get; set; } = "#5C6BC0";
    
    /// <summary>
    /// custom CSS class name for nodes
    /// </summary>
    [JsonPropertyName("nodeClassName")]
    public string? NodeClassName { get; set; }
    
    /// <summary>
    /// custom inline styles for nodes
    /// </summary>
    [JsonPropertyName("nodeStyle")]
    public string? NodeStyle { get; set; }
    
    // ========== Edge Options ==========
    
    /// <summary>
    /// width of edges connecting nodes (in pixels)
    /// </summary>
    [JsonPropertyName("edgeWidth")]
    public int EdgeWidth { get; set; } = 1;
    
    /// <summary>
    /// color of edges
    /// </summary>
    [JsonPropertyName("edgeColor")]
    public string EdgeColor { get; set; } = "#BCBCBC";
    
    /// <summary>
    /// color of edges when highlighted
    /// </summary>
    [JsonPropertyName("edgeColorHover")]
    public string EdgeColorHover { get; set; } = "#BCBCBC";
    
    // ========== Font Options ==========
    
    /// <summary>
    /// font size for node text (e.g., "14px")
    /// </summary>
    [JsonPropertyName("fontSize")]
    public string FontSize { get; set; } = "14px";
    
    /// <summary>
    /// font family for node text
    /// </summary>
    [JsonPropertyName("fontFamily")]
    public string? FontFamily { get; set; }
    
    /// <summary>
    /// font weight for node text (e.g., "400", "bold")
    /// </summary>
    [JsonPropertyName("fontWeight")]
    public string FontWeight { get; set; } = "400";
    
    /// <summary>
    /// font color for node text
    /// </summary>
    [JsonPropertyName("fontColor")]
    public string FontColor { get; set; } = "#000000";
    
    // ========== Interaction Options ==========
    
    /// <summary>
    /// enable/disable node highlighting on hover
    /// </summary>
    [JsonPropertyName("highlightOnHover")]
    public bool HighlightOnHover { get; set; } = true;
    
    /// <summary>
    /// enable/disable zoom and export toolbar
    /// </summary>
    [JsonPropertyName("enableToolbar")]
    public bool EnableToolbar { get; set; } = false;
    
    /// <summary>
    /// enable/disable expand/collapse functionality
    /// </summary>
    [JsonPropertyName("enableExpandCollapse")]
    public bool EnableExpandCollapse { get; set; } = false;
    
    // ========== Tooltip Options ==========
    
    /// <summary>
    /// enable/disable tooltips on node hover
    /// </summary>
    [JsonPropertyName("enableTooltip")]
    public bool EnableTooltip { get; set; } = false;
    
    /// <summary>
    /// tooltip container element id
    /// </summary>
    [JsonPropertyName("tooltipId")]
    public string TooltipId { get; set; } = "apextree-tooltip-container";
    
    /// <summary>
    /// maximum width of tooltip (in pixels)
    /// </summary>
    [JsonPropertyName("tooltipMaxWidth")]
    public int TooltipMaxWidth { get; set; } = 100;
    
    /// <summary>
    /// border color of tooltip
    /// </summary>
    [JsonPropertyName("tooltipBorderColor")]
    public string TooltipBorderColor { get; set; } = "#BCBCBC";
    
    /// <summary>
    /// background color of tooltip
    /// </summary>
    [JsonPropertyName("tooltipBGColor")]
    public string TooltipBGColor { get; set; } = "#FFFFFF";
    
    // ========== Leaf Node Options ==========
    
    /// <summary>
    /// enable grouping of leaf nodes (stacking)
    /// </summary>
    [JsonPropertyName("groupLeafNodes")]
    public bool GroupLeafNodes { get; set; } = false;
    
    /// <summary>
    /// spacing between grouped leaf nodes (in pixels)
    /// </summary>
    [JsonPropertyName("groupLeafNodesSpacing")]
    public int GroupLeafNodesSpacing { get; set; } = 10;
    
    // ========== Container Options ==========
    
    /// <summary>
    /// CSS class name for the root container
    /// </summary>
    [JsonPropertyName("containerClassName")]
    public string ContainerClassName { get; set; } = "root";
    
    /// <summary>
    /// inline CSS styles for the canvas container
    /// </summary>
    [JsonPropertyName("canvasStyle")]
    public string? CanvasStyle { get; set; }
    
    /// <summary>
    /// key name in data object that contains the display content
    /// </summary>
    [JsonPropertyName("contentKey")]
    public string ContentKey { get; set; } = "name";
    
    // ========== Advanced Options ==========
    
    /// <summary>
    /// viewport width for zooming/panning
    /// </summary>
    [JsonPropertyName("viewPortWidth")]
    public int? ViewPortWidth { get; set; }
    
    /// <summary>
    /// viewport height for zooming/panning
    /// </summary>
    [JsonPropertyName("viewPortHeight")]
    public int? ViewPortHeight { get; set; }
}
