using Microsoft.AspNetCore.Http;

namespace Whm.Infrastructure.Helpers
{
    public static class FileHelper
    {
        private static readonly Dictionary<string, List<byte[]>> _fileSignature = new Dictionary<string, List<byte[]>>
        {
            { "jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
                }
            },
            {
                "mp4", new List<byte[]> {
                    new byte[] { 0x00, 0x00, 0x00, 0x18 },
                    new byte[] { 0x66, 0x74, 0x79, 0x70 },
                    new byte[] { 0x6D, 0x70, 0x34, 0x32 }
                }
            },
            {
                "mkv", new List<byte[]> {
                    new byte[] { 0x1A, 0x45, 0xDF, 0xA3 }
                }
            }
        };

        /// <summary>
        ///     ValidFileExtension
        /// </summary>
        /// <param name="file"></param>
        /// <param name="validExtension"></param>
        /// <returns>bool</returns>
        public static bool ValidFileExtension(IFormFile file, string[] validExtension)
        {
            string fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (validExtension.Contains(fileExtension))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     CheckFileSignature
        /// </summary>
        /// <param name="uploadFile"></param>
        /// <param name="extensionFile"></param>
        /// <returns>bool</returns>
        public static bool CheckFileSignature(IFormFile uploadFile, string extensionFile)
        {
            var reader = new BinaryReader(uploadFile.OpenReadStream());
            try
            {
                if (!_fileSignature.ContainsKey(extensionFile))
                {
                    return false;
                }
                var signatures = _fileSignature[extensionFile];
                var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

                return signatures.Any(signature =>
                    headerBytes.Take(signature.Length).SequenceEqual(signature));
            }
            finally
            {
                reader.Close();
            }
        }

        /// <summary>
        ///     GenerateFileName
        /// </summary>
        /// <param name="originalFileName"></param>
        /// <param name="userName"></param>
        /// <returns>Format file name</returns>
        public static string GenerateFileName(string originalFileName, string userName)
        {
            return $"{StringHelper.GenerateUUID()}-{originalFileName}-{userName}";
        }
    }
}

