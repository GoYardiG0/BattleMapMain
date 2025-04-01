using BattleMapMain.ViewModels;
using CommunityToolkit.Maui.Views;

namespace BattleMapMain.Views;

public partial class MiniPickerView : Popup
{
	public MiniPickerView(BattleMapViewModel vm)
	{
		this.BindingContext = vm;
        vm.ClosePopup += ClosePopup;
        InitializeComponent();
	}

    private void ClosePopup(List<string> l)
    {
        this.Close();
    }
}