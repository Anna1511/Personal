using BoDi;
using OpenQA.Selenium;
using SpecflowDemo.Framework.Managers;
using System;
using TechTalk.SpecFlow;
using static SpecflowDemo.Framework.Data.ConfigurationData;

namespace SpecflowDemo.Framework.Hooks
{
	[Binding]
	public sealed class WebDriverContext
	{
		private readonly IObjectContainer _objectContainer;
		private WebDriverManager _webDriverManager;
		private ScenarioContext _scenarioContext;
		public IWebDriver _driver;

		public WebDriverContext(IObjectContainer objectContainer) => _objectContainer = objectContainer;

		[BeforeScenario]
		public void BeforeScenario(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
			_webDriverManager = new WebDriverManager(scenarioContext);

			_driver = _webDriverManager.Init();
			_driver.Navigate().GoToUrl(BaseUrl);
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			_scenarioContext[DriverContextName] = _webDriverManager;
			_objectContainer.RegisterInstanceAs(_driver);
		}

		[AfterScenario]
		public void TearDown()
		{
			//using IWebDriver driver = _objectContainer.Resolve<IWebDriver>();
			_driver.Quit();
			_driver.Dispose();
		}
	}
}
