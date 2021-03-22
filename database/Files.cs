using System;
using System.IO;
using System.Security.AccessControl;

namespace GofRPG_API
{
    class Files
    {   
        //Data members
        private String fileName = "sql_connection_string.txt";
        private Boolean isEncrypted = false;

        public String DecryptFile()
        {
            //Find the file, and decrypt it if it is encrypted.
            if(isEncrypted)
            {
                //decrypt file
                try
                {
                    File.Decrypt(fileName);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return "";
                }
            }

            //Gather the contents from the decrypted file.
            String contents = System.IO.File.ReadAllText(fileName);
            isEncrypted = false;

            //Return the contents
            return contents;
        }

        public Boolean EncryptFile()
        {
            //Find the file, and encrypt it if it is decrypted.
            if(!isEncrypted)
            {
                //entrypt file
                try
                {
                    File.Encrypt(fileName);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }

            //Change the value for isEncrypted
            isEncrypted = true;

            //Return true if it is sucesscully encrypted. False if not.
            return true;
        }

    }
}