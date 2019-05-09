using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common;
namespace Datos
{
    public class Usuario:ConexionSQL 
    {
        public bool Login(string User, string Pass)
        {
            using (var conexion = GetConexion())
            {
                conexion.Open();
                using(var comando= new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "select * from [dbo].[Usuarios] where UserName=@UserName and Password=@Password";
                    comando.Parameters.AddWithValue("@UserName", User);
                    comando.Parameters.AddWithValue("@Password", Pass);
                    comando.CommandType = CommandType.Text;
                    SqlDataReader dr = comando.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UserLoginCache.IdUser = dr.GetInt32(0);
                            UserLoginCache.Nombre = dr.GetString(3);
                            UserLoginCache.Apellido = dr.GetString(4);
                            UserLoginCache.Posicion = dr.GetString(5);
                            UserLoginCache.Email = dr.GetString(6);
                        }
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                }
            }

        }
    }
}
