
namespace DashboardAutomation.Shared;

[DebuggerDisplay("{Code} - {Message}")]
public class Error : IEquatable<Error>
{
  public Error(string code, string message)
  {
    Code = code;
    Message = message;
  }

  public string Code { get; }
  public string Message { get; }


  public static implicit operator string(Error error) => error.ToString();

  public static Error NullValue => new("Null-Value", "The object must has value but it is null");

  public static bool operator ==(Error? first, Error? second) => first?.Code == second?.Code;
  public static bool operator !=(Error? first, Error? second) => first?.Code != second?.Code;

  public bool Equals(Error? error)
    => Code == error?.Code;

  public override bool Equals(object? obj)
    => obj is Error error && error is not null && this.Code == error.Code;

  public override int GetHashCode()
    => Code.GetHashCode() * 26;

  public override string ToString()
    => $"{Code}: {Message}";
}
