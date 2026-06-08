
namespace DashboardsAgent.Shared;

[DebuggerDisplay("{IsSuccess}{IsFailed ? \" - Error:\" + Errors[0] : System.String.Empty}")]
public class Result
{
  private Result(ResultStatus status, params Error[] errors)
  {
    Status = status;
    Errors = errors;
  }

  public bool IsSuccess => Status == ResultStatus.Success;
  public bool IsFailed => !IsSuccess;
  public ResultStatus Status { get; private set; }
  public Error[] Errors { get; private set; }


  public static implicit operator Result(Error error) => new(ResultStatus.Failed, error);
  public static implicit operator Result(Error[] errors) => new(ResultStatus.Failed, errors);
  public static implicit operator Result(bool isSuccess) => isSuccess
    ? Success()
    : throw new InvalidOperationException("A failed result must have at least one error.");

  public static Result Success() => new(ResultStatus.Success);

  public static Result Failed(params Error[] error) => new(ResultStatus.Failed, error);

  public static Result BadRequest(params Error[] errors)
    => new(ResultStatus.BadRequest, errors);

  public static Result NotFound(params Error[] errors)
    => new(ResultStatus.NotFound, errors);

  public static Result Conflict(params Error[] errors)
    => new(ResultStatus.Conflict, errors);

  public static Result Invalid(params Error[] errors)
    => new(ResultStatus.Invalid, errors);

  public static Result Exception(string code, Exception exception)
    => new(ResultStatus.Exception, new Error(code, exception.Message), new Error(code + ".Stack", exception.StackTrace!));
}


[DebuggerDisplay("{IsSuccess} {IsFailed ? \"- Error: \" + Errors[0] : \"Value: \" + Value}")]
public class Result<T>
{
  private Result(T? value) : this(ResultStatus.Success)
  {
    _value = value;
  }

  private Result(ResultStatus status, params Error[] errors)
  {
    Status = status;
    Errors = errors;
    _value = default;
  }

  public bool IsSuccess => Status == ResultStatus.Success;
  public bool IsFailed => !IsSuccess;
  public ResultStatus Status { get; private set; }
  public Error[] Errors { get; private set; }

  private readonly T? _value;
  public T Value => Status == ResultStatus.Success
    ? _value!
    : throw new InvalidOperationException("There is no value of failure result");

  public Result FailureResult()
  {
    if (IsSuccess)
    { throw new InvalidOperationException("There is no failure for success result"); }

    return Status switch
    {
      ResultStatus.BadRequest => Result.BadRequest(Errors),
      ResultStatus.NotFound => Result.NotFound(Errors),
      ResultStatus.Conflict => Result.Conflict(Errors),
      ResultStatus.Invalid => Result.Invalid(Errors),
      _ => Result.Failed(Errors)
    };
  }


  public static implicit operator Result<T>(Error error) => new(ResultStatus.Failed, error);
  public static implicit operator Result<T>(Error[] errors) => new(ResultStatus.Failed, errors);
  public static implicit operator T(Result<T> result) => result.Value;
  public static implicit operator Result<T>(T value) => new(value);
  public static implicit operator Result<T>(Result result) => result.IsFailed
    ? new(result.Status, result.Errors)
    : throw new InvalidOperationException("Simple Result class can't convert to Result<T>.");

  public static Result<T> Success(T value)
    => new(value);
}
