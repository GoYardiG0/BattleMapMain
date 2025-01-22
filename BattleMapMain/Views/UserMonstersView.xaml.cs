using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class UserMonstersView : ContentPage
{
	public UserMonstersView(UserMonstersViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}