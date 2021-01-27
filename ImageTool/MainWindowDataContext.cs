using ImageTool.Models;
using ImageTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageTool
{
    public class MainWindowDataContext : ObservableObject
    {
        private List<ImageItem> list;
        private ImageMode mode = ImageMode.Rotate;
        private List<RotateDegreeInfo> degrees;
        private RotateDegreeInfo degree;
        private static Dictionary<ImageMode, string> modeMap = new Dictionary<ImageMode, string>()
        {
            { ImageMode.Rotate,"_Rotate"}
        };
        private TaskState state;

        public MainWindowDataContext()
        {
            Degrees = new List<RotateDegreeInfo> {
                new RotateDegreeInfo{Degree=RotateDegree.D90,Name="90°"},
                new RotateDegreeInfo{Degree=RotateDegree.D180,Name="180°"},
                new RotateDegreeInfo{Degree=RotateDegree.D270,Name="270°"}
            };
            Degree = degrees[0];
        }

        public List<RotateDegreeInfo> Degrees { get => degrees; set => Set(ref degrees, value); }
        public RotateDegreeInfo Degree { get => degree; set => Set(ref degree, value); }

        public List<ImageItem> List { get => list; set => Set(ref list, value); }
        public ImageMode Mode { get => mode; set => Set(ref mode, value); }
        public TaskState State { get => state; set => Set(ref state, value); }

        public void SetList(string[] fileNames)
        {
            State = TaskState.Load;
            var extra = modeMap[mode];
            List = fileNames.Select(t =>
            {
                int index;
                string newName;
                if ((index = t.LastIndexOf(".")) != -1)
                {
                    newName = t.Insert(index, extra);
                }
                else
                {
                    newName = t.Insert(t.Length, extra);
                }
                return new ImageItem { Name = t, NewName = newName };
            }).ToList();
        }

        public void HandleImage()
        {
            State = TaskState.Running;
            ImageService service = new ImageService();
            service.Rotate(List, Degree.Degree);
            State = TaskState.Complete;
        }
    }
}
