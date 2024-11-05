using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class GameStartView : ContentPage
{
	public GameStartView(GameStartViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}