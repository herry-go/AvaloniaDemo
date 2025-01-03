﻿using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using SukiDemo.Utilities;

namespace SukiDemo.Converters;

public sealed class StringToControlConverter : IValueConverter
{
    public static readonly StringToControlConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string xamlCode) return null;
        if (string.IsNullOrWhiteSpace(xamlCode)) return null;

        var previewCode = XamlData.InsertIntoGridControl(xamlCode);

        try
        {
            return AvaloniaRuntimeXamlLoader.Parse<Grid>(previewCode);
        }
        catch
        {
            return null;
        }
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}