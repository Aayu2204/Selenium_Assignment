using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    class Program
    {
        static String logtablename;
        static String Clientname;
        static string Insurance_Plan;

        static void Main(string[] args)
        {
            ChromeDriver driver = null;
            String url;
            String userid;
            String password, Greeting = null; ;
            String Downloadfolderpath, Downloadfolderpath1;
            String claim_Files_Id = null, supporting_Files_Id;


            Assignment.MobilesScreen dashboardObj = null;
            try
            {

                By btnMobilesScreen = By.XPath("//a[contains(text(),'Mobiles')]");

                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

                driver.Url = @"https://www.amazon.in/";

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);

                dashboardObj = ClickMobileScreenBtn(driver, btnMobilesScreen);
                Thread.Sleep(1000);

                Thread.Sleep(1000);
                dashboardObj.clickPowerBankOption();
                Thread.Sleep(5000);
                dashboardObj.dataDriven_LoginScenario();
                Thread.Sleep(4000);


            }
            catch (Exception e)
            {

                //ceobj.sendmailDataExtraction(Clientname, Insurance_Plan, e.Message, con, claim_Files_Id);



            }
            driver.Quit();
            Thread.Sleep(2000);
            Environment.Exit(-1);

        }



        private static Assignment.MobilesScreen ClickMobileScreenBtn(IWebDriver driver, By btnSubmit)
        {

            IWebElement buttonElement = driver.FindElement(btnSubmit);
            if (buttonElement.Displayed || buttonElement.Enabled)
                try
                {
                    buttonElement.Click();
                }
                catch (Exception e)
                {

                }
            return new Assignment.MobilesScreen(driver);
        }
    }
}
