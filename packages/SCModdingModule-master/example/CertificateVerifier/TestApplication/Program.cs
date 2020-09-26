using System;
using System.IO;
using System.Security.Cryptography;
using Defter.CertificateVerifier;
using Defter.CertificateVerifier.Security;

namespace TestApplication
{
    class Program
    {
        static int Main(string[] args)
        {
            var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            string solutionDir = currentDirectory.Parent.Parent.Parent.Parent.Parent.FullName + Path.DirectorySeparatorChar;
            string certDir = solutionDir + @"certs" + Path.DirectorySeparatorChar;
           
            VerifyFileWithHelper(certDir, solutionDir + @"x64\Release\CIGDevelopmentTools.dll");
            VerifyFileWithHelper(certDir, solutionDir + @"x64\Release\CIGDevelopmentTools_bad.dll");
            try
            {
                FileCertVerifier verifier = new FileCertVerifier(certDir + "Defter.CA.cer", certDir + "Defter.CoreSigning.cer");
                VerifyFile(verifier, solutionDir + @"x64\Release\CIGDevelopmentTools.dll");
                VerifyFile(verifier, solutionDir + @"x64\Release\CIGDevelopmentTools_bad.dll");
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Error: {0}", e);
                return 1;
            }
            return 0;
        }

        private static void VerifyFile(FileCertVerifier verifier, string checkFilePath)
        {
            try
            {
                Console.WriteLine("Check file: {0}", checkFilePath);
                Console.WriteLine("File certicicate valid: {0}", verifier.VerifyFileCertificate(checkFilePath));
                Console.WriteLine("File signature valid: {0}", verifier.VerifyFileSignature(checkFilePath));
                Console.WriteLine("File valid: {0}", verifier.VerifyFile(checkFilePath));
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Verify error: {0}", e);
            }
        }

        private static void VerifyFileWithHelper(string certDir, string checkFilePath)
        {
            Console.WriteLine("Check file (with helper): {0}", checkFilePath);
            bool status = VerifyHelper.VerifyFile(certDir + "Defter.CoreSigning.cer", checkFilePath);
            Console.WriteLine("File valid: {0}", status);
        }
    }
}
