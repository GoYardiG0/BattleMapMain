using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class UserMonstersView : ContentPage
{
	public UserMonstersView(UserMonstersViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (this.BindingContext is UserMonstersViewModel)
        {
            ((UserMonstersViewModel)this.BindingContext).Refresh();
        }
    }

}