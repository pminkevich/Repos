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

namespace AntiProcrastinate
{
    public partial class UserForm : Form
    {
        private User.User ControlUser;
        Windows.FormState formState;
        public UserForm()
        {
            InitializeComponent();
            ControlUser = new User.User();
             formState= new Windows.FormState();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            
            formState.Maximize(this);
            //ConnectData(); //Metodo para llenar un datagrid
            Reproducir();

        }
        //Reproductor con WebBrowser
        private void Reproducir()
        {
            var Video= ControlUser.FirstVideo();

            /*esto es para una futura version que calcule en tiempo del video y pueda estar
             * reproduciendose hasta que finalice*/
            //var json = new WebClient().DownloadString("https://www.googleapis.com/youtube/v3/videos?part=contentDetails&id=" + Video.Id_Video.ToString() + "&key=AIzaSyCdzXmTfns0XL5FMPGo9MugccXnd6EDnv0");
            ////Vuelco el Json a YoutubeUser
            //YoutubeUser VideoYouTube = JsonConvert.DeserializeObject<YoutubeUser>(json);
       
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
    }
}
