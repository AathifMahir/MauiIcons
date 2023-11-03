namespace MauiIcons.Modules.UnitTest.Mocks;

class MockPage : Page
{
    public MockPage(MockPageViewModel viewModel)
    {
        BindingContext = viewModel;
    }
}