namespace ExpenseTrackApp.CommonServices
{
    public interface IModelDataAnnotationCheck
    {
        void ValidateModel<TDomainModel>(TDomainModel domainModel);
    }
}