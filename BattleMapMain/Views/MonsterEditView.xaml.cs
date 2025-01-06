namespace BattleMapMain.Views;
using BattleMapMain.ViewModels;

public partial class MonsterEditView : ContentPage
{
	public MonsterEditView(MonsterEditViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}