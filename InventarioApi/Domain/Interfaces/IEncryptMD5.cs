using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEncryptMD5
    {
        Task<string> EncryptMD5Async(string plainPassword);
    }
}
