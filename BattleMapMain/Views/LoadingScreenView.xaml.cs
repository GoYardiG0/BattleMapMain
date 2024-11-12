namespace BattleMapMain.Views;
using BattleMapMain.ViewModels;

public partial class LoadingScreenView : ContentPage
{
	public LoadingScreenView(LoadingScreenViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}