using OpenQA.Selenium;
using SpecflowDemo.Framework.Hooks;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using static SpecflowDemo.Framework.Data.ConfigurationData;

namespace SpecflowDemo.StepDefinitions
{
	[Binding]
	public sealed class NavigationSteps : BaseSteps
	{
		public NavigationSteps(WebDriverContext driverContext) : base(driverContext)
		{
		}

		[Given(@"I am on the 'Home' page")]
		public void NavigateToUrl()
		{
			//NavigateToUrl(ConfigurationManager.AppSettings.Get(BaseUrl));
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}
	}
}
