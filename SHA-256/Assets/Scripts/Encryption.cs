using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Encryption : MonoBehaviour {

    private void Start() {
        string text = "maydinunlu";
        string hashText = GetSHA256(text);
        Debug.Log("Hash Text (" + text  + "): " + hashText);
    }

    /// <summary>
    /// Converts a string into a SHA-256 Hash Vaue
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private string GetSHA256(string text) {
        byte[] textToBytes = Encoding.UTF8.GetBytes(text);

        SHA256Managed mySHA256 = new SHA256Managed();

        byte[] hashValue = mySHA256.ComputeHash(textToBytes);

        return GetHexStringFromHash(hashValue);
    }


    /// <summary>
    /// Converts an array of bytes into a hexadecimal string 
    /// </summary>
    /// <param name="hashValue"></param>
    /// <returns></returns>
    public string GetHexStringFromHash(byte[] hashValue) {
        string hexString = String.Empty;

        foreach (byte b in hashValue) {
            hexString += b.ToString("x2");
        }

        return hexString;
    }

}