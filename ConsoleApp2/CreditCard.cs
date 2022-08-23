using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CreditCard
    {
        private string cardNumber;
        private string expireDate;
        private string holderName;
        private int cvv;

        private long customerNumber;
        private long iban;

        public CreditCard(string cardNumber, string expireDate, string holderName, int cvv)
        {
            if(cardNumber.Length != 16)
            {
                throw new CreditCardLenghtException("Credit Card Number Not Valid");
            }
            if(expireDate.Length > 5)
            {
                throw new CreditCardExpireDateException("Expire Date Not Valid");
            }
            if (cvv.ToString().Length != 3)
            {
                throw new Exception("Not Valid CVV");
            }
            if (expireDate.Contains("/"))
            {
                string[] inputeDates = expireDate.Split("/");
                string currentMonth = DateTime.Now.ToString("mm");
                string currentYear = DateTime.Now.ToString("yy");

                if (Int32.Parse(inputeDates[0]) < 1 || Int32.Parse(inputeDates[0]) > 12)
                {
                    throw new CreditCardExpireDateException("Expire Date Not Valid");
                }
                
                else if (Int32.Parse(inputeDates[1]) < Int32.Parse(currentYear))
                {
                    throw new CreditCardExpireDateException("Expire Date Not Valid");
                }
                else if((Int32.Parse(inputeDates[0]) < Int32.Parse(currentMonth)) && (Int32.Parse(inputeDates[1]) == Int32.Parse(currentYear))){
                    throw new CreditCardExpireDateException("Expire Date Not Valid");
                }
                else
                {
                    this.cardNumber = cardNumber;
                    this.expireDate = expireDate;
                    this.holderName = holderName;
                    this.cvv = cvv;
                }
            }
            else
            {
                throw new CreditCardExpireDateException("Expire Date Not Valid");
            }
        }
        public void getInfos()
        {
            Console.WriteLine("CN: "+cardNumber +" ED:"+expireDate + " HN: "+holderName + " CVV:"+cvv);
        }
        public string CardNumber { get { return this.cardNumber; } }
        public string ExpireDate { get { return this.expireDate; } }
        public string HolderName { get { return this.holderName; } }
        public int CVV { get { return this.cvv; } }
        public long CustomerNumber { get { return this.customerNumber; }set { this.customerNumber = value; } }
        public long Iban { get { return this.iban; } set { this.iban = value; } }
    }
}
