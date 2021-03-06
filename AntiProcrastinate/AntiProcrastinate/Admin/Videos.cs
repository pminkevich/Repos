﻿using AntiProcrastinate.Antip;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AntiProcrastinate.Admin
{
    class Videos
    {
        

        private YouTubeAPI Get(string channel)
        {
            //url del Json
            var json = new WebClient().DownloadString("https://www.googleapis.com/youtube/v3/search?order=date&part=snippet&channelId=" + channel + "&maxResults=50&key=API DE YOUTUBE");
            //Vuelco el Json a YoutubeAPI
            YouTubeAPI obj = JsonConvert.DeserializeObject<YouTubeAPI>(json);
            return obj;
        }
        private YouTubePlayList GetList(string playList, string pageToken="")
        {
            //url del Json
            string Api = "&key=Api YouTube";
            var json = new WebClient().DownloadString("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&playlistId=" + playList + "&maxResults=50&pageToken="+ pageToken + Api);
            //Vuelco el Json a YoutubeAPI
            YouTubePlayList obj = JsonConvert.DeserializeObject<YouTubePlayList>(json);
            return obj;

        }
        public async Task<int> AgregarChannel(string channel)
        {
            int total = 0;
            await Task.Run(() => {

                var obj = Get(channel);
                total = ((ICollection)obj.items).Count;
                //obj.pageInfo.totalResults;
                GuardarChannel(obj, total);


            });
            return total;


        }
        public async Task<int> AgregarPlayList(string playList)
        {
            int total = 0;
            await Task.Run(() =>
            {
                var obj = GetList(playList);
                total = ((ICollection)obj.items).Count;
                GuardarPlayList(obj, total);
                if (obj.nextPageToken != null)
                {
                    //string Token = obj.nextPageToken;
                    while (obj.nextPageToken != null)
                    {
                        obj = GetList(playList, obj.nextPageToken);
                        total += ((ICollection)obj.items).Count;
                        GuardarPlayList(obj, total);
                    }
                }
               
            });
            return total;
        }

        private void GuardarChannel(YouTubeAPI obj, int total)
        {
            List<Model.Videos> Videos = new List<Model.Videos>();
            try
            {
                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {
                    for (int i = 0; i < total; i++)
                    {

                        Model.Videos Video = new Model.Videos();

                        Video.Id_Video = obj.items[i].id.videoId;
                        Video.Nombre = obj.items[i].snippet.title;
                        Video.Url = "https://www.youtube.com/embed/" + obj.items[i].id.videoId;
                        Video.ESTADO = "Listo";
                        Videos.Add(Video);



                    }
                    if (total > 0)
                    {
                        db.Videos.AddRange(Videos);
                        // db.Entry(Videos).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                    }
                    //return total;

                }
            }
            //cath para saber sobre error en Entity Framework
            //catch (DbEntityValidationException ex)
            //{
            //    StringBuilder sb = new StringBuilder();

            //    foreach (var failure in ex.EntityValidationErrors)
            //    {
            //        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
            //        foreach (var error in failure.ValidationErrors)
            //        {
            //            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
            //            sb.AppendLine();
            //        }
            //    }
            //    //return total;
            //    throw new DbEntityValidationException(
            //        "Entity Validation Failed - errors follow:\n" +
            //        sb.ToString(), ex

            //    ); // Add the original exception as the innerException



            //}
            catch (Exception ex)
            {
                string Error = ex.Message;
                // return total;
            }
        }

        private void GuardarPlayList(YouTubePlayList obj, int total)
        {
            List<Model.Videos> Videos = new List<Model.Videos>();
            try
            {
                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {
                    for (int i = 0; i < total; i++)
                    {

                        Model.Videos Video = new Model.Videos();

                        Video.Id_Video = obj.items[i].snippet.resourceId.videoId;
                        Video.Nombre = obj.items[i].snippet.title;
                        Video.Url = "https://www.youtube.com/embed/" + obj.items[i].snippet.resourceId.videoId;
                        Video.ESTADO = "Listo";
                        Videos.Add(Video);



                    }
                    if (total > 0)
                    {
                        db.Videos.AddRange(Videos);
                        // db.Entry(Videos).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                    }
                    //return total;

                }
            }
            //cath para saber sobre error en Entity Framework
            //catch (DbEntityValidationException ex)
            //{
            //    StringBuilder sb = new StringBuilder();

            //    foreach (var failure in ex.EntityValidationErrors)
            //    {
            //        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
            //        foreach (var error in failure.ValidationErrors)
            //        {
            //            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
            //            sb.AppendLine();
            //        }
            //    }
            //    //return total;
            //    throw new DbEntityValidationException(
            //        "Entity Validation Failed - errors follow:\n" +
            //        sb.ToString(), ex

            //    ); // Add the original exception as the innerException



            //}
            catch (Exception ex)
            {
                string Error = ex.Message;
                // return total;
            }
        }


        public int Vistos()
        {
            int Vistos;
            try
            {

                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {

                    Vistos = db.Videos.Where(x => x.ESTADO == "Visto").Count();

                }
            }
            catch (Exception)
            {
                Vistos = 0;
                throw;

            }

            return Vistos;

        }
        public int PorVer()
        {
            int PorVer;
            try
            {

                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {

                    PorVer = db.Videos.Where(x => x.ESTADO == "Listo").Count();

                }
            }
            catch (Exception)
            {
                PorVer = 0;
                throw;

            }

            return PorVer;
        }
    }

}