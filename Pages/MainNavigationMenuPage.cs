using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowNunit.Pages;

namespace SpecflowDemo.Pages
{
	public class MainNavigationMenuPage : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//button[contains(@class, 'header-search')]")]
		public IWebElement SearchButton { get; set; }

		public MainNavigationMenuPage(IWebDriver driver) : base(driver)
		{
		}

		public SearchFormPage ClickSearchButton()
		{
			SearchButton.Click();
			return new SearchFormPage(driver);
		}
	}
}
