using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MontreTest
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        int WIDH = 300, HEIGHT = 300, secHANd = 140, minHand = 110, hrHand = 80;
        int cx, cy;//centre
        Bitmap btm;
        Graphics g;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            btm = new Bitmap( WIDH + 1, HEIGHT + 1);
            
            cx = WIDH / 2;
            cy = HEIGHT / 2;
            this.BackColor = Color.Azure;
            t.Interval = 1000;//in milliseconde
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

        }
        private void t_Tick(Object c,EventArgs e )
        { 
            // create grafics
            g= Graphics.FromImage(btm);
            //get time
            int ss=DateTime.Now.Second;
            int min=DateTime.Now.Minute;
            int h=DateTime.Now.Hour;
            int [] handcoord=new int[2];
            //clear
            g.Clear(Color.White);
            //draw cercle
            g.DrawEllipse(new Pen(Color.Black,4),0,0,WIDH,HEIGHT);
            //draw figurr
            g.DrawString("12",new Font("Arial",14),Brushes.Black,new Point(130,17));
            g.DrawString("1", new Font("Arial", 14), Brushes.Black, new Point(200, 33));
            g.DrawString("|",new Font("Arial",14),Brushes.Black,new Point(140,-5));
            g.DrawString("2", new Font("Arial", 14), Brushes.Black, new Point(250, 76));
            g.DrawString("3",new Font("Arial",14),Brushes.Black,new Point(270,140));
            g.DrawString("__", new Font("Arial", 14), Brushes.Black, new Point(286, 136));
            g.DrawString("4", new Font("Arial", 14), Brushes.Black, new Point(244, 220));
            g.DrawString("5", new Font("Arial", 14), Brushes.Black, new Point(200, 255));
            g.DrawString("6", new Font("Arial", 14), Brushes.Black, new Point(140, 260));
            g.DrawString("7",new Font("Arial",14),Brushes.Black,new Point(60,245));
            g.DrawString("8", new Font("Arial", 14), Brushes.Black, new Point(22, 205));
            g.DrawString("|", new Font("Arial", 14), Brushes.Black, new Point(142, 282));
            g.DrawString("9",new Font("Arial",14),Brushes.Black,new Point(20,140));
            g.DrawString("11", new Font("Arial", 14), Brushes.Black, new Point(69, 30));
            g.DrawString("10", new Font("Arial", 14), Brushes.Black, new Point(27, 90));
            g.DrawString("_", new Font("Arial", 14), Brushes.Black, new Point(0, 136));
            int d=DateTime.Now.Day;
            g.DrawString(d+"", new Font("Arial", 10), Brushes.Black, new Point(240, 144));
            g.DrawRectangle(new Pen(Color.Black, 1f), new Rectangle(240, 144, 20, 14));
            // second Hand
            handcoord=msCord(ss,secHANd);
            //draw seconde hand
            g.DrawLine(new Pen(Color.Red,1f),new Point(cx,cy),new Point(handcoord[0],handcoord[1]));
            // minut hand
              handcoord=msCord(min,minHand);
            //draw  hand
            g.DrawLine(new Pen(Color.Black,2f),new Point(cx,cy),new Point(handcoord[0],handcoord[1]));
            //draw hour hand
             handcoord=hCord(h%12,min,hrHand);
            //draw  hand
            g.DrawLine(new Pen(Color.Gray,3f),new Point(cx,cy),new Point(handcoord[0],handcoord[1]));
            //load bmp in pikture
            pictureBox1.Image=btm;
                this.Text="Clock"+h+":"+min+":"+ss;
            g.Dispose();




        }

            //coordonne du minute et seconde Hand
            private int[] msCord(int val,int hlen)
            {

                int[] coord=new int[2];
                val*=6;//each  minute and seconde make 6 °
                if(val>=0 && val<=100)
                {
                    coord[0]=cx+(int)(hlen*Math.Sin(Math.PI*val/180));
                    coord[1]=cy-(int)(hlen*Math.Cos(Math.PI*val/180));
                    
                }
                else
                {
                     coord[0]=cx-(int)(hlen* - Math.Sin(Math.PI*val/180));
                    coord[1]=cy-(int)(hlen*Math.Cos(Math.PI*val/180));

                }

                return coord;
            }
        //coord for hour and
         private int[] hCord(int hval,int mval,int hlen)
            {
                int[] coord=new int[2];
             //each hour make 30 degree
             //each minut make 0,5 °


                int val=(int)((hval*30)+(mval*0.5));

                if(val>=0 && val<=100)
                {
                    coord[0]=cx+(int)(hlen*Math.Sin(Math.PI*val/180));
                    coord[1]=cy-(int)(hlen*Math.Cos(Math.PI*val/180));
                    
                }
                else
                {
                     coord[0]=cx-(int)(hlen* - Math.Sin(Math.PI*val/180));
                    coord[1]=cy-(int)(hlen*Math.Cos(Math.PI*val/180));

                }

                return coord;
            }

         private void pictureBox1_Click(object sender, EventArgs e)
         {

         }

        }




        }
    

