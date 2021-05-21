using ApprenticeTipsService.ApiKeyAuth;
using ApprenticeTipsService.Classes;
using ApprenticeTipsService.Models;
using ApprenticeTipsService.RequestResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprenticeTipsService.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class ApprenticeshipController : ControllerBase
    {
        [HttpPost("AddDetailsToDB")]
        public void AddAADetailsToDB(DetailAdderRequest request)
        {
            var DBinserter = new DatabaseInserter();

            int currentId = DBinserter.InsertData("email, firstname, surname, phone, previous_level, comments", $"{request.Contact.EmailAddress}', '{request.Contact.FirstName}', '{request.Contact.Surname}', '{request.Contact.ContactNumber}', '{request.Contact.Qualification}', '{request.Contact.Comment}", "Contact", "webform");
            DBinserter.InsertCheckboxData(request, currentId);

        }

        [HttpPost("GetApprenticeships")]
        public ApprenticeshipFinderResponse GetApprenticeships(ApprenticeshipFinderRequest request)
        {
            var response = new ApprenticeshipFinderResponse();
            var retriever = new DatabaseRetriever();

            response.Apprenticeships = retriever.GetMultipleApprenticeships(request);

            return response;
        }

    }
}
