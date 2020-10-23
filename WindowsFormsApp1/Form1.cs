
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        private Bitmap window;
        private Graphics graph;
        private TCube[] c;
        private TPoint COP;
        private TPoint VRP;
        private TPoint VRPV;
        private TPoint WC;
        private TVector VPN;
        private TVector VUP;
        private TVector u;
        private TVector v;
        private TVector n;
        private TVector DOP;
        private double[,] T1n2;
        private double[,] T3;
        private double[,] T4;
        private double[,] T5;
        private double[,] T6;
        private double wxmin;
        private double wxmax;
        private double wymin;
        private double wymax;
        private double shx;
        private double shy;
        private double FP;
        private double BP;
        private double k;
        private double sx;
        private double sy;
        private double sz;
        private double zmin;
        private double zmax;
        private double near;
        private double alpha;
        private bool Forw;
        private bool Back;
        private bool Righ;
        private bool Lef;
        private bool Rplus;
        private bool Rmin;
        

     
        public Form1()
        {
            InitializeComponent();
         //   this.Load += new EventHandler(this.Form1_Load);
            this.window = new Bitmap(400, 400);
            this.graph = Graphics.FromImage((Image)this.window);
            this.c = new Form1.TCube[9];
            this.T1n2 = new double[4, 4];
            this.T3 = new double[4, 4];
            this.T4 = new double[4, 4];
            this.T5 = new double[4, 4];
            this.T6 = new double[4, 4];
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetPoint(ref this.COP, 0.0, 0.0, 4.0);
            this.SetPoint(ref this.VRP, 0.0, 0.0, 4.0);
            this.SetPoint(ref this.VRPV, 0.0, 0.0, 0.0);
            this.SetVector(ref this.VPN, 0.0, 0.0, 1.0);
            this.SetVector(ref this.VUP, 0.0, 1.0, 0.0);
            this.wxmin = -2.0;
            this.wxmax = 2.0;
            this.wymin = -2.0;
            this.wymax = 2.0;
            this.FP = 2.0;
            this.BP = -10.0;
            this.near = 0.0;
            this.alpha = Math.PI / 2.0;
            this.Forw = false;
            this.Back = false;
            this.Righ = false;
            this.Lef = false;
            this.Rplus = false;
            this.Rmin = false;
            System.Windows.Forms.Timer Timer1 = new System.Windows.Forms.Timer();
            this.Timer1.Enabled = false;
            this.Process();
        }

       public void ClearWindow() => graph.FillRectangle(Brushes.Black, 0, 0, this.boxCanvas.Width,this.boxCanvas.Height); // window (umin, vmin, umax, vmax)

        public void SetVector(ref Form1.TVector V, double x, double y, double z)
        {
            V.x = x;
            V.y = y;
            V.z = z;
        }

        public double VectorLength(Form1.TVector V) => Math.Pow(V.x * V.x + V.y * V.y + V.z * V.z, 0.5);

        public Form1.TVector UnitVector(Form1.TVector V)
        {
            Form1.TVector tvector;
            tvector.x = V.x / this.VectorLength(V);
            tvector.y = V.y / this.VectorLength(V);
            tvector.z = V.z / this.VectorLength(V);
            return tvector;
        }

        public Form1.TVector AddVectors(Form1.TVector V1, Form1.TVector V2)
        {
            Form1.TVector tvector;
            tvector.x = V1.x + V2.x;
            tvector.y = V1.y + V2.y;
            tvector.z = V1.z + V2.z;
            return tvector;
        }

        public Form1.TVector MultiplyVector(double s, Form1.TVector V)
        {
            Form1.TVector tvector;
            tvector.x = s * V.x;
            tvector.y = s * V.y;
            tvector.z = s * V.z;
            return tvector;
        }

        public double DotProduct(Form1.TVector V1, Form1.TVector V2) => V1.x * V2.x + V1.y * V2.y + V1.z * V2.z;

        public Form1.TVector CrossProduct(Form1.TVector V1, Form1.TVector V2)
        {
            Form1.TVector tvector;
            tvector.x = V1.y * V2.z - V2.y * V1.z;
            tvector.y = V1.z * V2.x - V2.z * V1.x;
            tvector.z = V1.x * V2.y - V2.x * V1.y;
            return tvector;
        }

        public void SetPoint(ref Form1.TPoint P, double x, double y, double z)
        {
            P.x = x;
            P.y = y;
            P.z = z;
            P.w = 1.0;
        }

        public void SetLine(ref Form1.TLine L, int p1, int p2)
        {
            L.p1 = p1;
            L.p2 = p2;
        }

        public void SetCubes()
        {
            int start = 0;
            do
            {
                this.c[start].P = new Form1.TPoint[8];
                checked { ++start; }
            }
            while (start <= 8);
            int startline = 0;
            do
            {
                this.c[startline].L = new Form1.TLine[12];
                checked { ++startline; }
            }
            while (startline <= 8);
            this.SetPoint(ref this.c[0].P[0], -5.0, 1.0, 5.0);
            this.SetPoint(ref this.c[0].P[1], -3.0, 1.0, 5.0);
            this.SetPoint(ref this.c[0].P[2], -3.0, -1.0, 5.0);
            this.SetPoint(ref this.c[0].P[3], -5.0, -1.0, 5.0);
            this.SetPoint(ref this.c[0].P[4], -5.0, 1.0, 3.0);
            this.SetPoint(ref this.c[0].P[5], -3.0, 1.0, 3.0);
            this.SetPoint(ref this.c[0].P[6], -3.0, -1.0, 3.0);
            this.SetPoint(ref this.c[0].P[7], -5.0, -1.0, 3.0);
            this.SetPoint(ref this.c[1].P[0], -1.0, 1.0, 5.0);
            this.SetPoint(ref this.c[1].P[1], 1.0, 1.0, 5.0);
            this.SetPoint(ref this.c[1].P[2], 1.0, -1.0, 5.0);
            this.SetPoint(ref this.c[1].P[3], -1.0, -1.0, 5.0);
            this.SetPoint(ref this.c[1].P[4], -1.0, 1.0, 3.0);
            this.SetPoint(ref this.c[1].P[5], 1.0, 1.0, 3.0);
            this.SetPoint(ref this.c[1].P[6], 1.0, -1.0, 3.0);
            this.SetPoint(ref this.c[1].P[7], -1.0, -1.0, 3.0);
            this.SetPoint(ref this.c[2].P[0], 3.0, 1.0, 5.0);
            this.SetPoint(ref this.c[2].P[1], 5.0, 1.0, 5.0);
            this.SetPoint(ref this.c[2].P[2], 5.0, -1.0, 5.0);
            this.SetPoint(ref this.c[2].P[3], 3.0, -1.0, 5.0);
            this.SetPoint(ref this.c[2].P[4], 3.0, 1.0, 3.0);
            this.SetPoint(ref this.c[2].P[5], 5.0, 1.0, 3.0);
            this.SetPoint(ref this.c[2].P[6], 5.0, -1.0, 3.0);
            this.SetPoint(ref this.c[2].P[7], 3.0, -1.0, 3.0);
            this.SetPoint(ref this.c[3].P[0], -5.0, 1.0, 1.0);
            this.SetPoint(ref this.c[3].P[1], -3.0, 1.0, 1.0);
            this.SetPoint(ref this.c[3].P[2], -3.0, -1.0, 1.0);
            this.SetPoint(ref this.c[3].P[3], -5.0, -1.0, 1.0);
            this.SetPoint(ref this.c[3].P[4], -5.0, 1.0, -1.0);
            this.SetPoint(ref this.c[3].P[5], -3.0, 1.0, -1.0);
            this.SetPoint(ref this.c[3].P[6], -3.0, -1.0, -1.0);
            this.SetPoint(ref this.c[3].P[7], -5.0, -1.0, -1.0);
            this.SetPoint(ref this.c[4].P[0], -1.0, 1.0, 1.0);
            this.SetPoint(ref this.c[4].P[1], 1.0, 1.0, 1.0);
            this.SetPoint(ref this.c[4].P[2], 1.0, -1.0, 1.0);
            this.SetPoint(ref this.c[4].P[3], -1.0, -1.0, 1.0);
            this.SetPoint(ref this.c[4].P[4], -1.0, 1.0, -1.0);
            this.SetPoint(ref this.c[4].P[5], 1.0, 1.0, -1.0);
            this.SetPoint(ref this.c[4].P[6], 1.0, -1.0, -1.0);
            this.SetPoint(ref this.c[4].P[7], -1.0, -1.0, -1.0);
            this.SetPoint(ref this.c[5].P[0], 3.0, 1.0, 1.0);
            this.SetPoint(ref this.c[5].P[1], 5.0, 1.0, 1.0);
            this.SetPoint(ref this.c[5].P[2], 5.0, -1.0, 1.0);
            this.SetPoint(ref this.c[5].P[3], 3.0, -1.0, 1.0);
            this.SetPoint(ref this.c[5].P[4], 3.0, 1.0, -1.0);
            this.SetPoint(ref this.c[5].P[5], 5.0, 1.0, -1.0);
            this.SetPoint(ref this.c[5].P[6], 5.0, -1.0, -1.0);
            this.SetPoint(ref this.c[5].P[7], 3.0, -1.0, -1.0);
            this.SetPoint(ref this.c[6].P[0], -5.0, 1.0, -3.0);
            this.SetPoint(ref this.c[6].P[1], -3.0, 1.0, -3.0);
            this.SetPoint(ref this.c[6].P[2], -3.0, -1.0, -3.0);
            this.SetPoint(ref this.c[6].P[3], -5.0, -1.0, -3.0);
            this.SetPoint(ref this.c[6].P[4], -5.0, 1.0, -5.0);
            this.SetPoint(ref this.c[6].P[5], -3.0, 1.0, -5.0);
            this.SetPoint(ref this.c[6].P[6], -3.0, -1.0, -5.0);
            this.SetPoint(ref this.c[6].P[7], -5.0, -1.0, -5.0);
            this.SetPoint(ref this.c[7].P[0], -1.0, 1.0, -3.0);
            this.SetPoint(ref this.c[7].P[1], 1.0, 1.0, -3.0);
            this.SetPoint(ref this.c[7].P[2], 1.0, -1.0, -3.0);
            this.SetPoint(ref this.c[7].P[3], -1.0, -1.0, -3.0);
            this.SetPoint(ref this.c[7].P[4], -1.0, 1.0, -5.0);
            this.SetPoint(ref this.c[7].P[5], 1.0, 1.0, -5.0);
            this.SetPoint(ref this.c[7].P[6], 1.0, -1.0, -5.0);
            this.SetPoint(ref this.c[7].P[7], -1.0, -1.0, -5.0);
            this.SetPoint(ref this.c[8].P[0], 3.0, 1.0, -3.0);
            this.SetPoint(ref this.c[8].P[1], 5.0, 1.0, -3.0);
            this.SetPoint(ref this.c[8].P[2], 5.0, -1.0, -3.0);
            this.SetPoint(ref this.c[8].P[3], 3.0, -1.0, -3.0);
            this.SetPoint(ref this.c[8].P[4], 3.0, 1.0, -5.0);
            this.SetPoint(ref this.c[8].P[5], 5.0, 1.0, -5.0);
            this.SetPoint(ref this.c[8].P[6], 5.0, -1.0, -5.0);
            this.SetPoint(ref this.c[8].P[7], 3.0, -1.0, -5.0);
            int index3 = 0;
            do
            {
                this.SetLine(ref this.c[index3].L[0], 0, 1);
                this.SetLine(ref this.c[index3].L[1], 1, 2);
                this.SetLine(ref this.c[index3].L[2], 2, 3);
                this.SetLine(ref this.c[index3].L[3], 3, 0);
                this.SetLine(ref this.c[index3].L[4], 4, 5);
                this.SetLine(ref this.c[index3].L[5], 5, 6);
                this.SetLine(ref this.c[index3].L[6], 6, 7);
                this.SetLine(ref this.c[index3].L[7], 7, 4);
                this.SetLine(ref this.c[index3].L[8], 0, 4);
                this.SetLine(ref this.c[index3].L[9], 1, 5);
                this.SetLine(ref this.c[index3].L[10], 2, 6);
                this.SetLine(ref this.c[index3].L[11], 3, 7);
                checked { ++index3; }
            }
            while (index3 <= 8);
        }

        public void TransformCube(ref Form1.TCube cu, double[,] M)
        {
            int index = 0;
            do
            {
                cu.P[index] = this.Transform(cu.P[index], M);
                checked { ++index; }
            }
            while (index <= 7);
        }

        public void TransformCubes(double[,] M)
        {
            int index = 0;
            do
            {
                this.TransformCube(ref this.c[index], M);
                checked { ++index; }
            }
            while (index <= 8);
        }

        public void DrawCube(Form1.TCube cu, Pen p)
        {
            int index = 0;
            do
            {
                Form1.TPoint v1_1 = new TPoint();
                this.SetPoint(ref v1_1, cu.P[cu.L[index].p1].x, cu.P[cu.L[index].p1].y, cu.P[cu.L[index].p1].z);
                v1_1.w = cu.P[cu.L[index].p1].w;
                Form1.TPoint v1_2 = new TPoint();
                this.SetPoint(ref v1_2, cu.P[cu.L[index].p2].x, cu.P[cu.L[index].p2].y, cu.P[cu.L[index].p2].z);
                v1_2.w = cu.P[cu.L[index].p2].w;
                if (v1_1.w > this.near | v1_2.w > this.near)
                {
                    if (v1_2.w <= this.near)
                    {
                        this.ClipLine(v1_1, ref v1_2);
                    }
                    else
                    {
                        v1_2.x /= v1_2.w;
                        v1_2.y /= v1_2.w;
                        v1_2.z /= v1_2.w;
                        v1_2.w = 1.0;
                    }
                    if (v1_1.w <= this.near)
                    {
                        this.ClipLine(v1_2, ref v1_1);
                    }
                    else
                    {
                        v1_1.x /= v1_1.w;
                        v1_1.y /= v1_1.w;
                        v1_1.z /= v1_1.w;
                        v1_1.w = 1.0;
                    }
                    if (this.CSClip(ref v1_1, ref v1_2))
                        this.graph.DrawLine(p, checked((int)Math.Round(unchecked(v1_1.x * 100.0 + 150.0))), checked((int)Math.Round(unchecked(v1_1.y * -100.0 + 150.0))), checked((int)Math.Round(unchecked(v1_2.x * 100.0 + 150.0))), checked((int)Math.Round(unchecked(v1_2.y * -100.0 + 150.0))));
                }
                checked { ++index; }
            }
            while (index <= 11);
        }

        public void DrawCubes()
        {
            this.DrawCube(this.c[8], Pens.Red);
            this.DrawCube(this.c[7], Pens.Orange);
            this.DrawCube(this.c[6], Pens.Yellow);
            this.DrawCube(this.c[5], Pens.Green);
            this.DrawCube(this.c[4], Pens.Blue);
            this.DrawCube(this.c[3], Pens.Violet);
            this.DrawCube(this.c[2], Pens.Purple);
            this.DrawCube(this.c[1], Pens.Brown);
            this.DrawCube(this.c[0], Pens.Aquamarine);
        }

        public void SetRowMatrix(ref double[,] M, int row, double a, double b, double c, double d)
        {
            M[row, 0] = a;
            M[row, 1] = b;
            M[row, 2] = c;
            M[row, 3] = d;
        }

        public Form1.TPoint Transform(Form1.TPoint P, double[,] M)
        {
            Form1.TPoint tpoint;
            tpoint.x = P.x * M[0, 0] + P.y * M[1, 0] + P.z * M[2, 0] + P.w * M[3, 0];
            tpoint.y = P.x * M[0, 1] + P.y * M[1, 1] + P.z * M[2, 1] + P.w * M[3, 1];
            tpoint.z = P.x * M[0, 2] + P.y * M[1, 2] + P.z * M[2, 2] + P.w * M[3, 2];
            tpoint.w = P.x * M[0, 3] + P.y * M[1, 3] + P.z * M[2, 3] + P.w * M[3, 3];
            return tpoint;
        }

        public void DrawWindow()
        {
            this.graph.DrawLine(Pens.Black, 50, 250, 250, 250);
            this.graph.DrawLine(Pens.Black, 50, 50, 250, 50);
            this.graph.DrawLine(Pens.Black, 250, 50, 250, 250);
            this.graph.DrawLine(Pens.Black, 50, 50, 50, 250);
        }

        public void Process()
        {
            this.ClearWindow();
            this.n = this.UnitVector(this.VPN);
            this.v = this.UnitVector(this.AddVectors(this.VUP, this.MultiplyVector(-1.0 * this.DotProduct(this.n, this.VUP), this.n)));
            this.u = this.UnitVector(this.CrossProduct(this.v, this.n));
            // ini declare matrix M dari PPT 5 slide 9
            double[,] M = new double[4, 4];
            this.SetRowMatrix(ref M, 0, this.u.x, this.v.x, this.n.x, 0.0);
            this.SetRowMatrix(ref M, 1, this.u.y, this.v.y, this.n.y, 0.0);
            this.SetRowMatrix(ref M, 2, this.u.z, this.v.z, this.n.z, 0.0);
            this.SetRowMatrix(ref M, 3, 0.0, 0.0, 0.0, 1.0);
            this.VRPV = this.Transform(this.VRP, M);
            this.SetPoint(ref this.WC, (this.wxmin + this.wxmax) / 2.0, (this.wymin + this.wymax) / 2.0, 0.0);
            this.SetVector(ref this.DOP, this.WC.x - this.COP.x, this.WC.y - this.COP.y, this.WC.z - this.COP.z);

            this.shx = -this.DOP.x / this.DOP.z; // harusnya -DOPx based dari ppt 
            this.shy = -this.DOP.y / this.DOP.z; // -//- -DOPy based dari ppy
            this.k = this.BP - this.COP.z; // ini sama kayak B4/B3 (Back plane yang udah melakukan 4 transformasi
            this.sx = 2.0 * -this.COP.z / ((this.wxmax - this.wxmin) * this.k);
            this.sy = 2.0 * -this.COP.z / ((this.wymax - this.wymin) * this.k);
            this.sz = -1.0 / (this.BP - this.COP.z);
            this.zmin = -((-this.COP.z + this.FP) / this.k);

            this.shx = (- this.DOP.x / this.DOP.z);
            this.shy = -(this.DOP.y / this.DOP.z);
            this.k = -this.COP.z + this.BP; 
            this.sx = 2.0 * -this.COP.z / ((this.wxmax - this.wxmin) * this.k);
            this.sy = 2.0 * -this.COP.z / ((this.wymax - this.wymin) * this.k);
            this.sz = -1.0 / (-this.COP.z + this.BP);
            this.zmin = -((-this.COP.z ) / this.k);

            this.zmax = -1.0;
            this.SetRowMatrix(ref this.T1n2, 0, this.u.x, this.v.x, this.n.x, 0.0);
            this.SetRowMatrix(ref this.T1n2, 1, this.u.y, this.v.y, this.n.y, 0.0);
            this.SetRowMatrix(ref this.T1n2, 2, this.u.z, this.v.z, this.n.z, 0.0);
            this.SetRowMatrix(ref this.T1n2, 3, -this.VRPV.x, -this.VRPV.y, -this.VRPV.z, 1.0); // ini di PPT 5 slide 12, 
            this.SetRowMatrix(ref this.T3, 0, 1.0, 0.0, 0.0, 0.0);
            this.SetRowMatrix(ref this.T3, 1, 0.0, 1.0, 0.0, 0.0);
            this.SetRowMatrix(ref this.T3, 2, 0.0, 0.0, 1.0, 0.0);
            this.SetRowMatrix(ref this.T3, 3, -this.COP.x, -this.COP.y, -this.COP.z, 1.0); // -COPx sama kayak -eu di ppt 5 slide 27. bedanya COPx itu coordinate COP yang ada di WCS
            this.SetRowMatrix(ref this.T4, 0, 1.0, 0.0, 0.0, 0.0);
            this.SetRowMatrix(ref this.T4, 1, 0.0, 1.0, 0.0, 0.0);
            this.SetRowMatrix(ref this.T4, 2, this.shx, this.shy, 1.0, 0.0);
            this.SetRowMatrix(ref this.T4, 3, 0.0, 0.0, 0.0, 1.0);
            this.SetRowMatrix(ref this.T5, 0, this.sx, 0.0, 0.0, 0.0);
            this.SetRowMatrix(ref this.T5, 1, 0.0, this.sy, 0.0, 0.0);
            this.SetRowMatrix(ref this.T5, 2, 0.0, 0.0, this.sz, 0.0);
            this.SetRowMatrix(ref this.T5, 3, 0.0, 0.0, 0.0, 1.0);
            this.SetRowMatrix(ref this.T6, 0, 1.0, 0.0, 0.0, 0.0);
            this.SetRowMatrix(ref this.T6, 1, 0.0, 1.0, 0.0, 0.0);
            this.SetRowMatrix(ref this.T6, 2, 0.0, 0.0, 1.0 / (1.0 + this.zmin), this.zmax);
            this.SetRowMatrix(ref this.T6, 3, 0.0, 0.0, -this.zmin / (1.0 + this.zmin), 0.0);
            this.SetCubes();
            this.TransformCubes(this.T1n2);
            this.TransformCubes(this.T3);
            this.TransformCubes(this.T4);
            this.TransformCubes(this.T5);
            this.TransformCubes(this.T6);
            this.DrawCubes();
            this.DrawWindow();
            this.boxCanvas.Image = (Image)this.window;
        }

        public int CSAnd(Form1.CSBits b1, Form1.CSBits b2)
        {
            int num = 0;
            if (b1.Above & b2.Above)
                checked { num += 32; }
            if (b1.Below & b2.Below)
                checked { num += 16; }
            if (b1.Right & b2.Right)
                checked { num += 8; }
            if (b1.Left & b2.Left)
                checked { num += 4; }
            if (b1.Front & b2.Front)
                checked { num += 2; }
            if (b1.Back & b2.Back)
                checked { ++num; }
            return num;
        }

        public int CSOr(Form1.CSBits b1, Form1.CSBits b2)
        {
            int num = 0;
            if (b1.Above | b2.Above)
                checked { num += 32; }
            if (b1.Below | b2.Below)
                checked { num += 16; }
            if (b1.Right | b2.Right)
                checked { num += 8; }
            if (b1.Left | b2.Left)
                checked { num += 4; }
            if (b1.Front | b2.Front)
                checked { num += 2; }
            if (b1.Back | b2.Back)
                checked { ++num; }
            return num;
        }

        public Form1.CSBits CSCode(Form1.TPoint p)
        {
            Form1.CSBits csBits;
            csBits.Above = p.y > 1.0;
            csBits.Below = p.y < -1.0;
            csBits.Right = p.x > 1.0;
            csBits.Left = p.x < -1.0;
            csBits.Front = p.z > 0.0;
            csBits.Back = p.z < -1.0;
            return csBits;
        }

        public bool CSClip(ref Form1.TPoint p1, ref Form1.TPoint p2)
        {
            bool flag1;
            bool flag2 = false;
            do
            {
                flag1 = false;
                Form1.CSBits csBits = this.CSCode(p1);
                Form1.CSBits b2 = this.CSCode(p2);
                if (this.CSOr(csBits, b2) == 0)
                    flag2 = true;
                else if (this.CSAnd(csBits, b2) > 0)
                {
                    flag2 = false;
                }
                else
                {
                    flag1 = true;
                    Form1.CSBits b1;
                    Form1.TPoint tpoint1;
                    Form1.TPoint tpoint2;
                    if (this.CSAnd(csBits, csBits) > 0)
                    {
                        b1 = csBits;
                        tpoint1 = p2;
                        tpoint2 = p1;
                    }
                    else
                    {
                        b1 = b2;
                        tpoint1 = p1;
                        tpoint2 = p2;
                    }
                    double x;
                    double y;
                    double z;
                    if (b1.Above)
                    {
                        x = tpoint1.x + (tpoint2.x - tpoint1.x) * (1.0 - tpoint1.y) / (tpoint2.y - tpoint1.y);
                        y = 1.0;
                        z = tpoint1.z + (tpoint2.z - tpoint1.z) * (1.0 - tpoint1.y) / (tpoint2.y - tpoint1.y);
                    }
                    else if (b1.Below)
                    {
                        x = tpoint1.x + (tpoint2.x - tpoint1.x) * (-1.0 - tpoint1.y) / (tpoint2.y - tpoint1.y);
                        y = -1.0;
                        z = tpoint1.z + (tpoint2.z - tpoint1.z) * (-1.0 - tpoint1.y) / (tpoint2.y - tpoint1.y);
                    }
                    else if (b1.Right)
                    {
                        x = 1.0;
                        y = tpoint1.y + (tpoint2.y - tpoint1.y) * (1.0 - tpoint1.x) / (tpoint2.x - tpoint1.x);
                        z = tpoint1.z + (tpoint2.z - tpoint1.z) * (1.0 - tpoint1.x) / (tpoint2.x - tpoint1.x);
                    }
                    else if (b1.Left)
                    {
                        x = -1.0;
                        y = tpoint1.y + (tpoint2.y - tpoint1.y) * (-1.0 - tpoint1.x) / (tpoint2.x - tpoint1.x);
                        z = tpoint1.z + (tpoint2.z - tpoint1.z) * (-1.0 - tpoint1.x) / (tpoint2.x - tpoint1.x);
                    }
                    else if (b1.Front)
                    {
                        x = tpoint1.x + (tpoint2.x - tpoint1.x) * (0.0 - tpoint1.z) / (tpoint2.z - tpoint1.z);
                        y = tpoint1.y + (tpoint2.y - tpoint1.y) * (0.0 - tpoint1.z) / (tpoint2.z - tpoint1.z);
                        z = 0.0;
                    }
                    else
                    {
                        x = tpoint1.x + (tpoint2.x - tpoint1.x) * (-1.0 - tpoint1.z) / (tpoint2.z - tpoint1.z);
                        y = tpoint1.y + (tpoint2.y - tpoint1.y) * (-1.0 - tpoint1.z) / (tpoint2.z - tpoint1.z);
                        z = -1.0;
                    }
                    if (this.CSAnd(b1, csBits) == this.CSOr(b1, csBits))
                    {
                        this.SetPoint(ref p1, x, y, z);
                        this.CSCode(p1);
                    }
                    else
                    {
                        this.SetPoint(ref p2, x, y, z);
                        this.CSCode(p2);
                    }
                }
            }
            while (flag1);
            return flag2;
        }

        public void ClipLine(Form1.TPoint v1, ref Form1.TPoint v2)
        {
            double num = (v1.w - this.near) / (v1.w - v2.w);
            double x = num * v1.x + (1.0 - num) * v2.x;
            double y = num * v1.y + (1.0 - num) * v2.y;
            double z = num * v1.z + (1.0 - num) * v2.z;
            this.SetPoint(ref v2, x, y, z);
        }

        public void MoveCamera(double r, double a)
        {
            this.VRP.x += r * Math.Cos(this.alpha + a); // Move camera along x (right left)
            this.VRP.z -= r * Math.Sin(this.alpha + a); // Move camera along z (forw backw)
            this.Process();
        }

        public void Rotate(double a)
        {
            Form1.TVector V = new TVector();
            this.SetVector(ref V, this.COP.x, this.COP.y, this.COP.z);
            double num1 = this.VectorLength(V);
            double num2 = this.VRP.x - num1 * Math.Cos(this.alpha);
            double num3 = this.VRP.z + num1 * Math.Sin(this.alpha);
            this.alpha += a;
            while (this.alpha > 2.0 * Math.PI)
                this.alpha -= 2.0 * Math.PI;
            while (this.alpha < 0.0)
                this.alpha += 2.0 * Math.PI;
            this.VRP.x = num2 + num1 * Math.Cos(this.alpha);
            this.VRP.z = num3 - num1 * Math.Sin(this.alpha);
            this.VPN.x = -Math.Cos(this.alpha);
            this.VPN.z = Math.Sin(this.alpha);
            this.Process();
        }

        public bool IsValid(string s) => IsNumeric(s) && Convert.ToDouble(s) >= 0.0;


        private void forward_MouseDown(object sender, MouseEventArgs e)
        {
            this.Forw = true;
            this.Timer1.Enabled = true;
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Start();
            
        }

        private void forward_MouseUp(object sender, MouseEventArgs e)
        {
            this.Forw = false;
            this.Timer1.Enabled = false;
            Timer1.Stop();
            Timer1.Interval = 100;
        }

      
        private void backward_MouseUp(object sender, MouseEventArgs e)
        {
            this.Back = false;
            this.Timer1.Enabled = false;
            Timer1.Stop();
            Timer1.Interval = 100;
        }

        private void backward_MouseDown(object sender, MouseEventArgs e)
        {
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Start();
            this.Back = true;
            this.Timer1.Enabled = true;

        }

        private void right_MouseDown(object sender, MouseEventArgs e)
        {
            this.Righ = true;
            this.Timer1.Enabled = true;
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Start();
        }

        private void right_MouseUp(object sender, MouseEventArgs e)
        {
            this.Righ = false;
            this.Timer1.Enabled = false;
            Timer1.Stop();

        }

        private void left_MouseDown(object sender, MouseEventArgs e)
        {
            this.Lef = true;
            this.Timer1.Enabled = true;
        }

        private void left_MouseUp(object sender, MouseEventArgs e)
        {
            this.Lef = false;
            this.Timer1.Enabled = false;
        }


        private void RotateMin_MouseUp(object sender, MouseEventArgs e)
        {
            this.Timer1.Enabled = false;
            this.Rmin = false;
            Timer1.Stop();
        }

        private void rotateMin_MouseDown(object sender, MouseEventArgs e)
        {
            this.Rmin = true;
            this.Timer1.Enabled = true;
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Start();
        }

        private void rotateYplus_MouseDown(object sender, MouseEventArgs e)
        {
            this.Rplus = true;
            this.Timer1.Enabled = true;
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Start();
        }

        private void rotateYplus_MouseUp(object sender, MouseEventArgs e)
        {
            
            this.Rplus = false;
            this.Timer1.Enabled = false;
            Timer1.Stop();

        }





        public bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            if (this.Forw)
                this.MoveCamera(0.1, 0.0);
            if (this.Back)
                this.MoveCamera(-0.1, 0.0);
            if (this.Righ)
                this.MoveCamera(0.1, -1.0 * Math.PI / 2.0);
            if (this.Lef)
                this.MoveCamera(0.1, Math.PI / 2.0);
            if (this.Rplus)
                this.Rotate(Math.PI / 180.0);
            if (!this.Rmin)
                return;
            this.Rotate(-1.0 * Math.PI / 180.0);
        }

        public struct TVector
        {
            public double x;
            public double y;
            public double z;
        }

        public struct TPoint
        {
            public double x;
            public double y;
            public double z;
            public double w;
        }

        public struct TLine
        {
            public int p1;
            public int p2;
        }

        public struct TCube
        {
            public Form1.TPoint[] P;
            public Form1.TLine[] L;
        }

        public struct CSBits
        {
            public bool Above;
            public bool Below;
            public bool Right;
            public bool Left;
            public bool Front;
            public bool Back;
        }

    }
}
