using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class CharacterSheetsView : ContentPage
{
	public CharacterSheetsView(CharacterSheetsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (this.BindingContext is CharacterSheetsViewModel)
        {
            ((CharacterSheetsViewModel)this.BindingContext).Refresh();
        }
    }
}