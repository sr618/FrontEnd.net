using proj0.Models;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proj0.DAL
{
    public class DAL_Category : DAL_HELP
    {
        public List<CategoryModel> GetallCategories()
        {
            string conStr = "Data Source=localhost;Initial Catalog=proj_Auction;Persist Security Info=True;User ID=sa;Password=Tasky12345;";

            //get all categories from the database 
            List<CategoryModel> categories = new List<CategoryModel>();
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conStr);
                DbCommand cmd = sqlDB.GetStoredProcCommand("spGetCategories");
                using (IDataReader reader = sqlDB.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        CategoryModel category = new CategoryModel();
                        category.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                        category.Name = reader["Name"].ToString();
                        category.Description = reader["Description"].ToString();
                        category.Image = reader["Image"].ToString();
                        category.Modified = reader["Modified"].ToString();
                        category.Created = reader["Created"].ToString();
                        categories.Add(category);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                throw ex;
            }

            return categories;
        }
    }
}
