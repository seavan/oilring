namespace Web.Common.Validation.Parsers
{
    public abstract class RegisteredParser<T> : ICustomParser
    {
        public abstract bool TryParse(object _value, out object _result);
        public RegisteredParser()
        {
            //CustomValidatorRepository.INST.AddParser(typeof(T), this);
        }
    }
}