using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GofRPG_API
{
    class Files
    {   
        //Data members
        private String _encryptedFileName = "sql_encrypted_data.txt";   //actual data that we will use (in string value)
        private String _fileName = "sql_connection_string.txt";         //name of sql encrypted data incase original is lost (in byte value)
        private Boolean _isEncrypted = false;                           //checks if the file is encrypted
        private byte[] _encrypted;                                      //value of the encrypted bytes
        private byte[] _decrypted;                                      //value of the decrypted bytes

        public String DecryptFile()
        {
            //Find the file, and decrypt it if it is encrypted.
            if(File.Exists(_encryptedFileName))
            {
                //if the encrypted file exists, get the bytes and delete the file
                _encrypted = File.ReadAllBytes(_encryptedFileName);
                _isEncrypted = true;
                File.Delete(_encryptedFileName);
            }
            if( _isEncrypted)
            {
                //decrypt the bytes you get from the encrypted bytes if the file is encrypted
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

                //write file into original file name and back up file name
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