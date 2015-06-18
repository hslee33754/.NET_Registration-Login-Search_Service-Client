using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; //this adds the hash methods

/// <summary>
/// This class takes the password and the passkey or random seed as strings. 
/// It joins them and then converts them to a byte array. 
/// It applies the SHA512 hashing algorithm to the array 
/// to create the new password.
/// </summary>
/// 
public class PasswordHash
{
    private string passwd;
    private string passkey;

    public Byte[] HashIt(string password, string passkey)
    {
        passwd = password;
        this.passkey = passkey;

        //Byte arrays to store the bytes for the password
        Byte[] originalBytes;
        Byte[] encodedBytes;
        //use a modern method to hash
        SHA512 shaHash = SHA512.Create();

        //combine the passkey and the password
        string passToHash = passkey + passwd;

        //convert the string to bytes
        originalBytes = ASCIIEncoding.Default.GetBytes(passToHash);
        //take the converted string and hash it
        encodedBytes = shaHash.ComputeHash(originalBytes);

        //return the hashed password
        return encodedBytes;

    }
}