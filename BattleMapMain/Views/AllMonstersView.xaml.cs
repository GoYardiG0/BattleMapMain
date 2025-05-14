using BattleMapMain.ViewModels;

namespace BattleMapMain.Views;

public partial class AllMonstersView : ContentPage
{
	public AllMonstersView(AllMonstersViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (this.BindingContext is AllMonstersViewModel)
        {
            ((AllMonstersViewModel)this.BindingContext).Refresh();
        }
    }
}