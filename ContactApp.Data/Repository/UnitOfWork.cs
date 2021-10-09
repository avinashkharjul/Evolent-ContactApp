using ContactApp.Data.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        ContactAppContext _context;
        public UnitOfWork(ContactAppContext context)
        {
            _context = context;
            ContactRepo = new ContactRepository(_context);
        }

        public IContactRepository ContactRepo { get; private set; }


        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
