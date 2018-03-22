using System;

namespace GetHired.DomainModels.Contracts
{
    public interface IModificationHistory
    {
        DateTime DateModified { get; set; }
        DateTime DateCreated { get; set; }
    }
}