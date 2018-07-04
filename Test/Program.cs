using O2S.Components.PDFRender4NET;
using OHYDAL;
using OHYModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Test
{
    class Program
    {
        public enum Definition
        {
            One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10
        }

        /// <summary>
        /// 将PDF文档转换为图片的方法
        /// </summary>
        /// <param name="pdfInputPath">PDF文件路径</param>
        /// <param name="imageOutputPath">图片输出路径</param>
        /// <param name="imageName">生成图片的名字</param>
        /// <param name="startPageNum">从PDF文档的第几页开始转换</param>
        /// <param name="endPageNum">从PDF文档的第几页开始停止转换</param>
        /// <param name="imageFormat">设置所需图片格式</param>
        /// <param name="definition">设置图片的清晰度，数字越大越清晰</param>
        public static void ConvertPDF2Image(string pdfInputPath, string imageOutputPath,
            string imageName, int startPageNum, int endPageNum, ImageFormat imageFormat, Definition definition)
        {
            PDFFile pdfFile = PDFFile.Open(pdfInputPath);

            if (!Directory.Exists(imageOutputPath))
            {
                Directory.CreateDirectory(imageOutputPath);
            }

            // validate pageNum
            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }

            if (endPageNum > pdfFile.PageCount)
            {
                endPageNum = pdfFile.PageCount;
            }

            if (startPageNum > endPageNum)
            {
                int tempPageNum = startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }

            // start to convert each page
            for (int i = startPageNum; i <= endPageNum; i++)
            {
                Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);
                pageImage.Save(imageOutputPath + imageName + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                pageImage.Dispose();
            }

            pdfFile.Dispose();
        }

        public static void Main1(string[] args)
        {
            ConvertPDF2Image("D:\\abc.pdf", "D:\\", "A", 1, 5, ImageFormat.Jpeg, Definition.Two);
        }
        public static void Main2()
        {
            OhyMongoClient omc = new OhyMongoClient();
            // omc.UserManagerUM.InsertOne(new UM() { UserName = "admin", Password = "admin@123" });
            // UM u = omc.FindOne<UM>(new { UserName = "admin" });
            //omc.ClienteleClt.InsertOne(new Clientele() { name = "jhs" });
            //Clientele c=omc.FindOne<Clientele>("{name:\"jhs\"}");
            //Clientele c = omc.FindOne<Clientele>(new { name = "jhs" });
            //Clientele c = omc.FindOne<Clientele>(a => a.name == "jhs");
            //for (int i = 0; i < 5; i++)
            //{
            //    omc.CustomerC.InsertOne(new Customer() {  language= (OHYModel.LanguageEnum)1, NickName = "昵称" + i, TelePhone = "电话" + i, Email = "邮件" + i, requirement = "需求" + i });
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    omc.CustomerC.InsertOne(new Customer() { language = (OHYModel.LanguageEnum)0, NickName = "NickName" + i, TelePhone = "TelePhone" + i, Email = "Email" + i, requirement = "requirement" + i });
            //}
            //for (int i = 0; i < 50; i++)
            //{
            //    omc.HomenTextHt.InsertOne(new HomeText() { Logo = "logo" + i, Title = "title" + i, Address = "Address" + i, Content = "Content" + i });
            //}
            //CompanyProfile cp = new CompanyProfile()
            //{
            //    CompanyName = "ying",
            //    Address = "ying",
            //    TellPhone = "ying",
            //    Fax = "ying",
            //    Type=0,
            //    Eamil = "ying",
            //    Website = "ying",
            //    Content = "ying",
            //    language=(OHYModel.LanguageEnum)0
            //};

            //omc.CompanyProfileCp.InsertOne(cp);

            //cp.TellPhone = "1234";
            //cp._id = ObjectId.Parse("58bade7fe3c03f2760eb180d");
            ////omc.HomenTextHt.UpdateOne(new ObjectFilterDefinition<HomeText>(new { _id = ht._id })
            ////    , new JsonUpdateDefinition<HomeText>("{$set:{Title:\"" + ht.Title + "\"}}"));
            //omc.UpdateOneById<CompanyProfile>(cp);
            //新闻中心
            //for (int i = 0; i < 5; i++)
            //{
            //    omc.PressCenterPc.InsertOne(new PressCenter() { Title = "标题" + i, Content = "内容" + i, Language = (OHYModel.LanguageEnum)1 });
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    omc.PressCenterPc.InsertOne(new PressCenter() { Title = "Title" + i, Content = "Content" + i, Language = (OHYModel.LanguageEnum)0 });
            //}
            //业绩展示
            //for (int i = 0; i < 5; i++)
            //{
            //    omc.PerformancePresentationPP.InsertOne(new PerformancePresentation() { CompanyName = "公司" + i, EntryName = "项目名称" + i, language = (OHYModel.LanguageEnum)1 });
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    omc.PerformancePresentationPP.InsertOne(new PerformancePresentation() { CompanyName = "CompanyName" + i, EntryName = "EntryName" + i, language = (OHYModel.LanguageEnum)0});
            //}
        }

        public static void Main()
        {
            OHYCommon.Common.SendEmail("abc","<h3>Hello Email</h3>");
            //Console.ReadKey();
        }
    }
}
