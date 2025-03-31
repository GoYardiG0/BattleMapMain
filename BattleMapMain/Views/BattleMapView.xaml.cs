namespace BattleMapMain.Views;

using BattleMapMain.Services;
using BattleMapMain.Classes_and_Objects;
using BattleMapMain.Models;
using BattleMapMain.ViewModels;
using Microsoft.Maui.Controls;


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
		InitializeComponent();
	}

    
    public void GraphicsView_StartInteraction(object sender, TouchEventArgs e)
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

            //case 2: // image mode
            //    graphics.mode = 2;
            //    graphics.startOrBase = e.Touches.FirstOrDefault();
            //    break

            case 2: // add mini mode
                graphics.startOrBase = e.Touches.FirstOrDefault();                
                graphics.AddMini(currentMini);
                vm.SelectedMini = currentMini;
                graphicsView.Invalidate();
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
                mode = 3;
                break;
            case 5: 
                
                break;
        }


    }
    private void MapGraphicsView_EndInteraction(object sender, TouchEventArgs e)
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

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        mode = 2;
        currentMini = new Mini(((App)Application.Current).monsters[0]);
        currentMini.SetImage(vm.proxy);
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        mode = 2;
        currentMini = new Mini(((App)Application.Current).monsters[4]);
        currentMini.SetImage(vm.proxy);
    }

    private void MoveMini_Button(object sender, EventArgs e)
    {
        mode = 4;
    }

    private void MiniSelect_button(object sender, EventArgs e)
    {
        mode = 3;
    }

    private void DeleteMini_button(object sender, EventArgs e)
    {
        var graphicsView = this.MapGraphicsView;
        this.graphics = ((GraphicsDrawable)graphicsView.Drawable);
        graphics.DeleteMini(currentMini);
        currentMini = null;
        vm.SelectedMini = currentMini;
        graphicsView.Invalidate();
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