using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooDTechnical
{
    public class LoginPageModel
    {
        private IWebDriver driver { get; set; }

        public LoginPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "user_login")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "user_pass")]
        public IWebElement Password { get; set; }
        
        [FindsBy(How=How.Id, Using ="wp-submit")]
        public IWebElement SubmitBtn { get; set; }
    }
}
