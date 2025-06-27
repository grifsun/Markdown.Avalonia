// Decompiled with JetBrains decompiler
// Type: Markdown.Avalonia.Utils.DefaultImageCache
// Assembly: Markdown.Avalonia, Version=11.0.5.0, Culture=neutral, PublicKeyToken=null
// MVID: AEC047A6-F407-4F53-BA94-D37C8A888AE1
// Assembly location: F:\dev\markdown\Markdown.Avalonia.dll

using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace Markdown.Avalonia.Utils
{
    public class DefaultImageCache : IImageCache
    {
        private readonly Dictionary<string, WeakReference<IImage>> _cache = new();

        public bool TryGetValue(string key, out IImage? image)
        {
            if (_cache.TryGetValue(key, out var weakReference) && weakReference.TryGetTarget(out image))
                return true;
            image = (IImage?)null;
            return false;
        }

        public void Invalidate()
        {
            foreach (string key in _cache.Keys.ToArray<string>())
            {
                if (_cache[key].TryGetTarget(out IImage _))
                    _cache.Remove(key);
            }
        }

        public IImage? this[string key]
        {
            get => !_cache[key].TryGetTarget(out var target) ? (IImage?)null : target;
            set
            {
                if (value == null)
                    return;
                _cache[key] = new WeakReference<IImage>(value);
            }
        }
    }
}
