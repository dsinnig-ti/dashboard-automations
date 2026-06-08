

namespace DashboardAutomation.Common
{
  public static class ObjectExtensions
  {
    public static T FillBy<T>(this T output, object input)
    {
      if (output is null || input is null)
        throw new InvalidOperationException("Input or output cannot be null");

      var propertyInfoInput = input.GetType().GetProperties();
      var propertyInfoOutput = output.GetType().GetProperties();
      foreach (var property in propertyInfoOutput)
      {
        if (property.CanWrite)
        { continue; }

        try
        {
          var propertyIn = propertyInfoInput.FirstOrDefault(x => x.Name.Equals(property.Name));
          if (propertyIn is null)
          { continue; }
          if (property.PropertyType != propertyIn.PropertyType)
          { continue; }

          property.SetValue(output, propertyIn.GetValue(input));
        }
        catch { }
      }

      return output;
    }

    public static string GetEnumMember(this Enum @enum)
        => (@enum.GetType()
                ?.GetField(@enum.ToString())
                ?.GetCustomAttributes(typeof(EnumMemberAttribute), false) as EnumMemberAttribute[])
                ?.FirstOrDefault()?.Value ?? @enum.ToString();

    public static T Clone<T>(this object obj)
        => Activator.CreateInstance<T>().FillBy(obj);

    public static T Clone<T>(this T obj) where T : notnull
        => Activator.CreateInstance<T>().FillBy(obj);

    public static string Join(this IEnumerable<string> collection, string separator = ", ")
        => string.Join(separator, collection);

    public static string ToString(this decimal number, int decimalPoints)
    {
      decimalPoints++;
      var zeros = "0.";
      for (int i = 0; i < decimalPoints; i++)
        zeros += "0";

      var str = number.ToString(zeros);
      var dotIndex = str.IndexOf('.');
      if (dotIndex + decimalPoints > str.Length || dotIndex == -1)
        return str;

      return str[..(dotIndex + decimalPoints)];
    }

    public static object TypeDescription(this Type type)
    {
      var properties = type.GetProperties();
      var info = new Dictionary<string, object>();
      foreach (var property in properties)
        info[property.Name] = property.PropertyType.Name;

      return type.IsArray ? new[] { info } : info;
    }

    public static string ToPersianDate(this DateTime date)
    {
      if (date == DateTime.MinValue)
        return "0001-01-01";

      var pc = new PersianCalendar();

      return $"{pc.GetYear(date):0000}-{pc.GetMonth(date):00}-{pc.GetDayOfMonth(date):00}";
    }

    public static string ToPersianDigit(this string inputString)
    {
      string[] persianDigits = CultureInfo.GetCultureInfo("fa-IR").NumberFormat.NativeDigits;
      var persianDigitBuilder = new StringBuilder();
      foreach (char c in inputString)
      {
        if (char.IsDigit(c))
          persianDigitBuilder.Append(persianDigits[int.Parse(c.ToString())]);
        else
          persianDigitBuilder.Append(c);
      }
      return persianDigitBuilder.ToString();
    }

    public static string TextNormalization(this string text)
    {
      var upperCaseCount = text.Count(x => char.IsUpper(x));
      if (upperCaseCount < 2)
        return text;

      var textBuffer = string.Empty;
      foreach (var chr in text)
      {
        if (string.IsNullOrEmpty(textBuffer))
        {
          textBuffer += chr;
          continue;
        }

        if (!char.IsUpper(textBuffer.Last()) && char.IsLetterOrDigit(textBuffer.Last()) && char.IsUpper(chr))
          textBuffer += " " + chr;
        else
          textBuffer += chr;
      }

      return textBuffer;
    }

  }
}
