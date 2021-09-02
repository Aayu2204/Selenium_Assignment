using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    class MobilesScreen
    {
        public IWebDriver driver;
        public MobilesScreen(IWebDriver driver)
        {
            this.driver = driver;
        }
        By btnMobileAccessories = By.XPath("//div[contains(@id,'nav-subnav')]//span[contains(text(),'Mobiles & Accessories')]");
        By btnPowerBank = By.XPath("//a[contains(text(),'Power Banks')]");
        By btnAccountsAndList = By.XPath("//span[contains(text(),'Account & Lists')]");
        By btnSignIn = By.XPath("//a/span[contains(text(),'Sign in')]");
        By txtUsername = By.XPath("//input[contains(@id,'ap_email')]");
        By txtPasword = By.XPath("//input[contains(@id,'ap_password')]");
        By btnContinue = By.XPath("//input[contains(@id,'continue')]");
        By btnLogIn = By.XPath("//input[contains(@id,'signInSubmit')]");
        By lblChange = By.XPath("//a[contains(text(),'Change')]");
        public void clickPowerBankOption()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(btnMobileAccessories)).Build().Perform();
            Thread.Sleep(3000);
            IWebElement powerBank = driver.FindElement(btnPowerBank);
            powerBank.Click();
            Thread.Sleep(3000);
        }

        public void dataDriven_LoginScenario()
        {
            string CSV_FilePath = AppDomain.CurrentDomain.BaseDirectory + "Book1.csv";
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(btnAccountsAndList)).Build().Perform();
            Thread.Sleep(4000);
            IWebElement clickSignInBtn = driver.FindElement(btnSignIn);
            clickSignInBtn.Click();
            Thread.Sleep(4000);
            using (var reader = new StreamReader(CSV_FilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    IWebElement txtUserName = driver.FindElement(txtUsername);
                    txtUserName.SendKeys(values[0].ToString());
                    Thread.Sleep(1000);
                    IWebElement clickContinueBtn = driver.FindElement(btnContinue);
                    clickContinueBtn.Click();
                    Thread.Sleep(4000);
                    IWebElement txtPassword = driver.FindElement(txtPasword);
                    txtPassword.SendKeys(values[1].ToString());
                    Thread.Sleep(5000);
                    IWebElement btnSubmit = driver.FindElement(btnLogIn);
                    btnSubmit.Click();
                    Thread.Sleep(5000);
                    IWebElement linklblChange = driver.FindElement(lblChange);
                    linklblChange.Click();
                    Thread.Sleep(4000);
                }
            }
        }



    }
}
