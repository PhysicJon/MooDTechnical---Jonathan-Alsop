using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooDTechnical
{
    class AddPostPageModel
    {
        private IWebDriver driver { get; set; }

        public AddPostPageModel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.ClassName, Using = "editor-title__input")]
        public IWebElement Title { get; set; }

        [FindsBy(How=How.XPath, Using = "//*[@id='primary']/div/div/div[1]/div[2]/div[3]/ul/li[2]/a/span")]
        public IWebElement HTMLTab { get; set; }

        [FindsBy(How=How.Id, Using = "tinymce-1")]
        public IWebElement BodyText { get; set; }

        [FindsBy(How=How.ClassName, Using = "editor-ground-control__publish-button")]
        public IWebElement PublishPost { get; set; }

        [FindsBy(How=How.ClassName, Using = "notice__content")]
        public IWebElement PublishConfirmed { get; set; }
    }
}
