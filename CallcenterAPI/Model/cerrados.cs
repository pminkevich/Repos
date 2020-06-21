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
    
    public partial class cerrados
    {
        public int idcierre { get; set; }
        public long idpersona { get; set; }
        public int idproducto { get; set; }
        public int idusuario { get; set; }
        public int idargumento { get; set; }
        public System.DateTime fechacierre { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora { get; set; }
        public string comentario { get; set; }
        public int idstate { get; set; }
    
        public virtual argumentos argumentos { get; set; }
        public virtual personas personas { get; set; }
        public virtual productos productos { get; set; }
        public virtual closestate closestate { get; set; }
        public virtual usuarios usuarios { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<cerrados> Mapeo)
            {
                Mapeo.HasKey(x => x.idcierre);

                Mapeo.HasOne(x => x.argumentos)
                    .WithMany(x=>x.cerrados)
                    .HasForeignKey(x=>x.idargumento);

                Mapeo.HasOne(x => x.productos)
                    .WithMany(x => x.cerrados)
                    .HasForeignKey(x => x.idproducto); 
                
                Mapeo.HasOne(x => x.personas)
                    .WithMany(x => x.cerrados)
                    .HasForeignKey(x => x.idpersona);

                Mapeo.HasOne(x => x.closestate)
                    .WithMany(x => x.cerrados)
                    .HasForeignKey(x => x.idstate);

                Mapeo.HasOne(x => x.usuarios)
                    .WithMany(x => x.cerrados)
                    .HasForeignKey(x => x.idusuario);

            }
        }
    }
}
