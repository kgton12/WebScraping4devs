
using CsvHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Globalization;
using WebScraping4devs.Enum;
using WebScraping4devs.Model;

namespace WebScraping4devs.Driver
{
    public class WebScraping
    {
        public WebScraping()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
        }

        IWebDriver driver = null;
        public string GetCPF(string link, int qtd, string dir)
        {           

            driver.Navigate().GoToUrl(link);

            List<Cpf> cpfs = new List<Cpf>();

            for (int i = 0; i < qtd; i++)
            {
                var cpf = new Cpf();
                IWebElement generateButton = driver.FindElement(By.Id("bt_gerar_cpf"));
                generateButton.Click();
                Thread.Sleep(1000);
                
                cpf.cpf = driver.FindElement(By.Id("texto_cpf")).Text;

                cpfs.Add(cpf);
            }

            SaveToCsvCPF(cpfs, dir);

            return "";
        }
        public string GetCardNumber(string link, Flag flag, int qtd, string dir)
        {
            string idCardNumber = null;

            driver.Navigate().GoToUrl(link);
 
            switch (flag)
            {
                case Flag.MasterCard:
                    idCardNumber = "master";
                    break;
                case Flag.Visa:
                    idCardNumber = "visa16";
                    break;
                case Flag.AmericanExpress:
                    idCardNumber = "amex";
                    break;
                case Flag.Dinners:
                    idCardNumber = "diners";
                    break;
                case Flag.Discover:
                    idCardNumber = "discover";
                    break;
                case Flag.HiperCard:
                    idCardNumber = "hiper";
                    break;
                default:
                    idCardNumber = "master";
                    break;
            }
            List<CreditCard> creditCards = new List<CreditCard>();

            for (int i = 0; i < qtd; i++)
            {
                var creditCard = new CreditCard();
                IWebElement flagCard = driver.FindElement(By.Id(idCardNumber));
                flagCard.Click();

                Thread.Sleep(1000);

                creditCard.CardNumber = driver.FindElement(By.Id("cartao_numero")).Text;
                creditCard.ExpirationDate = driver.FindElement(By.Id("data_validade")).Text;
                creditCard.SecurityCode = driver.FindElement(By.Id("codigo_seguranca")).Text;

                creditCards.Add(creditCard);
            }           

            SaveToCsvCreditCard(creditCards, dir);

            return "";
        }
        public void SaveToCsvCPF(List<Cpf> obj, string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<Cpf>();
                csv.NextRecord();

                foreach (var item in obj)
                {
                    csv.WriteRecord(item);
                    csv.NextRecord();
                }
            }
        }
        public void SaveToCsvCreditCard(List<CreditCard> obj, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<CreditCard>();
                csv.NextRecord();

                foreach (var item in obj)
                {
                    csv.WriteRecord(item);
                    csv.NextRecord();
                }                
            }
        }
        public void CloseDriver()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Dispose();
            }
        }
    }
}
