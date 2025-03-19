using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class MonsterStatsView : ContentPage
{
	public MonsterStatsView(MonsterStatsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}