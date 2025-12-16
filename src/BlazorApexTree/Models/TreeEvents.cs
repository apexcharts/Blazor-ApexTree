namespace BlazorApexTree.Models;

/// <summary>
/// event arguments for node click events
/// </summary>
public class NodeClickEventArgs : EventArgs
{
    /// <summary>
    /// id of the clicked node
    /// </summary>
    public string NodeId { get; set; } = string.Empty;
    
    /// <summary>
    /// timestamp when the click occurred
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// event arguments for node hover events
/// </summary>
public class NodeHoverEventArgs : EventArgs
{
    /// <summary>
    /// id of the hovered node
    /// </summary>
    public string NodeId { get; set; } = string.Empty;
    
    /// <summary>
    /// timestamp when the hover occurred
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// event arguments for layout change events
/// </summary>
public class LayoutChangeEventArgs : EventArgs
{
    /// <summary>
    /// new layout direction
    /// </summary>
    public TreeDirection Direction { get; set; }
    
    /// <summary>
    /// timestamp when the layout changed
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// event arguments for node expand events
/// </summary>
public class NodeExpandEventArgs : EventArgs
{
    /// <summary>
    /// id of the expanded node
    /// </summary>
    public string NodeId { get; set; } = string.Empty;
    
    /// <summary>
    /// timestamp when the expansion occurred
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// event arguments for node collapse events
/// </summary>
public class NodeCollapseEventArgs : EventArgs
{
    /// <summary>
    /// id of the collapsed node
    /// </summary>
    public string NodeId { get; set; } = string.Empty;
    
    /// <summary>
    /// timestamp when the collapse occurred
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
