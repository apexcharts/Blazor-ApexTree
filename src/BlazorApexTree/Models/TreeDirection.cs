namespace BlazorApexTree.Models;

/// <summary>
/// defines the direction in which the tree layout flows
/// </summary>
public enum TreeDirection
{
    /// <summary>
    /// tree flows from top to bottom
    /// </summary>
    Top,
    
    /// <summary>
    /// tree flows from bottom to top
    /// </summary>
    Bottom,
    
    /// <summary>
    /// tree flows from left to right
    /// </summary>
    Left,
    
    /// <summary>
    /// tree flows from right to left
    /// </summary>
    Right
}
