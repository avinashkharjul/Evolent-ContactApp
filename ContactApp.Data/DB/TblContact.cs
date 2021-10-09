using System;
using System.Collections.Generic;

#nullable disable

namespace ContactApp.Data.DB
{
    public partial class TblContact
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedById { get; set; }
    }
}
