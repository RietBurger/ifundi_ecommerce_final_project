using System;
using System.Security.Cryptography;
using System.IO;

namespace mvc_ecommerce_tutorial.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string Street { get; set; }
        public string StrNo { get; set; }
        public string Complex { get; set; }
        public string UnitNo { get; set; }
        public string PostalCode { get; set; }
        public string Suburb { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public int Latitude { get; set; } // these would be useful if maps installed and usable
        public int Longitude { get; set; }// these would be useful if maps installed and usable
        public string userID { get; set; }
        // public DateTime dt = new DateTime();
        // public date dt {get; set;}


        // encode and decoding password page reference: https://www.c-sharpcorner.com/blogs/how-to-encrypt-or-decrypt-password-using-asp-net-with-c-sharp1

        // Base64 Encode password
        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}

