using ApprenticeTipsService.ApiKeyAuth;
using ApprenticeTipsService.Classes;
using ApprenticeTipsService.RequestResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApprenticeTipsService.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class ApprenticeshipController : ControllerBase
    {
        [HttpPost("AddContactDetailsToDB")]
        public void AddContactDetailsToDB(DetailAdderRequest request)
        {
            var DBinserter = new DatabaseInserter();

            int currentId = DBinserter.InsertData("email, firstname, surname, phone, previous_level, comments", $"{request.Contact.EmailAddress}', '{request.Contact.FirstName}', '{request.Contact.Surname}', '{request.Contact.ContactNumber}', '{request.Contact.Qualification}', '{request.Contact.Comment}", "Contact", "webform");
            DBinserter.InsertCheckboxData(request, currentId);

        }
    }
}
