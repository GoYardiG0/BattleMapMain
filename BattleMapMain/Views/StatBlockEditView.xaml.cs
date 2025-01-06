namespace BattleMapMain.Views;
using BattleMapMain.ViewModels;

public partial class StatBlockEditView : ContentPage
{
	public StatBlockEditView(MonsterEditViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}