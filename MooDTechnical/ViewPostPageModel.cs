using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooDTechnical
{
    public class ViewPostPageModel
    {
        private IWebDriver driver { get; set; }

        public ViewPostPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.XPath, Using = "//article[1]/header/h1/a")]
        public IWebElement FirstPostTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//article[1]/div/p")]
        public IWebElement FirstPostBody { get; set; }

    }
}
