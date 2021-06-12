using FluentAssertions;
using SpecflowDemo.Framework.Hooks;
using SpecflowDemo.Pages;
using TechTalk.SpecFlow;

namespace SpecflowDemo.StepDefinitions
{
	[Binding]
	public sealed class SearchSteps : BaseSteps
	{
		private readonly MainNavigationMenuPage MainNavigationMenu;
		private readonly SearchFormPage SearchForm;

		public SearchSteps(WebDriverContext driverContext) : base(driverContext)
		{
			MainNavigationMenu = new MainNavigationMenuPage(driverContext._driver);
			SearchForm = new SearchFormPage(driverContext._driver);
		}

		[Given(@"I click on Search icon in top header menu")]
		public void ClickSearchIconInHeader()
		{
			MainNavigationMenu.ClickSearchButton();
		}

		[When(@"I enter '(.*)' into the 'Search' field on the 'Search' form")]
		public void EnterSearchQuery(string query)
		{
			SearchForm.EnterSearchQuery(query);
		}

		[When(@"I click 'Find' button on the 'Search' form")]
		public void ClickFindButton()
		{
			SearchForm.ClickFindButton();
		}

		[Then(@"Url equals to '(.*)'")]
		public void VerifyUrlEqualsTo(string expectedUrl)
		{
			Driver.Url.Should().BeEquivalentTo(expectedUrl);
		}
	}
}
