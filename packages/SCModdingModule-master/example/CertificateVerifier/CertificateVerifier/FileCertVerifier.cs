using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Defter.CertificateVerifier.Security
{
    /// <summary>
    /// Provides methods to verify file certificate and signature
    /// </summary>
    public class FileCertVerifier
    {
        private readonly X509Certificate2 rootCertificate;
        private readonly X509Certificate2 fileSignCertificate;

        /// <summary>
        /// Initializes a new instance of the <c>FileCertVerifier</c> class using a sign certificate file name.
        /// </summary>
        /// <param name="signCertFilename">An sign certificate filename (*.cer)</param>
        /// <exception cref="CryptographicException">
        /// An error with the certificate occurs.
        /// For example: 
        ///     The certificate file does not exist. 
        ///     The certificate is invalid. 
        ///     The certificate's password is incorrect.
        /// </exception>
        public FileCertVerifier(string signCertFilename)
        {
            fileSignCertificate = new X509Certificate2(signCertFilename);
        }

        /// <summary>
        /// Initializes a new instance of the <c>FileCertVerifier</c> class using information from a byte array
        /// </summary>
        /// <param name="signCertRawData">A byte array containing data from an X.509 sign certificate</param>
        /// <exception cref="CryptographicException">
        /// An error with the certificate occurs.
        /// For example: 
        ///     The certificate is invalid. 
        ///     The certificate's password is incorrect.
        /// </exception>
        public FileCertVerifier(byte[] signCertRawData)
        {
            fileSignCertificate = new X509Certificate2(signCertRawData);
        }

        /// <summary>
        /// Initializes a new instance of the <c>FileCertVerifier</c> class using a root and sign certificate file names.
        /// </summary>
        /// <param name="rootCertFilename">Root certificate filename (*.cer)</param>
        /// <param name="signCertFilename">An sign certificate filename (*.cer)</param>
        /// <exception cref="CryptographicException">
        /// An error with the certificate occurs.
        /// For example: 
        ///     The certificate file does not exist. 
        ///     The certificate is invalid. 
        ///     The certificate's password is incorrect.
        /// </exception>
        public FileCertVerifier(string rootCertFilename, string signCertFilename)
        {
            rootCertificate = new X509Certificate2(rootCertFilename);
            fileSignCertificate = new X509Certificate2(signCertFilename);
        }

        /// <summary>
        /// Initializes a new instance of the <c>FileCertVerifier</c> class using information from a byte arrays
        /// </summary>
        /// <param name="rootCertRawData">A byte array containing data from an X.509 root certificate</param>
        /// <param name="signCertRawData">A byte array containing data from an X.509 sign certificate</param>
        /// <exception cref="CryptographicException">
        /// An error with the certificate occurs.
        /// For example: 
        ///     The certificate is invalid. 
        ///     The certificate's password is incorrect.
        /// </exception>
        public FileCertVerifier(byte[] rootCertRawData, byte[] signCertRawData)
        {
            rootCertificate = new X509Certificate2(rootCertRawData);
            fileSignCertificate = new X509Certificate2(signCertRawData);
        }

        /// <summary>
        /// Verify file is signed only with one self-signed certificate and verify this certificate chain.
        /// </summary>
        /// <param name="filename">An filename to verify.</param>
        /// <returns>true if the file signed with certificate; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">The filename is null.</exception> 
        /// <exception cref="CryptographicException">The certificate is unreadable.</exception> 
        public bool VerifyFileCertificate(string filename)
        {
            if (filename == null) throw new ArgumentNullException("filename");
            X509Certificate2Collection fileCertificateCollection = new X509Certificate2Collection();
            fileCertificateCollection.Import(filename);
            if (fileCertificateCollection.Count == 1)
            {
                X509Certificate2 fileCertificate = fileCertificateCollection[0];
                if (fileCertificate.RawData.SequenceEqual(fileSignCertificate.RawData))
                {
                    X509Chain chain = X509Chain.Create();
                    if (rootCertificate != null)
                    {
                        chain.ChainPolicy.ExtraStore.Add(rootCertificate); // add CA cert for verification
                    }
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck; // no revocation checking
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
                    return chain.Build(fileCertificate) && VerifyChain(chain);
                }
            }
            return false;
        }

        /// <summary>
        /// Verify file signature for current signed certificate.
        /// </summary>
        /// <param name="filename">An filename to verify.</param>
        /// <returns>true if the file signature is valid; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">The filename is null.</exception> 
        /// <remarks>
        /// Warning: 
        ///     This method do not check certificate matched expected. 
        ///     Before use it always call <see cref="VerifyFileCertificate(string)"/>
        ///     or use method which verify both <see cref="VerifyFile(string)"/>
        /// </remarks>
        public bool VerifyFileSignature(string filename)
        {
            if (filename == null) throw new ArgumentNullException("filename");
            return WinTrust.VerifyEmbeddedSignature(filename);
        }

        /// <summary>
        /// Verify file is signed only with one self-signed certificate and verify it signature.
        /// </summary>
        /// <param name="filename">An filename to verify.</param>
        /// <returns>true if the file signed with certificate and signature is valid; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">The filename is null.</exception> 
        /// <exception cref="CryptographicException">The certificate is unreadable.</exception>
        public bool VerifyFile(string filename)
        {
            return VerifyFileCertificate(filename) && VerifyFileSignature(filename);
        }

        private bool VerifyChain(X509Chain chain)
        {
            if (VerifyChainStatus(chain.ChainStatus) && (chain.ChainElements.Count > 0))
            {
                if (rootCertificate != null)
                {
                    return chain.ChainElements[chain.ChainElements.Count - 1].Certificate.RawData.SequenceEqual(rootCertificate.RawData);
                }
                return true;
            }
            return false;
        }

        private static bool VerifyChainStatus(X509ChainStatus[] chainStatusArray)
        {
            if (chainStatusArray.Length == 1)
            {
                X509ChainStatusFlags chainStatus = chainStatusArray.First().Status;
                return chainStatus == X509ChainStatusFlags.NoError || chainStatus == X509ChainStatusFlags.UntrustedRoot || chainStatus == X509ChainStatusFlags.PartialChain;
            }
            return false;
        }
    }
}
