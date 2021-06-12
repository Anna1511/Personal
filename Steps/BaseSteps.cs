using OpenQA.Selenium;
using SpecflowDemo.Framework.Hooks;
using SpecflowDemo.Framework.Managers;
using TechTalk.SpecFlow;
using static SpecflowDemo.Framework.Data.ConfigurationData;

namespace SpecflowDemo.StepDefinitions
{
	[Binding]
	public class BaseSteps : Steps
	{
		protected IWebDriver Driver { get; }
		public WebDriverManager WebDriverManager;
		private readonly WebDriverContext WebDriverContext;

		public BaseSteps(WebDriverContext driverContext)
		{
			WebDriverContext = driverContext;
			WebDriverManager = (WebDriverManager)ScenarioContext.Current[DriverContextName];
			Driver = WebDriverContext._driver;
		}
		//protected LoginPage LoginPage { get; }

		[Given(@"I navigate to the '(.*)' page")]
		public virtual void NavigateToUrl(string url)
		{
			Driver.Navigate().GoToUrl(url);
		}
	}
}
