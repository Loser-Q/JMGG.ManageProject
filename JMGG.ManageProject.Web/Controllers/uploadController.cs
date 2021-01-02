using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model.Creative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{

    public class UploadController : Controller
    {
        public JsonResult Video(HttpPostedFileBase files)
        {
            string savePath = string.Empty;
            if (files != null)
            {
                if (files.ContentLength > 0)
                {
                    string filePath = files.FileName; //获得文件的完整路径名
                    //以年月日时分秒-毫秒将文件重新命名
                    string filename2 = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-fffffff");
                    string filename = filename2 + filePath.Substring(filePath.LastIndexOf('.'),
                                          filePath.Length - filePath.LastIndexOf('.'));
                    //设定上传路径（绝对路径）
                    string upPath = Server.MapPath("~/Uploads/") + filename;
                    //文件上传到绝对路径                   
                    files.SaveAs(upPath);
                    //设定数据库的存储路径
                    savePath = "\\Uploads\\" + filename;
                    //CreateImg(upPath, filename2);
                }
            }

            return Json("{\"video_url\":"+ savePath + ",\"mp3_url\":"+ savePath + "\",\"url\":\""+ savePath+ " !\",\"code\":0,\"main_img\":\"\",\"count\":632}");
        }

        //视频截图
        private string CreateImg(string fileName, string filename2)
        {
            string ffmpeg = Server.MapPath("~/Uploads/ffmpeg.exe");
            string vFileName = fileName;
            string FlvImgSize = "240x180";
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            string flv_img = filename2 + ".png";
            string flv_img_p = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/" + flv_img);
            startInfo.Arguments = " -i " + vFileName + "  -y  -f  image2   -ss 2 -vframes 1  -s   " + FlvImgSize +
                                  "  " + flv_img_p;
            try
            {
                System.Diagnostics.Process.Start(startInfo);
            }
            catch
            {
                return "";
            }

            if (System.IO.File.Exists(flv_img_p))
            {
                return flv_img;
            }

            return "";
        }
    }

}
