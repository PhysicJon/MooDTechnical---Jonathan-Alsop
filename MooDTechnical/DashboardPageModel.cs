using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooDTechnical
{
    public class DashboardPageModel
    {
        private IWebDriver driver { get; set; }

        public DashboardPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.XPath, Using = "/html/body/div[2]/div[2]/div[1]/div/ul[2]/li[3]/a")]
        public IWebElement AddPost { get; set; }
    }
}
