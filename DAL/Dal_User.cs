using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using proj0.Models;
using System.Data;
using System.Data.Common;

namespace proj0.DAL
{
    public class Dal_User 
    {
        //get all user in list from database
        string conStr = "Data Source=localhost;Initial Catalog=proj_Auction;Persist Security Info=True;User ID=sa;Password=Tasky12345;";

        public List<UserModel> GetAllUsers()
        {
            SqlDatabase
                sqlDB = new SqlDatabase(conStr);
            DbCommand cmd = sqlDB.GetStoredProcCommand("spGetAllUsers");
            List<UserModel> users = new List<UserModel>();
            using (IDataReader reader = sqlDB.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    UserModel user = new UserModel();
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                     user.Image = reader["Image"].ToString();
                    user.Modified = reader["Modified"].ToString();
                    user.Created = reader["Created"].ToString();
                    user.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                    user.address = reader["address"].ToString();
                    user.Pincode = Convert.ToInt32(reader["Pincode"]);
                    users.Add(user);
                }
            }
            return users;
         }

        public int AddUser(UserModel mdl)
        {
            SqlDatabase sqlDB = new SqlDatabase(conStr);
            DbCommand cmd = sqlDB.GetStoredProcCommand("spAddUser");
            sqlDB.AddInParameter(cmd, "@UserName", DbType.String, mdl.UserName);
            sqlDB.AddInParameter(cmd, "@Password", DbType.String, mdl.Password);
            sqlDB.AddInParameter(cmd, "@Image", DbType.String, mdl.Image);
            sqlDB.AddInParameter(cmd, "@IsActive", DbType.Boolean, mdl.IsActive);
            sqlDB.AddInParameter(cmd, "@IsAdmin", DbType.Boolean, mdl.IsAdmin);
            sqlDB.AddInParameter(cmd, "@Pincode", DbType.Int32, mdl.Pincode);
            sqlDB.AddInParameter(cmd, "@Address", DbType.String, mdl.address);
            sqlDB.AddInParameter(cmd, "@Email", DbType.String, mdl.Email);

         int res =   sqlDB.ExecuteNonQuery(cmd);
            return res;
        }
    }
}
