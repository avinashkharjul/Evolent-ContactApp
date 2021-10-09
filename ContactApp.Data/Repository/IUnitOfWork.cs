using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        
        IContactRepository ContactRepo { get; }
        int SaveChanges();
    }
}
