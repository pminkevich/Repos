using AntiProcrastinate.Antip;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntiProcrastinate.Model;

namespace AntiProcrastinate
{
    public partial class UserForm : Form
    {
        private User.User ControlUser;
        Windows.FormState formState;
        private Videos Video;
        private YoutubeUser VideoYouTube;
        private string Tiempo;
        private int TotalSeg;

        public UserForm()
        {
            InitializeComponent();
            ControlUser = new User.User();
             formState= new Windows.FormState();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            /*usar para maximizar y ocupar todo el ancho de la pantalla*/
            //formState.Maximize(this);

            //ConnectData(); //Metodo para llenar un datagrid
            Video = ControlUser.FirstVideo();
            VideoYouTube = ControlUser.GetInfoVideo(Video);
            Tiempo = VideoYouTube.items[0].contentDetails.duration.ToString();

            /*para poder depurar sino la pantalla
            siempre aparece al frente */
            this.TopMost = false;

            TotalSeg = TotalSec(Tiempo);

            lblDesafio.Text = "Nuevo Desafio";
            lblComienza.Text = "Comienza en";
            lblTitulo.Text = Video.Nombre.ToString();
            int Min = TotalSeg / 60;
            int Seg = TotalSeg % 60;
            lblTiempo.Text = Min.ToString()+ ":" + Seg.ToString();
            panel1.Visible = true;

            // MessageBox.Show(TotalSeg.ToString());
            TimerPanel.Enabled = true;
            TimerPanel.Start();


            
            Reproducir(Video);

        }
        //Reproductor con WebBrowser
        private void Reproducir(Videos Video)
        {
            
            Reproductor.ScriptErrorsSuppressed = true;
            
            //Reproductor.Url = new System.Uri(Video.Url.ToString()+ "?autoplay=1#movie_player", System.UriKind.RelativeOrAbsolute);
             Reproductor.Url = new System.Uri("https://www.youtube.com/watch?v="+Video.Id_Video.ToString() , System.UriKind.RelativeOrAbsolute);
           
            /* No funciona el embeb tira error script
            Reproductor.Url = new System.Uri("https://www.youtube.com/embed/MwSLIXelGg0", System.UriKind.RelativeOrAbsolute);*/
        }

        

        // Metodo para llenar un Datagrid con los videos para ver
        //private void ConnectData()
        //{
        //    dtgVideos.DataSource = ControlUser.ListaVideos();
        //}

        private int TotalSec(string Tiempo)
        {
            char[] lstTime = Tiempo.ToCharArray();

            //int Min = lstTime[2];
            char[] minStr = new char[3];
            char[] secStr = new char[3];

            int sec = 0;


            for (int i = 2; i < lstTime.Length; i++)
            {
                if (lstTime[i] != 'M')
                {
                    minStr[i - 2] = lstTime[i];
                }
                else
                {

                    sec = i + 1;
                    break;
                }
            }
            for (int i = sec; i < lstTime.Length; i++)
            {
                if (lstTime[i] != 'S')
                {
                    secStr[i - sec] = lstTime[i];
                }
                else
                {


                    break;
                }
            }
            string Minutos = new string(minStr);
            string Segundos = new string(secStr);
            int Min = Convert.ToInt32(Minutos);
            int Seg = Convert.ToInt32(Segundos);
            int TotalSeg = (Min * 60) + Seg;
            return TotalSeg;
        }

        private void TimerPanel_Tick(object sender, EventArgs e)
        {
            int Num = Convert.ToInt32(lblSeg.Text);
            lblSeg.Text = Convert.ToString(Num - 1);

            if (lblSeg.Text == "0")
            {
                TimerPanel.Stop();
                panel1.Visible = false;
                TimerPanel.Enabled = false;
                TimerVideo.Enabled = true;
                TimerVideo.Start();
            }


        }

        private void TimerVideo_Tick(object sender, EventArgs e)
        {
            TotalSeg--;
            if (TotalSeg == 4)
            {

                if (ControlUser.VideoVisto(Video))
                {
                    lblSeg.Text = "3";
                    lblDesafio.Text = "Desafio Completado";
                    lblComienza.Text = "Finaliza en";
                    panel1.Visible = true;
                    TimerPanel.Enabled = true;
                    TimerPanel.Start();
                } 
            }

            if (TotalSeg == 0)
            {
                
                TimerVideo.Stop();
                TimerVideo.Enabled = false;
                this.Close();
            }

        }
    }


}
