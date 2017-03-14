using System;
using System.Data;
using System.Web;

namespace Sign_in.handler
{
    /// <summary>
    /// info 的摘要说明
    /// </summary>
    public class info : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/pand";

            string info = context.Request["info"];

            HttpCookie login = context.Request.Cookies["usr"];
            if (login == null && info != "All")
            {
                context.Response.Write("no login");
                return;
            }

            string max_week = DAL.InfoServer.GetMaxWeek();
          //

            if (info == "you" )
            {
                string week4 = context.Request["week"];
                int week5 =  Convert.ToInt32(max_week)+ Convert.ToInt32(week4);

                DataTable you_info = DAL.InfoServer.GetYourInfon(login.Value,week5);

                string your_info_html = @"<tr>
                        <th class='t3'>开始</th>
                        <th class='t3'>结束</th>
                        <th class='t3'>星期</th>
                        <th class='t3'>时间</th></tr>";

                for (int i = 0; i< you_info.Rows.Count; ++i)
                {
                    int you_time = Convert.ToInt32(you_info.Rows[i]["Today"].ToString());
                    string start = you_info.Rows[i]["start"].ToString();
                    string end = you_info.Rows[i]["Endd"].ToString();
                    DateTime today = Convert.ToDateTime(you_info.Rows[i]["start"].ToString());
                    string week_day = today.GetDateTimeFormats('D')[2].ToString();

                    your_info_html += @"<tr>
                        <td>" + start.Substring(start.Length - 8, 5) + @"</td>
                        <td>" + end.Substring(end.Length - 8, 5) + @"</td>
                        <td>" + week_day.Substring(0, 3) + @"</td>
                        <td>" + (you_time / 60).ToString() + ":" + 
                                ((you_time % 60) > 9 ? (you_time % 60).ToString() 
                                : "0" + (you_time % 60).ToString()) + "</td></tr>";
                }

                context.Response.Write(your_info_html);
            }
            else if (info == "all")
            {
                string week2 = context.Request["week"];
                int week3 = Convert.ToInt32(max_week) + Convert.ToInt32(week2);

                DataTable all_info = DAL.InfoServer.GetAllInfon(week3);

                string all_info_html = @"<tr>
                        <th class='t1'>序号</th>
                        <th class='t2'>学号</th>
                        <th class='t3'>姓名</th>
                        <th class='t4'>在线</th>
                        <th class='t4'>周数</th>
                        <th class='t5'>共签到</th></tr>";

                for (int i = 0; i < all_info.Rows.Count; ++i)
                {
                    string total = all_info.Rows[i]["total"].ToString() == "" ? "0": all_info.Rows[i]["total"].ToString();
                    int week_total = Convert.ToInt32(total);
                    string on = all_info.Rows[i]["on"].ToString() == "1" ? "<front style='color: red;'>是</front>" : "否";

                    all_info_html += (@"<tr>
                        <td>" + (i+1).ToString() + @"</td>
                        <td>" + all_info.Rows[i]["StuId"].ToString() + @"</td>
                        <td>" + all_info.Rows[i]["Name"].ToString() + @"</td>
                        <td>" + on + @"</td>
                        <td>" + week3 + @"</td>
                        <td>" + (week_total / 60).ToString() + ":" +
                                 ((week_total % 60) > 9 ? (week_total % 60).ToString()
                                 : "0" + (week_total % 60).ToString()) + "</td></tr>");
                }

                context.Response.Write(all_info_html);
            }
            else if (info == "All")
            {
                string week0 = context.Request["week"];
                int week1 = Convert.ToInt32(max_week) + Convert.ToInt32(week0);

                DataTable all_detail = DAL.InfoServer.GetAllDetail(week1);

                string all_info_html = @"<tr>
                        <th class='t1'>序号</th>
                        <th class='t2'>学号</th>
                        <th class='t3'>姓名</th>
                        <th class='t3'>开始</th>
                        <th class='t3'>结束</th>
                        <th class='t4'>周数</th>
                        <th class='t4'>星期</th>
                        <th class='t5'>时间</th></tr>";

                int Total = 0;
                for (int i = 0, j = 0; i < all_detail.Rows.Count; ++i, ++j)
                {
                    string start = all_detail.Rows[i]["Start"].ToString();
                    string end = all_detail.Rows[i]["Endd"].ToString();
                    int total = Convert.ToInt32(all_detail.Rows[i]["Today"].ToString());

                    all_info_html += @"<tr>
                        <td>" + (i + 1).ToString() + @"</td>
                        <td>" + all_detail.Rows[i]["StuId"].ToString() + @"</td>
                        <td>" + all_detail.Rows[i]["Name"].ToString() + @"</td>
                        <td>" + start.Substring(start.Length-8, 5) + @"</td>
                        <td>" + end.Substring(end.Length-8, 5) + @"</td>
                        <td>" + all_detail.Rows[i]["Week"].ToString() + @"</td>
                        <td>" + all_detail.Rows[i]["DayOfWeek"].ToString() + @"</td>
                        <td>" + (total / 60).ToString() + ":" +
                                 ((total % 60) > 9 ? (total % 60).ToString()
                                 : "0" + (total % 60).ToString()) + "</td></tr>";
                    Total += total;

                    //判断是否同一个人
                    string a = all_detail.Rows[i]["StuId"].ToString();
                    string b = i >= all_detail.Rows.Count - 1 ? "" : all_detail.Rows[i + 1]["StuId"].ToString();
                    if (a != b)
                    {
                        all_info_html += @"<tr>
                            <td colspan='6' style='background:none;'></td>
                            <td>总共：</td>
                            <td>" + (Total / 60).ToString() + ":" +
                            ((Total % 60) > 9 ? (Total % 60).ToString()
                            : "0" + (Total % 60).ToString()) + "</td></tr>";
                        Total = 0;
                    }
                }

                context.Response.Write(all_info_html);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}