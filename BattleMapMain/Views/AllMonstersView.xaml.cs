using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class AllMonstersView : ContentPage
{
	public AllMonstersView(AllMonstersViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}