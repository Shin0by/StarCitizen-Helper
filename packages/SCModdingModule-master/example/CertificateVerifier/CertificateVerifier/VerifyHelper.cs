using Defter.CertificateVerifier.Security;
using System.Security.Cryptography;

namespace Defter.CertificateVerifier
{
    public static class VerifyHelper
    {
        public static bool VerifyFile(byte[] certificateRawData, string verifyFilename)
        {
            try
            {
                FileCertVerifier verifier = new FileCertVerifier(certificateRawData);
                return verifier.VerifyFile(verifyFilename);
            }
            catch (CryptographicException)
            {
                return false;
            }
        }

        public static bool VerifyFile(string certificateFilename, string verifyFilename)
        {
            try
            {
                FileCertVerifier verifier = new FileCertVerifier(certificateFilename);
                return verifier.VerifyFile(verifyFilename);
            }
            catch (CryptographicException)
            {
                return false;
            }
        }
    }
}
