using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using O2S.Components.PDFRender4NET;
using System.Drawing;
using System.Drawing.Imaging;

namespace OHYCommon
{
    public class FileCommon
    {
        /// <summary>
        /// 文件根目录
        /// </summary>
        public static string FileBasePath = null;

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
        public static int ConvertPDF2Image(string pdfInputPath, string imageOutputPath,
            string imageName, int? startPageNum, int? endPageNum, ImageFormat imageFormat, Definition definition = Definition.Five)
        {
            pdfInputPath = FileBasePath == null ? pdfInputPath : Path.Combine(FileBasePath, pdfInputPath);
            PDFFile pdfFile = PDFFile.Open(pdfInputPath);

            if (!Directory.Exists(imageOutputPath))
            {
                Directory.CreateDirectory(imageOutputPath);
            }

            // validate pageNum
            if (startPageNum <= 0)
                startPageNum = 1;

            if (endPageNum > pdfFile.PageCount)
                endPageNum = pdfFile.PageCount;

            if (startPageNum == null)
                startPageNum = 1;

            if (endPageNum == null)
                endPageNum = pdfFile.PageCount;

            if (startPageNum > endPageNum)
            {
                int tempPageNum = (int)startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }

            // start to convert each page
            for (int i = (int)startPageNum; i <= endPageNum; i++)
            {
                Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);
                pageImage.Save(imageOutputPath + imageName + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                pageImage.Dispose();
            }
            int pagecount= pdfFile.PageCount;
            pdfFile.Dispose();
            return pagecount;
        }

        /// <summary>
        /// 要清空文件夹的路径
        /// </summary>
        /// <param name="dirPath"></param>
        public static void ClearDir(string dirPath)
        {
            dirPath = FileBasePath == null ? dirPath : Path.Combine(FileBasePath, dirPath);
            IEnumerable<string> files = Directory.EnumerateFiles(dirPath);
            foreach (var fileName in files)
            {
                File.Delete(fileName);
            }
        }
    }
}
