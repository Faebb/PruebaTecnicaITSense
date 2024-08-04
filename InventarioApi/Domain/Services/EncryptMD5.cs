using Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class EncryptMD5 : IEncryptMD5
{
    public async Task<string> EncryptMD5Async(string plainPassword)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            byte[] data = await Task.Run(() => md5Hash.ComputeHash(Encoding.UTF8.GetBytes(plainPassword)));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}


