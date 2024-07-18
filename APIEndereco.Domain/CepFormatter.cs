using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEndereco.Domain
{
    public static class CepFormatter
    {
        public static string Format(string cep)
        {
            return Convert.ToUInt32(cep).ToString(@"00000\-000");
        }
    }
}
