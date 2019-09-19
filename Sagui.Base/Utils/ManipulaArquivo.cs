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

            try
            {
                using (var _stream = new FileStream(PathArquivo, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(_stream))
                    {
                        stream = reader.ReadBytes((int)_stream.Length);
                    }
                }
            }
            catch (Exception e)
            {

                stream = null;
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
