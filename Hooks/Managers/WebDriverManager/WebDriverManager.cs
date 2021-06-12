using OpenQA.Selenium;
using SpecflowDemo.Framework.Data;
using SpecflowDemo.Framework.Managers.WebDriverConfigs;
using TechTalk.SpecFlow;

namespace SpecflowDemo.Framework.Managers
{
	public class WebDriverManager
	{
		private IWebDriver _webDriver;
		private readonly ScenarioContext _scenarioContext;

		public WebDriverManager(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		public IWebDriver Init()
		{
			if (_webDriver == null)
			{
				_webDriver = ConfigurationData.BrowserName switch
				{
					"Chrome" => new ChromeWebDriverConfig().CreateDriver(),
					"Firefox" => new FirefoxWebDriverConfig().CreateDriver(),
					_ => throw new System.Exception("This type of browser isn't supported")
				};
			}

			return _webDriver;
		}

		public void MaximizeWindow()
		{
			_webDriver.Manage().Window.Maximize();
		}

		public void QuitCurrentDriver()
		{
			_webDriver.Quit();
		}
	}
}