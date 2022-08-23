namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cardNumber = "1111111111111111";
            string expireDate = "07/23";
            string holderName = "eren kaynar";
            int cvv = 354;
            //bilgilerin denendigi yer
            try
            {
                CreditCard card = new CreditCard(cardNumber, expireDate, holderName, cvv);
                card.getInfos();
                Console.WriteLine("Giris Basarili");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Giris Basarisiz");
            }
        }
    }
}