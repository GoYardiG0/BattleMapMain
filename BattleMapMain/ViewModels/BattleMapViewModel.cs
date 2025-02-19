using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BattleMapMain.Classes_and_Objects;
using BattleMapMain.Views;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;


namespace BattleMapMain.ViewModels
{
    public class GraphicsDrawable : IDrawable
    {
        public Point startOrBase;
        public Point end;
        public List<Line> lines = new List<Line>();
        public string currentImage = "dotnet_bot.png";
        //public int mode = 0;
        public Cords currentGridSquare = new Cords(0, 0);
        public Mini[,] AllMinis;
        public Mini currentMini;
        public bool createdAllMinis = false;
        private float boxWidth = 50;
        private float boxHeight = 50;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            DrawGrid(canvas, dirtyRect);
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 6;
            DrawAllLines(canvas, dirtyRect);
            DrawAllMinis(canvas, dirtyRect);
                
        }

        #region mini
        public Mini GetSelectedMini()
        {
            SetGridSquareFromPoint();
            currentMini = AllMinis[currentGridSquare.row, currentGridSquare.col];
            return currentMini;
        }
        public void DeleteMini(Mini mini)
        {
            AllMinis[mini.location.row, mini.location.col] = null;
        }

        public void MoveMini(Mini mini)
        {
            SetGridSquareFromPoint();
            AllMinis[mini.location.row, mini.location.col].location = new Cords(currentGridSquare.row, currentGridSquare.col);
        }
        public void AddMini(Mini mini)
        {
            SetGridSquareFromPoint();
            mini.location = new Cords(currentGridSquare.row, currentGridSquare.col);
            AllMinis[currentGridSquare.row, currentGridSquare.col] = mini;
            currentMini = mini;
        }

        #endregion

        #region draw alls
        private void DrawAllLines(ICanvas canvas, RectF dirtyRect)
        {
            if (lines.Count != 0)
            {
                foreach (Line line in lines)
                {
                    canvas.DrawLine(line.start, line.end);
                }
            }
        }
        public void DrawAllMinis(ICanvas canvas, RectF dirtyRect)
        {
            if (AllMinis != null)
            {

                foreach (Mini mini in AllMinis)
                {

                    if (mini != null)
                    {
                        IImage image;
                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                        using (Stream stream = assembly.GetManifestResourceStream($"BattleMapMain.Resources.Images.{mini.img}"))
                        {
                            image = PlatformImage.FromStream(stream);
                        }

                        if (image != null)
                        {
                            float x = (float)(mini.location.col * boxWidth /*+ boxWidth / 2*/);
                            float y = (float)(mini.location.row * boxHeight /*+ boxHeight / 2*/);
                            canvas.DrawImage(image, x, y, boxWidth, boxHeight);
                        }

                    }

                }

            }
        }
        public void DrawGrid(ICanvas canvas, RectF dirtyRect)
        {

            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 3;
            float rows = dirtyRect.Height / boxHeight;
            float Columns = dirtyRect.Width / boxWidth;
            for (int i = 0; i < rows; i++)
            {
                canvas.DrawLine(dirtyRect.Left, i * boxHeight, dirtyRect.Right, i * boxWidth);
            }
            for (int i = 0; i < Columns + 1; i++)
            {
                canvas.DrawLine(i * boxWidth, dirtyRect.Top, i * boxWidth, dirtyRect.Bottom);
            }
            if (!createdAllMinis)
            {
                createdAllMinis = true;
                AllMinis = new Mini[(int)rows - 1, (int)Columns - 1];
            }
        }

        #endregion

        #region line
        public void AddLine()
        {
            lines.Add(new Line(startOrBase, end));
        }
        #endregion





        public void SetGridSquareFromPoint()
        {
            int row = (int)(startOrBase.Y/boxHeight);
            int col = (int)(startOrBase.X/boxWidth);
            currentGridSquare = new Cords(row, col);
        }        
        
        
    }
    //public void DrawImage(ICanvas canvas, RectF dirtyRect)
    //{
    //    IImage image;
    //    Assembly assembly = GetType().GetTypeInfo().Assembly;
    //    using (Stream stream = assembly.GetManifestResourceStream($"BattleMapMain.Resources.Images.{currentImage}"))
    //    {
    //        image = PlatformImage.FromStream(stream);
    //    }

    //    if (image != null)
    //    {
    //        float height = (float)(Math.Max(startOrBase.Y, end.Y) - Math.Min(startOrBase.Y, end.Y));
    //        float width = (float)(Math.Max(startOrBase.X, end.X) - Math.Min(startOrBase.X, end.X));
    //        float x = (float)(Math.Min(startOrBase.X, end.X));
    //        float y = (float)(Math.Min(startOrBase.Y, end.Y));
    //        canvas.DrawImage(image, x, y, width, height);
    //    }
    //}
    public class BattleMapViewModel : ViewModelBase
    {
        private IServiceProvider serviceProvider;
        public GraphicsDrawable graphics;
        public BattleMapViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            //ChangeImageCommand = new Command(ChangeCurrentImage);
        }

        //public ICommand ChangeImageCommand { get; }

        //private string currentImage;
        //public string CurrentImage
        //{
        //    get => currentImage;
        //    set
        //    {
        //        currentImage = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public void ChangeCurrentImage(object image)
        //{
        //    currentImage=(string)image;
        //    OnPropertyChanged("CurrentImage");
        //}
    }
}
