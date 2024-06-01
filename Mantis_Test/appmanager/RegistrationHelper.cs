using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_Test 
{
    /*public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager): base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationAccount(account);
            SubmitRegistratio();
        }

        public void OpenRegistrationForm()
        {
            driver.FindElement(By.LinkText("Зарегистрировать новую учётную запись")).Click();
        }

        public void SubmitRegistratio()
        {
            throw new NotImplementedException();
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.26.2/mantisbt-2.26.2/login_page.php";
        }

        public void FillRegistrationAccount(AccountData account)
        {
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.Id("email-field")).SendKeys(account.Email);
        }
    }*/
}
