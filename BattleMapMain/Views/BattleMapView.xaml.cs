namespace BattleMapMain.Views;

using BattleMapMain.Classes_and_Objects;
using BattleMapMain.Models;
using BattleMapMain.ViewModels;


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
                currentMini = new Mini(currentImage);
                graphics.AddMini(currentMini);
                graphicsView.Invalidate();
                break;
            case 3: // select mini mode
                graphics.startOrBase = e.Touches.FirstOrDefault();
                currentMini = graphics.GetSelectedMini();
                break;
            case 4: // move mini mode
                graphics.startOrBase = e.Touches.FirstOrDefault();
                graphics.MoveMini(currentMini);
                graphicsView.Invalidate();
                break;
            case 5: // delete mini mode
                graphics.startOrBase = e.Touches.FirstOrDefault();
                graphics.DeleteMini(currentMini);
                graphicsView.Invalidate();
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
                graphics.end = e.Touches.FirstOrDefault();
                graphics.currentImage = currentImage;
                graphicsView.Invalidate();
                break;
            case 3: // delete mini mode

                break;
            case 4: // move mini mode

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
        currentImage = "dragonpfp.png";
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        mode = 2;
        currentImage = "dotnet_bot.png";
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