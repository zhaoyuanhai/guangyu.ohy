using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OHYCommon
{
    public class Common
    {
        public static bool SendEmail(string project, string body)
        {
            MailMessage msg = new MailMessage();
            string[] addressList = ConfigurationManager.AppSettings["toEmails"].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            addressList.ToList().ForEach(email => msg.To.Add(email));
            //msg.To.Add("jieshou@beijingonway.com");//密码 JieShou2017go

            msg.From = new MailAddress("wangzhan@beijingonway.com", "欧华源系统", Encoding.UTF8);

            msg.Subject = project;//邮件标题    
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码    
            msg.Body = body;//邮件内容    
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码    
            msg.IsBodyHtml = true;//是否是HTML邮件    
            msg.Priority = MailPriority.High;//邮件优先级    
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("wangzhan@beijingonway.com", "WangZhan2017go");
            //在71info.com注册的邮箱和密码    
            client.Host = "smtp.qiye.163.com";
            client.EnableSsl = true;
            object userState = msg;
            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }
    }
}
