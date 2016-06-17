using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Up_load : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["upload"]; //获取上传的文件
            if (file == null)
                return;
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); //将文件名设置成guid值，避免重复
            string filepath = "../upload_files/" + filename; //生成文件路径
            //filename = GetMD5HashFromFile(file);
            string manpath = Server.MapPath(filepath); //用context.Server.MapPath()生成绝对路径

            try
            {
                file.SaveAs(manpath); //保存文件，SaveAs()方法需要绝对路径
            }
            catch (Exception ex)
            {
                filename = null;
                Response.Write(ex.Message);
                return;
            }
            use_change.Executechange("insert into F_address(Address) values(@Address)", new SqlParameter("@Address", filepath));
            Response.Write("上传成功");       
        }
    }
}