using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

using System.Windows;

using Line = devDept.Eyeshot.Entities.Line;
using Region = devDept.Eyeshot.Entities.Region;


namespace WpfApp6
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            CompositeCurve profile = new CompositeCurve(
                new Line(0, 0, 50, 0),
                new Line(50, 0, 50, 50),
                new Line(50, 50, 0, 50),
                new Line(0, 50, 0, 0)
            );

            Region region = new Region(profile);

            Brep body = region.ExtrudeAsBrep(20);

            Region holeRegion = new Region(new Circle(Plane.XY, new Point3D(25, 25, 0), 10));

            body.ExtrudeRemove(holeRegion, 20);


            design1.Entities.Add(body, System.Drawing.Color.Blue);

            design1.SetView(viewType.Trimetric);
            design1.ZoomFit();
            design1.Invalidate();
        }
    }
}