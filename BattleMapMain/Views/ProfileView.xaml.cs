namespace BattleMapMain.Views;
using BattleMapMain.ViewModels;

public partial class ProfileView : ContentPage
{
	public ProfileView(ProfileViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}