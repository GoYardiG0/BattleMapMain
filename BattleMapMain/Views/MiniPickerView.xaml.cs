using BattleMapMain.ViewModels;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace BattleMapMain.Views;

public partial class MiniPickerView : Popup
{
    private BattleMapViewModel _vm;
    public MiniPickerView(BattleMapViewModel vm)
	{
		this.BindingContext = vm;
        _vm = vm;
        _vm.ClosePopup += ClosePopup;
        InitializeComponent();
        this.Closed += OnPopupClosed;
    }

    private void ClosePopup(List<string> l)
    {
        this.Close();
    }
    private void OnPopupClosed(object sender, PopupClosedEventArgs e)
    {
        if (_vm != null)
        {
            _vm.ClosePopup -= ClosePopup; 
        }
    }
}