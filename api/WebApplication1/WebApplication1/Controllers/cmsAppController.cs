using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cmsAppController : ControllerBase
    {
        private IConfiguration _configuration;
        public cmsAppController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public JsonResult GetCustomers()
        {

            string query = "select * from dbo.Customers";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("cmsAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon=new SqlConnection(sqlDatasource))
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
        [HttpPost]
        [Route("AddCustomer")]
        public JsonResult AddCustomer([FromForm] string newCustomer , [FromForm] string newCustomerEmail , [FromForm] string newCustomerPhone)
        {

            string query = "insert into dbo.Customers(name, email, phone) values(@newCustomer, @newCustomerEmail, @newCustomerPhone) ";

            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("cmsAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@newCustomer", newCustomer);
                    myCommand.Parameters.AddWithValue("@newCustomerEmail", newCustomerEmail);
                    myCommand.Parameters.AddWithValue("@newCustomerPhone", newCustomerPhone);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Customer Successfully");
        }
        [HttpDelete]
        [Route("DeleteCustomer")]
        public JsonResult DeleteCustomer(int id)
        {

            string query = "delete from dbo.Customers where id=@id";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("cmsAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Customer Successfully");
        }
    }
}
