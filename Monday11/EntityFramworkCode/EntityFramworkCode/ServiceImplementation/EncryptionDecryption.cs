using EntityFramworkCode.Models.DTO;

namespace EntityFramworkCode.ServiceImplementation
{
    public static class EncryptionDecryption 
    {
        public static string Encryption(string password)
        {
           
            var data_byte = System.Text.Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(data_byte); ;
        }
        public static string Decryption(string encodedData)
        {
            var decodedData = Convert.FromBase64String(encodedData);
            return System.Text.Encoding.UTF8.GetString(decodedData);
        }
    }
}
