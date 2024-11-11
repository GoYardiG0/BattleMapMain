namespace BattleMapMain.Views;
using BattleMapMain.ViewModels;

public partial class BattleMapView : ContentPage
{
	public BattleMapView(BattleMapViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}