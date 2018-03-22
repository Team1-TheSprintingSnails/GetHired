using System;

namespace GetHired.DomainModels.Contracts
{
    public interface IModificationHistory
    {
        DateTime DataModified { get; set; }
        DateTime DataCreated { get; set; }
    }
}