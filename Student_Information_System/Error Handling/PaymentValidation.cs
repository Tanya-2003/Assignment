using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;

namespace Student_Information_System.Error_Handling
{
    internal class PaymentValidation : Exception
    {
        public PaymentValidation(string message) : base(message)
        {

        }

        public static void PaymentErrorE(Payment payment)
        {
            if (payment.Amount <= 0)
            {
                throw new PaymentValidation("Payment amount invalid!!");
            }
            else if (payment.PaymentDate > DateTime.Now)
            {
                throw new PaymentValidation("Payment date invalid!!");
            }
        }
    }
}
