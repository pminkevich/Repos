using System;
using System.Collections.Generic;
using System.Linq;
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
					FVideo = db.Videos.First();

				}
				return FVideo;
			}
			catch (Exception ex)
			{

				string error = ex.Message;
				throw;
			}
		}

	}
}
