using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class SessionView : ContentPage
{
	public SessionView(SessionViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}