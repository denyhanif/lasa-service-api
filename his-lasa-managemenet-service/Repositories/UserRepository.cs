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
    public class UserRepository : DatabaseConfig, IUserRepository
    {
        public UserRepository() : base()
        { }

        public UserRepository(DatabaseContext Context) : base(Context)
        { }

       

       
        public IEnumerable<ViewLogin> GetData_user_login_SP(ParamLogin paramlogin)
        {
            IEnumerable<ViewLogin> data;
            //List<ViewLogin>  data = new List<ViewLogin>();
            //DataTable dt = new DataTable();
            try
            {
                    using (SqlConnection conn = new SqlConnection("Server=DESKTOP-6KAQFON\\SQLEXPRESS;Database=HIS_LASA;User id=sa;Password=sapassword;"))
                    {
                        var hashPassword = EncryptDecrypt.Encrypt(paramlogin.password);
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "spLogin_username_password";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("username", paramlogin.user_name));
                        cmd.Parameters.Add(new SqlParameter("password", hashPassword));


                    using (var reader = cmd.ExecuteReader())
                    {
                        data = reader.MapToList<ViewLogin>();
                    }

                    //using ( var da = new SqlDataAdapter(cmd))
                    //{
                    //    da.Fill(dt);
                    //}
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
                //throw new Exception("Username atau password salah");
            }

            return data;
        }
    }
}

