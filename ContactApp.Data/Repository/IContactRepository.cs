using ContactApp.Data.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Data.Repository
{
    public interface IContactRepository : IRepository<TblContact>
    {
        public TblContact Update(int id, TblContact record);
    }
}
