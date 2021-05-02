using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using HastaneWebAPI.Models;

namespace HastaneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvisionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProvisionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
      
        [HttpGet("complaint")]
       
        public JsonResult GetComplaint()
        {
            string query = @"select OperationID,OperationCode,OperationName from dbo.tbl_Operation";
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
        [HttpGet("diagnosis")]
       
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
        [HttpGet("expertise")]
        
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
        [HttpPost("post")]
        public JsonResult PostProvision(Provision pro)
        {
            try { 
            Random random = new Random();
            var pid = random.Next();
            pro.ProvisionNumber = pid;
                //string doj = pro.ProvisionDate.ToString().Split(' ')[0];
                var parsedDate = DateTime.Parse(pro.ProvisionDate);
                var query = @"insert into dbo.tbl_Provision(TCKN,ProvisionDate,Expertise,Diagnosis,Complaint,Operation,ProvisionNumber) values('" + pro.TCKN + @"','" + pro.ProvisionDate + @"','"+pro.Expertise+@"','"+pro.Diagnosis+@"','"+pro.Complaint+@"','"+pro.Operation+@"','"+pro.ProvisionNumber+@"')";
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
            return new JsonResult("Provizyon Numaranız: "+pro.ProvisionNumber);
            }
            catch(Exception e)
            {
                return new JsonResult(e.Message);
            }
        }
       

    }
}
