using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace th.AdminibotLegacy
{
    class Rtf
    {
        public const string RtfHeader = @"{\rtf1 ";
        public const string RtfFooter = @" }";
        public static string ColorTable = @"{\rtf1}";
        private static readonly Dictionary<string, string> _escapeRegexes = new Dictionary<string, string>
        {
            {@"(\\)(?:[^\\]|)", @"\\"}/*,
            {@"{", @"\{"},
            {@"}", @"\}"}*/
        };
        public static readonly Dictionary<string, object[]> Colors = new Dictionary<string, object[]>
        {
            {Types.Chat.Regular.ToString(), new object[]{1, Color.Black}},
            {Types.Chat.Status.ToString(),new object[]{2, Color.Gray}},
            {Types.Chat.Subscribe.ToString(), new object[]{3, Color.Gray}},
            {Types.Chat.Notification.ToString(), new object[]{4, Color.DimGray}},
            {Types.UserLevel.Admin.ToString(), new object[]{5, Color.OrangeRed}},
            {Types.UserLevel.GlobalMod.ToString(), new object[]{6, Color.Green}},
            {Types.UserLevel.Staff.ToString(), new object[]{7, Color.BlueViolet}},
            {Types.UserLevel.Broadcaster.ToString(), new object[]{8, Color.Firebrick}},
            {Types.UserLevel.Moderator.ToString(), new object[]{9, Color.Coral}},
            {Types.UserLevel.Editor.ToString(), new object[]{10, Color.Blue}},
            {Types.UserLevel.Viewer.ToString(), new object[]{11, Color.Black}}
        };

        [Flags]
        enum EmfToWmfBitsFlags
        {
            EmfToWmfBitsFlagsDefault = 0x00000000,
            EmfToWmfBitsFlagsEmbedEmf = 0x00000001,
            EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,
            EmfToWmfBitsFlagsNoXORClip = 0x00000004
        }

        const int MM_ISOTROPIC = 7;
        const int MM_ANISOTROPIC = 8;

        [DllImport("gdiplus.dll")]
        private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize, byte[] _buffer, int _mappingMode, EmfToWmfBitsFlags _flags);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SetMetaFileBitsEx(uint _bufferSize, byte[] _buffer);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CopyMetaFile(IntPtr hWmf,
            string filename);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteMetaFile(IntPtr hWmf);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteEnhMetaFile(IntPtr hEmf);

        public static string GetEmbedImageString(string path)
        {
            string fileName = path.Substring(path.LastIndexOf("/") + 1);
            fileName = fileName.Substring(0, fileName.Length - 4);
            string filePath = Environment.CurrentDirectory + @"\cache\" + Program.MakeValidFileName(fileName) + ".cache";
            string proto = "";
            if (File.Exists(filePath))
            {
                proto = File.ReadAllText(filePath);
            }
            else
            {
                try
                {
                    byte[] imageData = null;
                    using (var webClient = new WebClient())
                    {
                        imageData = webClient.DownloadData(path);
                    }

                    if (imageData == null) return String.Empty;

                    Bitmap image;
                    using (var ms = new MemoryStream(imageData))
                    {
                        image = new Bitmap(ms);
                    }

                    Metafile metafile = null;
                    float dpiX;
                    float dpiY;
                    using (Graphics g = Graphics.FromImage(image))
                    {
                        IntPtr hDC = g.GetHdc();
                        metafile = new Metafile(hDC, EmfType.EmfOnly);
                        g.ReleaseHdc(hDC);
                    }

                    using (Graphics g = Graphics.FromImage(metafile))
                    {
                        g.DrawImage(image, 0, 0);
                        dpiX = g.DpiX;
                        dpiY = g.DpiY;
                    }

                    IntPtr _hEmf = metafile.GetHenhmetafile();
                    uint _bufferSize = GdipEmfToWmfBits(_hEmf, 0, null, MM_ANISOTROPIC,
                        EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
                    byte[] _buffer = new byte[_bufferSize];
                    GdipEmfToWmfBits(_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC,
                        EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
                    IntPtr hmf = SetMetaFileBitsEx(_bufferSize, _buffer);
                    string tempfile = Path.GetTempFileName();
                    CopyMetaFile(hmf, tempfile);
                    DeleteMetaFile(hmf);
                    DeleteEnhMetaFile(_hEmf);

                    var stream = new MemoryStream();
                    byte[] data = File.ReadAllBytes(tempfile);
                    //File.Delete (tempfile);
                    int count = data.Length;
                    stream.Write(data, 0, count);

                    proto = @"{\pict\wmetafile8\picw" + (int) ((image.Width/dpiX)*2540)
                            + @"\pich" + (int) ((image.Height/dpiY)*2540)
                            + @"\picwgoal" + (int) ((image.Width/dpiX)*1440)
                            + @"\pichgoal" + (int) ((image.Height/dpiY)*1440)
                            + " "
                            + BitConverter.ToString(stream.ToArray()).Replace("-", "")
                            + "}";

                    StreamWriter file = new StreamWriter(filePath);
                    file.WriteLine(proto);

                    file.Close();
                }
                catch (Exception e)
                {
                    proto = null;
                }
                
            }
            
            return proto;
        }

        public static string EscapeString(string input)
        {
            StringBuilder escapedStr = new StringBuilder();
            foreach (char c in input)
                escapedStr.Append((c == '\\' || c == '{' || c == '}' ? @"\" : "") + c);
            
            return escapedStr.ToString();
        }
    }
}
