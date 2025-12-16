namespace BlazorApexTree;

/// <summary>
/// manages ApexTree license configuration
/// </summary>
public static class ApexTreeLicense
{
    private static string? _licenseKey;

    /// <summary>
    /// gets the current license key
    /// </summary>
    public static string? LicenseKey => _licenseKey;

    /// <summary>
    /// sets the ApexTree commercial license key
    /// call this method in Program.cs before rendering any trees
    /// </summary>
    /// <param name="licenseKey">your ApexTree commercial license key</param>
    /// <example>
    /// <code>
    /// // in Program.cs
    /// ApexTreeLicense.SetLicense("your-license-key-here");
    /// </code>
    /// </example>
    public static void SetLicense(string licenseKey)
    {
        if (string.IsNullOrWhiteSpace(licenseKey))
        {
            throw new ArgumentException("License key cannot be null or empty", nameof(licenseKey));
        }

        _licenseKey = licenseKey;
    }

    /// <summary>
    /// checks if a license key has been configured
    /// </summary>
    public static bool HasLicense => !string.IsNullOrWhiteSpace(_licenseKey);
}
