namespace Web.Common.Validation
{
    public interface IModelValidator
    {
        bool IsValidData(object _object, object[] _parentObjects = null);
        void UpdateData(object _object);

    }
}