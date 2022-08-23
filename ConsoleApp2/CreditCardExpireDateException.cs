using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CreditCardExpireDateException : Exception
    {
        public CreditCardExpireDateException()
        {

        }
        public CreditCardExpireDateException(string msg) : base(msg)
        {

        }

    }
}
