using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class CharacterAddView : ContentPage
{
	public CharacterAddView(CharacterSheetsViewModel vm)
    {
        this.BindingContext = vm;
        InitializeComponent();
	}
}