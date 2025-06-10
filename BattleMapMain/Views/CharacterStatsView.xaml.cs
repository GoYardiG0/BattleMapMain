using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class CharacterStatsView : ContentPage
{
	public CharacterStatsView(CharacterStatsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}