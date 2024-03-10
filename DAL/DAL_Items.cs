using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using proj0.Models;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace proj0.DAL
{
    public class DAL_Items : DAL_HELP
    {
        string conStr = "Data Source=localhost;Initial Catalog=proj_Auction;Persist Security Info=True;User ID=sa;Password=Tasky12345;";

        public int setData(ItemModel mdl,DbCommand cmd)
        {
            try
            {
                //add parameters to the command object
                cmd.Parameters.Add(new SqlParameter("@Title", mdl.Title));
                cmd.Parameters.Add(new SqlParameter("@Description", mdl.Description));
                cmd.Parameters.Add(new SqlParameter("@Condition", mdl.Condition));
                cmd.Parameters.Add(new SqlParameter("@CategoryID", mdl.CategoryID));
                cmd.Parameters.Add(new SqlParameter("@ReservePrice", mdl.ReservePrice));
                cmd.Parameters.Add(new SqlParameter("@FinalPrice", mdl.FinalPrice));
                cmd.Parameters.Add(new SqlParameter("@Photos", mdl.Photos));
                cmd.Parameters.Add(new SqlParameter("@Status", mdl.Status));
                cmd.Parameters.Add(new SqlParameter("@UserName", mdl.UserName));
                cmd.Parameters.Add(new SqlParameter("@Created", mdl.Created));
                cmd.Parameters.Add(new SqlParameter("@Modified", mdl.Modified));
                return 1;


            }
            catch (Exception ex)
            {
               return 0 ;
            }

        }
        public List<ItemModel> GetItems()
        {

      
            List<ItemModel> items = new List<ItemModel>();
            SqlDatabase sqlDB = new SqlDatabase(conStr);
            DbCommand cmd = sqlDB.GetStoredProcCommand("GetMST_Item");
            using (IDataReader dr = sqlDB.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    ItemModel item = new ItemModel();
                            item.ItemID = Convert.ToInt32(dr["ItemID"]);
                            item.Title = dr["Title"].ToString();
                            item.Description = dr["Description"].ToString();
                            item.Condition = dr["Condition"].ToString();
                            item.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                            item.Name = dr["CategoryName"].ToString();
                            item.ReservePrice = Convert.ToDecimal(dr["ReservePrice"]);
                            item.FinalPrice = dr["FinalPrice"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(dr["FinalPrice"]);
                            item.Photos = dr["Photos"].ToString();
                            item.Status = Convert.ToBoolean(dr["Status"]);
                            item.UserName = dr["UserName"].ToString();
                            item.Created = dr["Created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Created"]);
                            item.Modified = dr["Modified"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["Modified"]);
                            item.Sold = Convert.ToBoolean(dr["Sold"]);
                            item.userID = Convert.ToInt32(dr["userID"]);
                            items.Add(item);
                 }
    
            }
            return items;
        }

        public int AddItem(ItemModel item)
        {
        
            SqlDatabase sqlDB = new SqlDatabase(conStr);
            DbCommand cmd = sqlDB.GetStoredProcCommand("AddMST_Item");
            cmd.CommandType = CommandType.StoredProcedure;
            setData(item, cmd);
            int result = sqlDB.ExecuteNonQuery(cmd);
            return result;
        }

    }
}
