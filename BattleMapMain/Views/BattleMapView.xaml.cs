namespace BattleMapMain.Views;

using BattleMapMain.Services;
using BattleMapMain.Classes_and_Objects;
using BattleMapMain.Models;
using BattleMapMain.ViewModels;
using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui;


public partial class BattleMapView : ContentPage
{
    BattleMapViewModel vm;
    GraphicsDrawable graphics;
    int mode;
    string currentImage;
    Mini currentMini;
	public BattleMapView(BattleMapViewModel vm)
	{
        mode = 0;
		this.BindingContext = vm;
        this.vm = vm;
        vm.OpenPopup += DisplayPopup;
        vm.UpdateMap += UpdateMapDetails;
        Mini.proxy = vm.proxy;
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (this.BindingContext is  BattleMapViewModel)
        {
            await vm.GetDetailsFromHub();
            var graphicsView = this.MapGraphicsView;
            graphicsView.Invalidate();
        }
    }
    public async void UpdateMapDetails(MapDetails details)
    {
        var graphicsView = this.MapGraphicsView;
        this.graphics = ((GraphicsDrawable)graphicsView.Drawable);
        if (details != null)
        {
            graphics.AllMinis = MapDetails.ConvertTo2DArray(details.AllMinis);
            foreach (Mini mini in graphics.AllMinis)
            {

                if (mini != null)
                   await mini.SetImage();

            }
            graphics.lines = details.Lines;
            graphicsView.Invalidate();            
        }
    }

    public void DisplayPopup(List<string> l)
    {
        var popup = new MiniPickerView((BattleMapViewModel)this.BindingContext);
        this.ShowPopup(popup);
    }

    public async void GraphicsView_StartInteraction(object sender, TouchEventArgs e)
    {
        var graphicsView = this.MapGraphicsView;
        this.graphics = ((GraphicsDrawable)graphicsView.Drawable);
        switch (mode)
        {
            case 0:
                
                break;
                
            case 1: // deafult line                
                graphics.startOrBase = e.Touches.FirstOrDefault();
                break;

            case 2: // add mini mode
                graphics.startOrBase = e.Touches.FirstOrDefault();
                vm.SelectedMini = new Mini(vm.SelectedMini);
                currentMini = vm.SelectedMini;
                graphics.AddMini(currentMini);
                graphicsView.Invalidate();
                await vm.SendDetailsToHub(new MapDetails(graphics.AllMinis, graphics.lines));
                mode = 3;
                break;
            case 3: // select mini mode
                graphics.startOrBase = e.Touches.FirstOrDefault();
                currentMini = graphics.GetSelectedMini();
                vm.SelectedMini = currentMini;
                break;
            case 4: // move mini mode
                graphics.startOrBase = e.Touches.FirstOrDefault();
                graphics.MoveMini(currentMini);
                currentMini = graphics.GetSelectedMini();
                vm.SelectedMini = currentMini;
                graphicsView.Invalidate();                
                await vm.SendDetailsToHub(new MapDetails(graphics.AllMinis, graphics.lines));
                mode = 3;
                break;
            case 5: 
                
                break;
        }


    }
    private async void MapGraphicsView_EndInteraction(object sender, TouchEventArgs e)
    {
        var graphicsView = this.MapGraphicsView;
        this.graphics = ((GraphicsDrawable)graphicsView.Drawable);
        switch (mode)
        {
            default:
                
                break;

            case 1: // deafult line                              
                graphics.end = e.Touches.FirstOrDefault();
                graphics.AddLine();
                graphicsView.Invalidate();
                await vm.SendDetailsToHub(new MapDetails(graphics.AllMinis, graphics.lines));
                break;

            case 2: // add mini mode                
                
                break;
            case 3: // select mini mode

                break;
            case 4: // delete mini mode

                break;
            case 5: // move mini mode

                break;
        }

    }

    private void Clear_Button(object sender, EventArgs e)
    {
        var graphicsView = this.MapGraphicsView;
        this.graphics = ((GraphicsDrawable)graphicsView.Drawable);
        graphics.lines.Clear();
        graphicsView.Invalidate();
    }

    private void Undo_Button(object sender, EventArgs e)
    {
        if (graphics.lines.Count > 0)
        {
        var graphicsView = this.MapGraphicsView;
        this.graphics = ((GraphicsDrawable)graphicsView.Drawable);
        graphics.lines.Remove(graphics.lines[graphics.lines.Count - 1]);
        graphicsView.Invalidate();
        }
    }

    private void Line_Button(object sender, EventArgs e)
    {
        mode = 1;
    }

    private void MiniPickerButton_Clicked(object sender, EventArgs e)
    {
        mode = 2;        
    }

    private void MiniSelect_button(object sender, EventArgs e)
    {
        mode = 3;
    }

    private void MoveMini_Button(object sender, EventArgs e)
    {
        mode = 4;
        vm.SelectedMini = null;
    }

    

    private void DeleteMini_button(object sender, EventArgs e)
    {
        var graphicsView = this.MapGraphicsView;
        this.graphics = ((GraphicsDrawable)graphicsView.Drawable);
        graphics.DeleteMini(currentMini);
        currentMini = null;
        vm.SelectedMini = currentMini;
        graphicsView.Invalidate();
        mode = 3;
    }



    



    //private void GraphicsView_EndInteraction(object sender, TouchEventArgs e)
    //{
    //    var graphicsView = this.MapGraphicsView;
    //    this.graphics = ((GraphicsDrawable)graphicsView.Drawable);
    //    graphics.end = e.Touches.FirstOrDefault();
    //    graphics.b = true;
    //    ((GraphicsView)sender).Invalidate();
    //}
}