using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class CharacterSheetsView : ContentPage
{
	public CharacterSheetsView(CharacterSheetsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}