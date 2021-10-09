using ContactApp.Data.DB;
using ContactApp.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<TblContact> GetAll()
        {
            return _unitOfWork.ContactRepo.GetAll();
        }

        [HttpGet("{id}")]
        public TblContact Get(int id)
        {
            return _unitOfWork.ContactRepo.GetById(id);
        }

        [HttpPost]
        [Route("CreateContact")]
        public TblContact Post([FromBody]TblContact input)
        {
            _unitOfWork.ContactRepo.Add(input);
            _unitOfWork.SaveChanges();

            return input;
        }

        [HttpPut("{id}")]
        public void Put(int id,TblContact input)
        {
            _unitOfWork.ContactRepo.Update(id,input);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = _unitOfWork.ContactRepo.GetById(id);
            _unitOfWork.ContactRepo.Remove(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
