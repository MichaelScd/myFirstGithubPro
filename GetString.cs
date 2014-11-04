using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/*******************************
 * 
 * 负责读取默认位置的图像，
 * 调用OCR模块进行识别，
 * 并将识别结果放入剪贴板
 * 
*******************************/
namespace OCR
{
    class GetString
    {
        //NGA
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("GVOCR.dll")]
        public static extern bool setSingleImage(String filePath);

        [DllImport("GVOCR.dll")]
        public static extern string getImageStr();

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("GVOCR.dll")]
        public static extern bool clearOCR();

        string filePath = @"1.png";
        public string myGetString()
        {
            //NGA
            setSingleImage(filePath);
            //StringBuilder resStr = new StringBuilder(1024);
            string resStr = getImageStr();
            MessageBox.Show(resStr);
            //string resStr = "";
            //getSingleImageStr(resStr);
            Clipboard.SetDataObject(resStr.ToString());
            return resStr.ToString();
        }

    }
}
