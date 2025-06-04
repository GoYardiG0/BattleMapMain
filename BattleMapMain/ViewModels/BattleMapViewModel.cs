using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BattleMapMain.Classes_and_Objects;
using BattleMapMain.Services;
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
        //public int mode = 0;
        public Cords currentGridSquare = new Cords(0, 0);
        public Mini[,] AllMinis;
        public Mini currentMini;
        private float boxWidth = 50;
        private float boxHeight = 50;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            DrawGrid(canvas, dirtyRect);
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 6;            
            DrawAllMinis(canvas, dirtyRect);
            DrawAllLines(canvas, dirtyRect);
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
            currentMini = null;
        }

        public void MoveMini(Mini mini)
        {
            GetSelectedMini();
            if (currentMini == null)
            {
                AllMinis[mini.location.row, mini.location.col] = null;
                mini.location = new Cords(currentGridSquare.row, currentGridSquare.col);
                AllMinis[currentGridSquare.row, currentGridSquare.col] = mini;
            }
            

        }
        public void AddMini(Mini mini)
        {
            GetSelectedMini();
            if (currentMini == null)
            {
                mini.location = new Cords(currentGridSquare.row, currentGridSquare.col);
                AllMinis[currentGridSquare.row, currentGridSquare.col] = mini;
            }            
            
        }

        #endregion

        #region draw alls
        private void DrawAllLines(ICanvas canvas, RectF dirtyRect)
        {
            if (lines != null)
            {
                if (lines.Count != 0)
                {
                    foreach (Line line in lines)
                    {
                        canvas.DrawLine(line.start, line.end);
                    }
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


                        if (mini.img != null)
                        {
                            float x = (float)(mini.location.col * boxWidth + 1.5 /*+ boxWidth / 2*/);
                            float y = (float)(mini.location.row * boxHeight + 1.5 /*+ boxHeight / 2*/);
                            PathF path = new PathF();
                            //path.AppendCircle(x+ boxWidth / 2, y+ boxWidth / 2, boxWidth/2-2);
                            //canvas.ClipPath(path);
                            canvas.DrawImage(mini.img, x, y, boxWidth-3, boxHeight-3);
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
            if (AllMinis == null || AllMinis.Length == 0)
            {
                AllMinis = new Mini[(int)rows + 1, (int)Columns + 1];
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
    public partial class BattleMapViewModel : ViewModelBase
    {
        public event Action<List<string>> OpenPopup;
        public event Func<MapDetails, Task> UpdateMap;
        private IServiceProvider serviceProvider;
        public BattleMapWebAPIProxy proxy;
        public BattleMapProxy hubProxy;

        public BattleMapViewModel(IServiceProvider serviceProvider, BattleMapWebAPIProxy proxy, BattleMapProxy hubProxy)
        {
            this.serviceProvider = serviceProvider;
            this.proxy = proxy;
            MiniDetailsCommand = new Command(GoToMiniDetails);
            GoToMiniPickerCommand = new Command(GoToMiniPicker);
            this.hubProxy = hubProxy;
            //ChangeImageCommand = new Command(ChangeCurrentImage);
        }

        private Mini selectedMini;
        public Mini SelectedMini
        {
            get => selectedMini;
            set
            {
                selectedMini = value;
                OnPropertyChanged();
                OnPropertyChanged("IsSelectedMini");
            }
        }
        public bool IsSelectedMini
        {
            get
            {
                if (selectedMini == null)
                    return false;
                return true;
            }            
        }
        public ICommand GoToMiniPickerCommand { get; }

        async void GoToMiniPicker()
        {
            if (OpenPopup != null)
            {
                List<string> l = new List<string>();
                InitData();
                OpenPopup(l);
            }
        }
        public ICommand MiniDetailsCommand { get; }


        async void GoToMiniDetails()
        {
            if (selectedMini.monster != null)
            {
                var navParam = new Dictionary<string, object>()
                {
                    { "Monster",selectedMini.monster }
                };
                await Shell.Current.GoToAsync("MonsterDetails", navParam);
            }
            else if (selectedMini.character != null)
            {
                var navParam = new Dictionary<string, object>()
                {
                    { "Character",selectedMini.character }
                };
                await Shell.Current.GoToAsync("CharacterDetails", navParam);
            }
        }

        public async void UpdateMapDetails(MapDetails details)
        {
            Object obj = new Object();
            lock (obj)
            {
                Task t = UpdateMap(details);
                t.Wait();
                SelectedMini = null;
            }

        }

        public async Task GetDetailsFromHub()
        {
            UpdateMap(await hubProxy.GetDetails());
        }

        public async Task SendDetailsToHub(MapDetails details)
        {
            await hubProxy.SendDetails(details);
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
