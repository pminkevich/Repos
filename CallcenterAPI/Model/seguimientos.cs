//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CallcenterAPI
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    
    public partial class seguimientos
    {
        public int idseg { get; set; }
        public long idpersona { get; set; }
        public int idproducto { get; set; }
        public int idusuario { get; set; }
        public System.DateTime fechaseg { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora { get; set; }
        public string comentario { get; set; }
        public int idstate { get; set; }
    
        public virtual personas personas { get; set; }
        public virtual productos productos { get; set; }
        public virtual segstate segstate { get; set; }
        public virtual usuarios usuarios { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<seguimientos> Mapeo)
            {
                Mapeo.HasKey(x => x.idseg);
                Mapeo.HasOne(x => x.personas).
                    WithMany(x=>x.seguimientos)
                    .HasForeignKey(x=>x.idpersona);

                Mapeo.HasOne(x => x.productos).
                    WithMany(x => x.seguimientos)
                    .HasForeignKey(x => x.idproducto);

                Mapeo.HasOne(x => x.segstate).
                    WithMany(x => x.seguimientos)
                    .HasForeignKey(x => x.idstate);

                Mapeo.HasOne(x => x.usuarios).
                    WithMany(x => x.seguimientos)
                    .HasForeignKey(x => x.idusuario);

            }
        }
    }
}
