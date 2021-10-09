using ContactApp.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactApp.Data.Repository
{
    class ContactRepository : Repository<TblContact>, IContactRepository
    {
        ContactAppContext _context;
        public ContactRepository(ContactAppContext context) : base(context)
        {
            _context = context;
        }

        public TblContact Update(int id, TblContact record)
        {
            TblContact objContact = _context.TblContacts.FirstOrDefault(x => x.Id == id);
            if(objContact != null)
            {
                objContact.FirstName = record.FirstName;
                objContact.LastName = record.LastName;
                objContact.PhoneNumber = record.PhoneNumber;
                objContact.Status= record.Status;
                objContact.EmailId = record.EmailId;

                //_context.TblContacts.Add(objContact);
                _context.SaveChanges();
            }

            return objContact;
        }
    }
}
