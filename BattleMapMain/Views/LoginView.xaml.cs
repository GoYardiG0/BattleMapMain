namespace BattleMapMain.Views;
using BattleMapMain.ViewModels;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}