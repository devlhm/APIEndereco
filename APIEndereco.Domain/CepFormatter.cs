using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEndereco.Domain
{
    public class CepFormatter : ICepFormatter
    {
        public string Format(string cep)
        {
            return Convert.ToUInt32(cep).ToString(@"00000\-000");
        }
    }
}
