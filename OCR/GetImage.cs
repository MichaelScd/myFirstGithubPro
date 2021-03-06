﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//capture
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
/********************************
 *
 * 
 * 负责在指定的区域进行截图并保存在本地默认位置
 * 
 * 
********************************/
namespace OCR
{
    class GetImage
    {
        private int startX, startY, width, height;
        public void saveImage()
        {
            string Opath = @"C:/Picture";
            if (Opath.Substring(Opath.Length - 1, 1) != @"/")
                Opath = Opath + @"/";
            string photoname = "1";
            string path1 = Opath;
            //if (!Directory.Exists(path1))
            //    Directory.CreateDirectory(path1);
            try
            {

                Screen scr = Screen.PrimaryScreen;
                Rectangle rc = scr.Bounds;
                int iWidth = rc.Width;
                int iHeight = rc.Height;
                Bitmap myImage = new Bitmap(iWidth, iHeight);
                Graphics gl = Graphics.FromImage(myImage);
                gl.CopyFromScreen(new Point(startX, startY), new Point(0, 0), new Size(iWidth, iHeight));
                Image _img = myImage;
                //pictureBox1.Image = _img;
                // IntPtr dc1 = gl.GetHdc();
                //gl.ReleaseHdc(dc1);
                //MessageBox.Show(path1);
                //MessageBox.Show(photoname);
                _img.Save(path1 + "//" + photoname + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                // _img.Save("D:\\1.jpeg");
                //SendFile(path1 + "//" + photoname + ".jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("截屏失败！\n" + ex.Message.ToString() + "\n" + ex.StackTrace.ToString());
            }
        }

        public void setPosition(int startX,int startY,int width,int height) {
            this.startX = startX;
            this.startY = startY;
            this.width = width;
            this.height = height;
        }

    }


}
