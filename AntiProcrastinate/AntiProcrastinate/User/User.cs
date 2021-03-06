﻿using AntiProcrastinate.Antip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AntiProcrastinate.User
{
    class User
    {
		List<Model.Videos> Lista;
		Model.Videos FVideo;

		public User()
		{
			Lista = new List<Model.Videos>();
			FVideo = new Model.Videos();
		}

		public List<Model.Videos> ListaVideos()
        {			

			try
			{
				using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
				{
					Lista = db.Videos.Where(x => x.ESTADO == "Listo").ToList();
					
				}
				return Lista;
			}
			catch (Exception ex)
			{

				string error = ex.Message;
				throw;
			}
        }

		public Model.Videos FirstVideo()
		{
			try
			{
				using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
				{
					FVideo = db.Videos.First(x => x.ESTADO == "Listo");

				}
				return FVideo;
			}
			catch (Exception ex)
			{

				string error = ex.Message;
				throw;
			}
		}

		public YoutubeUser GetInfoVideo(Model.Videos Video)
		{
			string ApiYouTube = "&key=ApiYouTube";
			/*esto es para una futura version que calcule en tiempo del video y pueda estar
             * reproduciendose hasta que finalice*/
			var json = new WebClient().DownloadString("https://www.googleapis.com/youtube/v3/videos?part=contentDetails&id=" + Video.Id_Video.ToString() + ApiYouTube);
			////Vuelco el Json a YoutubeUser
			YoutubeUser VideoYouTube = JsonConvert.DeserializeObject<YoutubeUser>(json);
			return VideoYouTube;
		}

		public bool VideoVisto(Model.Videos Video)
		{
			bool estado = false;

			try
			{
				using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
				{
					Video.ESTADO = "Visto";
					
					db.Entry(Video).State = System.Data.Entity.EntityState.Modified;
					
					db.SaveChanges();
				}

				estado=true;

			}
			catch (Exception Ex)
			{
				string Error = Ex.Message;
				estado = false;

			}
			
				return estado;
			
		}

	}
}
