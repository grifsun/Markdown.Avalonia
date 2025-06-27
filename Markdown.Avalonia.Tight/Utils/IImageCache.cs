// Decompiled with JetBrains decompiler
// Type: Markdown.Avalonia.Utils.IImageCache
// Assembly: Markdown.Avalonia, Version=11.0.5.0, Culture=neutral, PublicKeyToken=null
// MVID: AEC047A6-F407-4F53-BA94-D37C8A888AE1
// Assembly location: F:\dev\markdown\Markdown.Avalonia.dll

using Avalonia.Media;

#nullable enable
namespace Markdown.Avalonia.Utils
{
  public interface IImageCache
  {
    void Invalidate();

    bool TryGetValue(string key, out IImage? image);

    IImage? this[string key] { get; set; }
  }
}
