using lab6.Data.Views;

namespace lab6
{
    class Program
    {
        public const int DELAY_TIME = 200;
        static void Main(string[] args)
        {
            MainBankView view = new MainBankView();
            view.RealizeView();
        }
    }
}