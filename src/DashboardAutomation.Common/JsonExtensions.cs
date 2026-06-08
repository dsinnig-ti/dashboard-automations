

namespace DashboardAutomation.Common
{
  public static class JsonExtensions
  {
    public static string Serialize(this object obj)
        => JsonSerializer.Serialize(obj);

    public static string Serialize(this object obj, JsonSerializerOptions options)
        => JsonSerializer.Serialize(obj, options);

    public static T? Deserialize<T>(this string json)
        => JsonSerializer.Deserialize<T>(json);

    public static object? Deserialize(this string json, Type type)
        => JsonSerializer.Deserialize(json, type);

    public static T? Deserialize<T>(this string json, JsonSerializerOptions options)
        => JsonSerializer.Deserialize<T>(json, options);

    public static bool Contains(this JsonDocument document, string property)
        => document.RootElement.TryGetProperty(property, out var v);

    public static bool Contains(this JsonElement element, string property)
        => element.TryGetProperty(property, out var v);

    public static JsonElement Get(this JsonDocument document, string property)
        => document.RootElement.GetProperty(property);

    public static JsonDocument? Add(this JsonElement element, string property, object value)
    {
      if (element.ValueKind != JsonValueKind.Object)
        return null;

      var dic = element.GetRawText().Deserialize<Dictionary<string, object>>()!;
      dic[property] = value;
      return JsonDocument.Parse(dic.Serialize());
    }

    public static JsonDocument ToJsonDocument(this object obj)
        => JsonDocument.Parse(obj.Serialize());

  }
}
