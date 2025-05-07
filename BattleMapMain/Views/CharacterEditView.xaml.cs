namespace BattleMapMain.Views;
using BattleMapMain.ViewModels;
using Microsoft.Extensions.Configuration;

public partial class CharacterEditView : ContentPage
{
	public CharacterEditView(CharacterEditViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
		Reload();
	}

	private async void Reload()
	{
		await Task.Delay(100);
		InitializeComponent();
	}
}