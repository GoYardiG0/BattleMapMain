namespace BattleMapMain.Views;

using BattleMapMain.ViewModels;


public partial class BattleMapView : ContentPage
{
    BattleMapViewModel vm;
    GraphicsDrawable graphics;
	public BattleMapView(BattleMapViewModel vm)
	{
        
		this.BindingContext = vm;
        this.vm = vm;
		InitializeComponent();
	}


    public void GraphicsView_StartInteraction(object sender, TouchEventArgs e)
    {
        var graphicsView = this.MapGraphicsView;
        this.graphics = ((GraphicsDrawable)graphicsView.Drawable);
        graphics.p1 = e.Touches.FirstOrDefault();
        graphics.b = true;
        ((GraphicsView)sender).Invalidate();
    }

    private void GraphicsView_EndInteraction(object sender, TouchEventArgs e)
    {
        graphics.p2 = e.Touches.FirstOrDefault();
        ((GraphicsView)sender).IsVisible = false;

        ((GraphicsView)sender).IsVisible = true;
        ((GraphicsView)sender).Invalidate();
    }
}