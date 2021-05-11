using System.Text;


namespace TimeCard.API.Utilities
{
    public  class MD5
    {
        public static string MD5Encrypt32(string password)
        {
          string pwd = ""; 
          System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create(); 
          byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
          for (int i = 0; i < s.Length; i++)
          {
            pwd = pwd + s[i].ToString("X");
          }
          return pwd;
        }
    }
}