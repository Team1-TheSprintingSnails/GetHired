using System;

namespace GetHired.DTO.Contracts
{
    public interface IModificationHistory
    {
        DateTime DateModified { get; }
        DateTime DateCreated { get; }
    }
}