﻿using System;
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
        public Point p1;
        public Point p2;
        public List<Line> lines = new List<Line>();
        public string currentImage = "dotnet_bot.png";
        public int mode = 0;
        
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 6;
            if (lines.Count != 0 )
            {
                foreach ( Line line in lines )
                {
                    canvas.DrawLine(line.start, line.end);
                }
            }
            switch (mode)
            {
                case 0:
                    break;
                case 1:
                    DrawLine(canvas, dirtyRect);
                    break;
                case 2:
                    DrawImage(canvas, dirtyRect);
                    break;
            }
                
        }
        
        public void DrawLine(ICanvas canvas, RectF dirtyRect)
        {
            canvas.DrawLine(p1,p2);
            lines.Add(new Line(p1,p2));
            mode = 0;
        }
        public void DrawImage(ICanvas canvas, RectF dirtyRect)
        {
            IImage image;
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream($"BattleMapMain.Resources.Images.{currentImage}"))
            {
                image = PlatformImage.FromStream(stream);
            }

            if (image != null)
            {
                float height = (float)(Math.Max(p1.Y, p2.Y) - Math.Min(p1.Y, p2.Y));
                float width = (float)(Math.Max(p1.X, p2.X) - Math.Min(p1.X, p2.X));
                float x = (float)((p1.X + p2.X) / 2);
                float y = (float)((p1.Y + p2.Y) / 2);
                canvas.DrawImage(image, x, y, width, height);
            }
        }
    }
    public class BattleMapViewModel : ViewModelBase
    {
        private IServiceProvider serviceProvider;
        public GraphicsDrawable graphics;
        public BattleMapViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            ChangeImageCommand = new Command(ChangeCurrentImage);
        }

        public ICommand ChangeImageCommand { get; }

        private string currentImage;
        public string CurrentImage
        {
            get => currentImage;
            set
            {
                currentImage = value;
                OnPropertyChanged();
            }
        }

        public void ChangeCurrentImage(object image)
        {
            currentImage=(string)image;
            OnPropertyChanged("CurrentImage");
        }
    }
}
