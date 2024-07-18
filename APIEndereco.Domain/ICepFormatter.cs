using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEndereco.Domain
{
    public interface ICepFormatter
    {
        string Format(string cep);
    }
}
