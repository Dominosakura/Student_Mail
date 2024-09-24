using Student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Student.Controllers
{
    public class AttachfileController : Controller
    {
        // GET: Attachfile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(MailInfo model)
        {
            try
            {
                // Cấu hình máy chủ SMTP của Gmail với cổng 587 cho TLS
                var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("22280201e0030@student.tdmu.edu.vn", "jmps uzep glbq gbrm"),
                    EnableSsl = true
                };

                // Tạo mail message
                var message = new MailMessage
                {
                    From = new MailAddress(model.From),
                    Subject = model.Subject,
                    Body = model.Body,
                    IsBodyHtml = true // Nếu body là HTML
                };
                message.ReplyToList.Add(model.From);
                message.To.Add(new MailAddress(model.To));

                // Xử lý tệp đính kèm
                if (model.AttachmentFile != null && model.AttachmentFile.ContentLength > 0)
                {
                    var attachment = new Attachment(model.AttachmentFile.InputStream, model.AttachmentFile.FileName);
                    message.Attachments.Add(attachment);
                }

                // Gửi email
                smtpClient.Send(message);

                ViewBag.Message = "Email đã được gửi thành công!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Gửi email thất bại: " + ex.Message;
            }

            return View("Index");
        }
    }
}