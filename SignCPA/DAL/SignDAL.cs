using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;
using SignCPA.Models;

namespace SignCPA.DAL
{
    public class SignDAL
    {
        public static string connStr = "Data Source=.;Initial Catalog=SignCPA;Integrated Security=True";

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public List<Sign> GetAllSigns()
        {
            var result = new List<Sign>();
            string cmdStr = " SELECT * FROM dbo.[Sign](NOLOCK) ORDER BY ModifyTime DESC ";
            var conn = new SqlConnection(connStr);
            var cmd = new SqlCommand(cmdStr, conn);
            using (conn)
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Sign
                    {
                        ID = Int32.Parse(reader["ID"].ToString()),
                        SignTime =DateTime.Parse(reader["SignTime"].ToString()).ToString("MM月dd号 HH时mm分"),
                        DoneLevel = Int32.Parse(reader["DoneLevel"].ToString()),
                        Content = reader["Content"] == null ? "" : reader["Content"].ToString(),
                        CreateTime = DateTime.Parse(reader["CreateTime"].ToString()).ToString("MM月dd号 HH时mm分"),
                        ModifyTime = DateTime.Parse(reader["ModifyTime"].ToString()).ToString("MM月dd号 HH时mm分"),
                        Color = reader["Color"].ToString()
                    };
                    result.Add(item);
                }
                return result;
            }
        }

        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        public int AddSign(Sign sign)
        {
            try
            {
                var result = 0;
                var sb = new StringBuilder();
                sb.Append(" INSERT INTO dbo.[Sign] ( [SignTime] , [DoneLevel] , [Content] , [CreateTime] , [ModifyTime] ,[Color])");
                sb.Append(" VALUES ( @SignTime , @DoneLevel , @Content , @CreateTime , @ModifyTime ,@Color )");
                var conn = new SqlConnection(connStr);
                var cmd = new SqlCommand(sb.ToString(), conn);
                cmd.Parameters.AddWithValue("@SignTime", sign.SignTime);
                cmd.Parameters.AddWithValue("@DoneLevel", sign.DoneLevel);
                cmd.Parameters.AddWithValue("@Content", sign.Content);
                cmd.Parameters.AddWithValue("@CreateTime", sign.CreateTime);
                cmd.Parameters.AddWithValue("@ModifyTime", sign.ModifyTime);
                cmd.Parameters.AddWithValue("@Color", sign.Color);

                using (conn)
                {
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
                return result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }
}