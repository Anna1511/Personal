using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowNunit.Pages;

namespace SpecflowDemo.Pages
{
	public class SearchFormPage : BasePage
	{
		[FindsBy(How = How.XPath, Using = "//div[contains(@class, 'search__panel')]")]
		public IWebElement SearchPanel { get; set; }

		[FindsBy(How = How.XPath, Using = "//input[contains(@id, 'form_search')]")]
		public IWebElement SearchInput { get; set; }

		[FindsBy(How = How.XPath, Using = "//button[contains(@class, 'search__submit')]")]
		public IWebElement FindButton { get; set; }

		public SearchFormPage(IWebDriver driver) : base(driver)
		{
		}

		public SearchFormPage EnterSearchQuery(string query)
		{
			SearchInput.SendKeys(query);
			return this;
		}

		public SearchFormPage ClickFindButton()
		{
			FindButton.Click();
			return this;
		}
	}
}
