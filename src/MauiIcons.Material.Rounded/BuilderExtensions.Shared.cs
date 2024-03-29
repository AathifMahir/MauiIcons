﻿

namespace MauiIcons.Material.Rounded;
public static class BuilderExtensions
{
    /// <summary>
	/// Initializes the .NET MAUI Icons Library
	/// </summary>
	/// <param name="builder"><see cref="MauiAppBuilder"/> generated by <see cref="MauiApp"/> </param>
	/// <returns><see cref="MauiAppBuilder"/> initialized for <see cref="Material"/></returns>
    /// 
    public static MauiAppBuilder UseMaterialRoundedMauiIcons(this MauiAppBuilder builder)
    {
        return builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(BuilderExtensions).Assembly, Constants.TtfFontFamily, Constants.FontFamily);
        });
    }

    
   
}
