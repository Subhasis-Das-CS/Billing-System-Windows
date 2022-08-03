using Anystore.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anystore.DAL
{
    class gstinDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;





        #region METHOD TO GET PRODUCT ID BASED ON PRODUCT NAME
        public gstinBll GetProductIDFromName(int ProductName)
        {
            //First Create an Object of DeaCust BLL and REturn it
            gstinBll p = new gstinBll();

            //SQL Conection here
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Data TAble to Holdthe data temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Get id based on Name
                string sql = "SELECT gstin,phone,name,address,tagline,website FROM tbl_gst WHERE id='" + ProductName + "'";
                //Create the SQL Data Adapter to Execute the Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                //Passing the CAlue from Adapter to DAtatable
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                  
                    p.gstin = dt.Rows[0]["gstin"].ToString();
                    p.phone = dt.Rows[0]["phone"].ToString();
                    p.name = dt.Rows[0]["name"].ToString();
                    p.tagline = dt.Rows[0]["tagline"].ToString();
                    p.address = dt.Rows[0]["address"].ToString();
                    p.website = dt.Rows[0]["website"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return p;
        }
        #endregion





        #region get gst no. from table

        public bool Insert(gstinBll g)
        {


            bool isSuccess = false;


            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //query to add new catagory

                string sql = "INSERT INTO tbl_gst (id, gstin, phone, name, tagline, address, website) VALUES(@id, @gstin,@phone, @name, @tagline, @address, @website)";

                //pass values

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@gstin",g.gstin);
                cmd.Parameters.AddWithValue("@id", g.id);
                cmd.Parameters.AddWithValue("@phone", g.phone);
                cmd.Parameters.AddWithValue("@name", g.name);
                cmd.Parameters.AddWithValue("@tagline", g.tagline);
                cmd.Parameters.AddWithValue("@address", g.address);
                cmd.Parameters.AddWithValue("@website", g.website);
                conn.Open();

                //int var to execute query
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Please Update The Existing Data");

            }
            finally
            {
                conn.Close();
            }







            return isSuccess;


        }









        #endregion

        #region Select Method

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_gst";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();

            }
            return dt;
        }

        #endregion
        #region Update Data

        public bool Update(gstinBll g)
        {

            bool isSuccess = false;



            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "UPDATE tbl_gst SET gstin=@gstin, phone=@phone, name=@name, tagline=@tagline, address=@address, website=@website WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@gstin", g.gstin);
                cmd.Parameters.AddWithValue("@id", g.id);
                cmd.Parameters.AddWithValue("@phone", g.phone);
                cmd.Parameters.AddWithValue("@name", g.name);
                cmd.Parameters.AddWithValue("@tagline", g.tagline);
                cmd.Parameters.AddWithValue("@address", g.address);
                cmd.Parameters.AddWithValue("@website", g.website);


                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {

                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return isSuccess;

        }

        #endregion


     
        #region Delete Product

        public bool Delete()
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM tbl_gst";
                SqlCommand cmd = new SqlCommand(sql, conn);


                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return isSuccess;
        }


        #endregion
    }




   

    



}
