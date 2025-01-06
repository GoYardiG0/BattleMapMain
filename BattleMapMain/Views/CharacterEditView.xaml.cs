namespace BattleMapMain.Views;
using BattleMapMain.ViewModels;

public partial class CharacterEditView : ContentPage
{
	public CharacterEditView(CharacterEditViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}