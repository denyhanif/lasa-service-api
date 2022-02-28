using his_lasa_managemenet_service.Common;
using his_lasa_managemenet_service.Models;
using his_lasa_managemenet_service.Models.ViewModel;
using his_lasa_managemenet_service.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Repositories
{
    public class LasaRepository : DatabaseConfig, ILasaRepository
    {
        public LasaRepository() : base()
        {

        }

        public LasaRepository(DatabaseContext Context) : base(Context)
        { }

        public IEnumerable<Lasa> GetAllData_Lasa()
        {
            IEnumerable<Lasa> data;
            
            using (SqlConnection connect = new SqlConnection("Server=DESKTOP-6KAQFON\\SQLEXPRESS;Database=HIS_LASA;User id=sa;Password=sapassword;"))
            {
                connect.Open();
                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "spGetData_lasa";
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    data = reader.MapToList<Lasa>();
                }
                connect.Close();
            }

            return data;
        }

        public IEnumerable<Lasa> Search_lasa_byName(string product_name)
        {
            IEnumerable<Lasa> data;
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=DESKTOP-6KAQFON\\SQLEXPRESS;Database=HIS_LASA;User id=sa;Password=sapassword;"))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "spGetData_lasabyName_Search";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("keyword", product_name));

                    using (var reader = cmd.ExecuteReader())
                    {
                        data = reader.MapToList<Lasa>();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            return data;
        }

        public Lasa MapingLasa(Lasa lasa)
        {
           
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=DESKTOP-6KAQFON\\SQLEXPRESS;Database=HIS_LASA;User id=sa;Password=sapassword;"))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "spInsert_NewLasa";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("SalesItemId",lasa.SalesItemId ));
                    cmd.Parameters.Add(new SqlParameter("is_Lasa", lasa.is_lasa));

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    //result = (from DataRow dr in dt.Rows
                    //          select dr["Result"].ToString()).First();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lasa;
        }  

        public UpdateLasa UpdateLasa(int item_id, UpdateLasa updateLasa)
        {
            DataTable dt = new DataTable();
            try {
                using (SqlConnection conn = new SqlConnection("Server=DESKTOP-6KAQFON\\SQLEXPRESS;Database=HIS_LASA;User id=sa;Password=sapassword;"))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "spUpdateData_Lasa";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Id",updateLasa.item_id));
                    cmd.Parameters.Add(new SqlParameter("IsLasa", updateLasa.is_lasa));
                    using ( var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updateLasa;
        }

        public IEnumerable<DataTabelLasa> Tabel_TR_Lasa()
        {
            IEnumerable<DataTabelLasa> data;

            using (SqlConnection connect = new SqlConnection("Server=DESKTOP-6KAQFON\\SQLEXPRESS;Database=HIS_LASA;User id=sa;Password=sapassword;"))
            {
                connect.Open();
                SqlCommand cmd = connect.CreateCommand();
                cmd.CommandText = "spGetData_TRLasa";
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    data = reader.MapToList<DataTabelLasa>();
                }
                connect.Close();
            }
            return data;
        }
    }
}
