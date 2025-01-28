using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class MonsterAddView : ContentPage
{
	public MonsterAddView(MonsterAddViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}