namespace BattleMapMain.Views;
using BattleMapMain.ViewModels;

public partial class StatBlockEditView : ContentPage
{
	public StatBlockEditView(StatBlockEditViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}