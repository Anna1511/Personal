using FluentAssertions;
using OpenQA.Selenium;
using SpecflowDemo.Framework.Data;
using SpecflowDemo.Framework.Hooks;
using SpecflowDemo.Pages;
using SpecFlowNunit.Hooks.Helpers.TestEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecflowDemo.StepDefinitions
{
	[Binding]
	public sealed class NavigationSteps : BaseSteps
	{
		private readonly MainNavigationMenuPage MainNavigationMenu;

		public NavigationSteps(WebDriverContext driverContext) : base(driverContext)
		{
			MainNavigationMenu = new MainNavigationMenuPage(driverContext._driver);
		}

		[Given(@"I am on the 'Home' page")]
		public void NavigateToUrl()
		{
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}

		[When(@"I scroll to the bottom of the page")]
		public void ScrollToBottom()
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
			js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
		}

		[Then(@"I see next links")]
		public void VerifyLinksInFooter(Table table)
		{
			var expectedLinks = new List<Link>();
			table.Rows.ToList().ForEach(row => expectedLinks.Add(new Link() {Href = $"{ConfigurationData.BaseUrl}{row["linkHref"]}", Name=row["linkName"] }));

			///Out-of-the box solution doesn't work.
			//var expectedLinks = table.CreateSet<Link>().ToList();

			var actualLinks = MainNavigationMenu.GetFooterLinks();
			for (int i = 0; i < expectedLinks.Count; i++)
			{
				actualLinks.Find(link => link.Name == expectedLinks[i].Name).Href.Should().BeEquivalentTo(expectedLinks[i].Href);
			}
		}
	}
}
