using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using HastaneWebAPI.Models;
using System.Data.SqlClient;
using System.Data;

namespace HastaneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertiseController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ExpertiseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("{expertise}")]
        public JsonResult GetExpertise()
        {
            string query = @"select ExpertiseID,ExpertiseCode,ExpertiseName from dbo.tbl_ExpertiseList";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpGet]
        [Route("{diagnosis}")]
        public JsonResult GetDiagnosis()
        {
            string query = @"select DiagnosisID,DiagnosisCode,DiagnosisName from dbo.tbl_Diagnoses";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
