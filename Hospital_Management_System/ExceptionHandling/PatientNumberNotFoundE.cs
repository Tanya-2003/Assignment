using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.ExceptionHandling
{
    internal class PatientNumberNotFoundE : Exception
    {
        public PatientNumberNotFoundE(string message) : base(message)
        {
        }
    }
}

