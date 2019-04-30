using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sagui.Base.Utils
{
    public static class ManipulaArquivo
    {
        public static byte[] GerarStreamArquivo(string PathArquivo)
        {
            byte[] stream = default(byte[]);

            using (var _stream = new FileStream(PathArquivo, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(_stream))
                {
                    stream = reader.ReadBytes((int)_stream.Length);
                }
            }

            return stream;
        }



        public static void GerarArquivoPeloStream()
        {
            using (Stream file = File.OpenWrite(@"c:\path\to\your\file\here.txt"))
            {
                //file.Write(fileBytes, 0, fileBytes.Length);
            }
        }
    }
}
