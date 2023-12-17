using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LIVE_DEMO
{
    public partial class MAIN_FORM : Form
    {
        Rasterization raster;
        private float rotationAngle = 0.0f;
        private float z_pos = 0.01f;
        public MAIN_FORM()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ObjParser parser = new ObjParser("cube.obj");
            //ObjParser parser = new ObjParser("sphere.obj");

            //ObjParser parser = new ObjParser("figure.obj");


            List<float[]> verticesList = parser.Vertices.Select(vertex => new float[] { vertex[0], vertex[1], vertex[2] }).ToList();
            List<int[]> facesList = parser.Faces.Select(face => new int[] { face[0], face[1], face[2] }).ToList();
            List<int[]> triangles = parser.Faces.Select(face => new int[] { face[0], face[1], face[2] }).ToList();

            raster = new Rasterization(PCT_CANVAS.Size, verticesList, triangles, rotationAngle, z_pos);

            PCT_CANVAS.Image = raster.Canvas;
            PCT_CANVAS.Invalidate();
        }


        private void PCT_CANVAS_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            rotationAngle = hScrollBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PCT_CANVAS.Invalidate();
            Init();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            z_pos = hScrollBar2.Value/10;
        }
    }
}