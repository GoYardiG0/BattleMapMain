using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BattleMapMain.Views;

namespace BattleMapMain.ViewModels
{
    public class GraphicsDrawable : IDrawable
    {
        public Point p1;
        public Point p2;
        public bool b = false;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 6;
            canvas.DrawLine(10,50,20,50);
            if (b) 
                DrawLine(canvas, dirtyRect);
        }
        
        public void DrawLine(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 6;
            p2 = new Point(0,1);
            canvas.DrawLine(p1,p2);
            
        }
    }
    public class BattleMapViewModel : ViewModelBase
    {
        private IServiceProvider serviceProvider;
        public GraphicsDrawable graphics;
        public BattleMapViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
       
    }
}
