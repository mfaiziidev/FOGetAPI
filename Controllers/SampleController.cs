using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace FOGetAPI.Controllers
{
    public class SampleController : ApiController
    {
        DBConnection db = new DBConnection();
        
        [ActionName("GetFOEntries")]
        [Route("api/FO_API/GetFOEntries")]
        [HttpGet]
        public HttpResponseMessage GetEntries()
        {
            try
            {
                var result = GetEntriesFromDb();
                return Request.CreateResponse(HttpStatusCode.OK, new { result });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
        public List<clsEntries> GetEntriesFromDb()
        {
            try
            {
                List<clsEntries> lst = new List<clsEntries>();
                using (SqlConnection conn = db.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("GetFOEntries"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            clsEntries info = new clsEntries();
                            info.ID = Convert.ToInt32(reader["ID"]);
                            info.Name = reader["Name"].ToString();
                            info.PhnNo = reader["PhnNo"].ToString();
                            info.Email = reader["Email"].ToString();

                            lst.Add(info);
                        }
                        conn.Close();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Exception in GetEntriesFromDb: {ex}");

                // Return a more informative error message
                throw new Exception("An error occurred while fetching data from the database. Please check the logs for details.", ex);
            }
        }
    }
}
