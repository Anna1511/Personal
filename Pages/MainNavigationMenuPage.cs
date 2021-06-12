using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowNunit.Hooks.Helpers.TestEntities;
using SpecFlowNunit.Pages;
using System.Collections.Generic;
using System.Linq;

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

		public List<Link> GetFooterLinks()
		{
			var links = new List<Link>();
			var elements = driver.FindElements(By.XPath("//a[contains(@class, 'footer__links-item')]")).ToList();

			elements.ForEach(link => links.Add(new Link() { Name = link.Text, Href = link.GetAttribute("href") }));

			return links;
		} 
	}
}
