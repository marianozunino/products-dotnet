using System.Text.Json;

namespace Products.Common.Dtos
{
  public class ErrorResponseDto
  {
    public List<ErrorDto> Errors { get; set; } = new();
    public int StatusCode { get; set; }

    public override string ToString()
    {
      return JsonSerializer.Serialize(this);
    }
  }

  public class ErrorDto
  {
    public ErrorDto(string property, string error)
    {
      Property = property;
      Error = error;
    }

    public string Property { get; set; }
    public string Error { get; set; }
  }
}
