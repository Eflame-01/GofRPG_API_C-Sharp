using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GofRPG_API
{
    class Files
    {   
        //Data members
        private String _encryptedFileName = "sql_encrypted_data.txt";
        private String _fileName = "sql_connection_string.txt";
        private Boolean _isEncrypted = false;
        private byte[] _encrypted;
        private byte[] _decrypted;

        public String DecryptFile()
        {
            //Find the file, and decrypt it if it is encrypted.
            if(File.Exists(_encryptedFileName))
            {
                _encrypted = File.ReadAllBytes(_encryptedFileName);
                _isEncrypted = true;
                File.Delete(_encryptedFileName);
            }
            if( _isEncrypted)
            {
                //decrypt file
                CspParameters cspParameters = new CspParameters();
                cspParameters.KeyContainerName = "Container";
                using(var rsa = new RSACryptoServiceProvider(2048, cspParameters))
                {
                    _decrypted = rsa.Decrypt(_encrypted, true);
                }
                File.WriteAllText(_fileName, Encoding.UTF8.GetString(_decrypted));
            }

            //Gather the contents from the decrypted file.
            String contents = System.IO.File.ReadAllText(_fileName);
            _isEncrypted = false;

            //Return the contents
            return contents;
        }

        public Boolean EncryptFile()
        {
            //Find the file, and encrypt it if it is decrypted.
            if(!File.Exists(_encryptedFileName) && !_isEncrypted)
            {
                //entrypt file
                byte[] plain = Encoding.UTF8.GetBytes(System.IO.File.ReadAllText(_fileName));
                int rsaProvider = 1;
                CspParameters cspParameters = new CspParameters(rsaProvider);
                cspParameters.KeyContainerName = "Container";
                using(var rsa = new RSACryptoServiceProvider(2048, cspParameters))
                {
                    _encrypted = rsa.Encrypt(plain, true);
                }

                File.WriteAllText(_fileName, BitConverter.ToString(_encrypted).Replace("-", ""));
                File.WriteAllBytes(_encryptedFileName, _encrypted);
            }

            //Change the value for isEncrypted
            _isEncrypted = true;

            //Return true if it is sucesscully encrypted. False if not.
            return true;
        }

    }
}