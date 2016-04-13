using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MooDTechnical
{
    /************************/
    /*    Jonathan Alsop    */
    /************************/

    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;        
        private string PostTitle = "New Automated Post";
        private string BodyText = "This is a new post created using Selenium Webdriver’s .Net bindings";

        WebDriverWait wait;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://moodtest401.wordpress.com/";
            verificationErrors = new StringBuilder();

            //Initialise implicit wait, up to 30 seconds
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(30000));

            //Full Screen
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        [Description("Ensure a user can Log in successfully and the Dashboard is displayed")]
        public void Test001_SuccessfulLogin()
        {
            driver.Navigate().GoToUrl(baseURL + "wp-login.php");
            
            //Ensure the title is correct
            Assert.AreEqual(driver.Title, "moodtest401 › Log In");

            Login("moodtest401", "SQA4cce55");

            //Ensure the dashboard is displayed
            WaitForTitle("Dashboard ‹ moodtest401 — WordPress");
        }

        [Test]
        [Description("Ensure a new post can be created including a Title and Body Text. Publish this post")]
        public void Test002_AddNewPost()
        {
            driver.Navigate().GoToUrl(baseURL + "wp-login.php");

            //Ensure the title is correct
            Assert.AreEqual(driver.Title, "moodtest401 › Log In");

            Login("moodtest401", "SQA4cce55");

            //Ensure the dashboard is displayed
            WaitForTitle("Dashboard ‹ moodtest401 — WordPress");

            DashboardPageModel dash = new DashboardPageModel(driver);

            //Click Add Post button in the Top Right of the screen
            dash.AddPost.Click();

            //Ensure the New Post screen is displayed
            WaitForTitle("New Post ‹ moodtest401 — WordPress.com");

            AddPostPageModel post = new AddPostPageModel(driver);

            //Ensure the Add Post form is displayed
            Assert.IsTrue(post.Title.Displayed);

            //Enter a title
            post.Title.SendKeys(PostTitle);

            post.HTMLTab.Click();

            WaitForElementAppear(post.BodyText);

            //Enter body text
            post.BodyText.SendKeys(BodyText);            

            //publish post
            post.PublishPost.Click();

            WaitForTitle("Edit Post ‹ moodtest401 — WordPress.com");

            //Ensure the confirmation message is displayed
            WaitForElementAppear(post.PublishConfirmed);
        }

        [Test]
        [Description("Ensure a user can see the published post")]
        public void Test003_PublishedPostView()
        {
            driver.Navigate().GoToUrl(baseURL);

            //Ensure the page has loaded correctly
            Assert.AreEqual(driver.Title, "moodtest401");

            ViewPostPageModel view = new ViewPostPageModel(driver);

            //Ensure the title matches the previously created post title
            Assert.AreEqual(view.FirstPostTitle.Text, PostTitle);

            //Ensure the body text matches the previously created post body text
            Assert.AreEqual(view.FirstPostBody.Text, BodyText);
        }
                
        private void WaitForTitle(string title)
        {
            wait.Until(s => driver.Title.Equals(title));
        }

        private void WaitForElementAppear(IWebElement element)
        {
            wait.Until(s => element.Displayed);
        }

        private void Login(string user, string password)
        {
            LoginPageModel login = new LoginPageModel(driver);

            //Enter a username, password and click Login button
            login.Username.SendKeys(user);
            login.Password.SendKeys(password);
            login.SubmitBtn.Click();
        }
    }
}

