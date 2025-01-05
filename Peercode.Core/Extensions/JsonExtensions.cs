using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Peercode.Core.Extensions;

public static class JsonExtensions
{
    public static T? FromJson<T>(this string str)
    {
        if (str == null) return default;
        return JsonSerializer.Deserialize<T>(str);
    }

    public static string? ToJson<T>(this T obj)
    {
        if (obj == null) return null;
        return JsonSerializer.Serialize<T>(obj);
    }
}
