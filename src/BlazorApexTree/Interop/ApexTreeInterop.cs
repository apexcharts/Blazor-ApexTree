using Microsoft.JSInterop;
using System.Text.Json;

namespace BlazorApexTree.Interop;

/// <summary>
/// handles JavaScript interop for ApexTree operations
/// </summary>
public class ApexTreeInterop : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private bool _disposed = false;

    /// <summary>
    /// initializes a new instance of the ApexTreeInterop class
    /// </summary>
    /// <param name="jsRuntime">the JavaScript runtime instance</param>
    public ApexTreeInterop(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// initialize the ApexTree component
    /// </summary>
    /// <param name="elementId">container element id</param>
    /// <param name="options">tree configuration options</param>
    /// <param name="dotNetRef">reference to component for callbacks</param>
    public async Task<bool> InitializeAsync<T>(string elementId, object options, DotNetObjectReference<T> dotNetRef) where T : class
    {
        try
        {
            return await _jsRuntime.InvokeAsync<bool>("blazorApexTree.init", elementId, options, dotNetRef);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error initializing ApexTree: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// render the tree with provided data
    /// </summary>
    /// <param name="elementId">container element id</param>
    /// <param name="data">tree data structure</param>
    /// <param name="options">tree configuration options</param>
    public async Task<bool> RenderAsync(string elementId, object data, object options)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<bool>("blazorApexTree.render", elementId, data, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error rendering ApexTree: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// set the ApexTree license key
    /// </summary>
    /// <param name="licenseKey">commercial license key</param>
    public async Task<bool> SetLicenseAsync(string licenseKey)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<bool>("blazorApexTree.setLicense", licenseKey);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error setting license: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// change the tree layout direction
    /// </summary>
    /// <param name="elementId">container element id</param>
    /// <param name="direction">new direction (top, bottom, left, right)</param>
    public async Task<bool> ChangeLayoutAsync(string elementId, string direction)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<bool>("blazorApexTree.changeLayout", elementId, direction);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error changing layout: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// expand a specific node
    /// </summary>
    /// <param name="elementId">container element id</param>
    /// <param name="nodeId">id of the node to expand</param>
    public async Task<bool> ExpandAsync(string elementId, string nodeId)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<bool>("blazorApexTree.expand", elementId, nodeId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error expanding node: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// collapse a specific node
    /// </summary>
    /// <param name="elementId">container element id</param>
    /// <param name="nodeId">id of the node to collapse</param>
    public async Task<bool> CollapseAsync(string elementId, string nodeId)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<bool>("blazorApexTree.collapse", elementId, nodeId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error collapsing node: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// fit the tree to screen
    /// </summary>
    /// <param name="elementId">container element id</param>
    public async Task<bool> FitScreenAsync(string elementId)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<bool>("blazorApexTree.fitScreen", elementId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fitting to screen: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// destroy the tree instance and cleanup
    /// </summary>
    /// <param name="elementId">container element id</param>
    public async Task<bool> DestroyAsync(string elementId)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<bool>("blazorApexTree.destroy", elementId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error destroying tree: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// disposes the interop resources asynchronously
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;
        _disposed = true;
        
        // no module to dispose since we're using global object
        await Task.CompletedTask;
    }
}