using System.Runtime.InteropServices;
using ShowMeTheXaml.Avalonia.AvaloniaEdit;

namespace AvaloniaDemo.Styles;

public class CustomXamlDisplayAvaloniaEditThemeBehavior : XamlDisplayAvaloniaEditThemeBehavior {
    protected override void OnAttachedToVisualTree() {
        if (RuntimeInformation.ProcessArchitecture == Architecture.Wasm) {
            return;
        }
        base.OnAttachedToVisualTree();
    }

    protected override void OnDetachedFromVisualTree() {
        if (RuntimeInformation.ProcessArchitecture == Architecture.Wasm) {
            return;
        }
        base.OnDetachedFromVisualTree();
    }
}