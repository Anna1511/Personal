using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecFlowNunit.Pages
{
	public class BasePage
	{
		protected IWebDriver driver;

		public BasePage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}
	}
}
