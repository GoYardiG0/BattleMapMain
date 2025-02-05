using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class CharacterAddView : ContentPage
{
	public CharacterAddView(CharacterAddViewModel vm)
    {
        this.BindingContext = vm;
        InitializeComponent();
	}
}