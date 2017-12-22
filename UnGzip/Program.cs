using SharpCompress.Common;
using SharpCompress.Reader;
using System;
using System.IO;

namespace UnGzip
{
    public class GZip
    {
        /// <summary>
        /// 解压tar.gz/rar压缩文件
        /// </summary>
        /// <param name="path">压缩文件路径</param>
        /// <param name="decomPath">解压缩目录</param>
        public static void untargz(string path, string decomPath)
        {
            try
            {
                using (Stream stream = File.OpenRead(path))
                {
                    var reader = ReaderFactory.Open(stream);
                    while (reader.MoveToNextEntry())
                    {
                        if (!reader.Entry.IsDirectory)
                        {
                            reader.WriteEntryToDirectory(decomPath, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void Main()
        {
            untargz("F:\\项目相关文档\\Gridsum.Source\\HW_20160104.tar.gz", "F:\\项目相关文档\\Gridsum.Source\\ungz\\");
        }
    }
}
