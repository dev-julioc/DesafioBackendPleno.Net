namespace MoviesRental.Domain.Validator;
public class DomainValidatorException : Exception
{
    public DomainValidatorException(string error) : base(error)
    { }
    
    public static void When(bool hasError, string message)
    {
        if(hasError)
            throw new DomainValidatorException(message);
    }

}
