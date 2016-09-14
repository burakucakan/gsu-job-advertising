using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace GSUKariyer.COMMON.Helpers.General
{
    public static class Compressor
    {

        public class DeflaterCompression
        {
            private const int BUFFER_SIZE = 65536;
            private static int viewStateCompression = ICSharpCode.SharpZipLib.Zip.Compression.Deflater.DEFAULT_COMPRESSION;

            public static byte[] Compress(byte[] bytes)
            {
                using (MemoryStream memoryStream = new MemoryStream(BUFFER_SIZE))
                {
                    Deflater deflater = new Deflater(viewStateCompression);
                    using (Stream stream = new DeflaterOutputStream(memoryStream, deflater, BUFFER_SIZE))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    return memoryStream.ToArray();
                }
            }
            public static byte[] Decompress(byte[] bytes)
            {
                using (MemoryStream byteStream = new MemoryStream(bytes))
                {
                    using (Stream stream = new InflaterInputStream(byteStream))
                    {
                        using (MemoryStream memory = new MemoryStream(BUFFER_SIZE))
                        {
                            byte[] buffer = new byte[BUFFER_SIZE];
                            while (true)
                            {
                                int size = stream.Read(buffer, 0, BUFFER_SIZE);
                                if (size <= 0)
                                    break;

                                memory.Write(buffer, 0, size);
                            }
                            return memory.ToArray();
                        }
                    }
                }
            }
        }

        public class Gzip
        {

            public static byte[] Compress(byte[] data)
            {
                MemoryStream output = new MemoryStream();
                GZipStream gzip = new GZipStream(output,
                                  CompressionMode.Compress, true);
                gzip.Write(data, 0, data.Length);
                gzip.Close();
                return output.ToArray();
            }

            public static byte[] Decompress(byte[] data)
            {
                MemoryStream input = new MemoryStream();
                input.Write(data, 0, data.Length);
                input.Position = 0;
                GZipStream gzip = new GZipStream(input,
                                  CompressionMode.Decompress, true);
                MemoryStream output = new MemoryStream();
                byte[] buff = new byte[64];
                int read = -1;
                read = gzip.Read(buff, 0, buff.Length);
                while (read > 0)
                {
                    output.Write(buff, 0, read);
                    read = gzip.Read(buff, 0, buff.Length);
                }
                gzip.Close();
                return output.ToArray();
            }
        }
    }
}
