namespace Products.Common.Exceptions
{
  public class RecordNotFoundException : Exception
  {
    public RecordNotFoundException(string name) : base(name)
    {
    }
  }
}
