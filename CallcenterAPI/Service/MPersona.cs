using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CallcenterAPI
{
   
    class MPersona
    {

        public long idpersona { get; set; }
        public Nullable<int> idperfilventa { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefono3 { get; set; }
        public string telefono4 { get; set; }
        public string telefono5 { get; set; }
        public string telefono6 { get; set; }
        public Nullable<byte> telefonodefault { get; set; }
        public string dni { get; set; }
        public string cuil { get; set; }
        public string provincia { get; set; }
        public string partido { get; set; }
        public string localidad { get; set; }
        public string zona { get; set; }
        public string calle { get; set; }
        public string altura { get; set; }
        public string piso { get; set; }
        public string dpto { get; set; }
        public string cp { get; set; }
        public string cbu { get; set; }
        public string tarjeta { get; set; }
        public string codtarjeta { get; set; }
        public string codobrasocial { get; set; }
        public string condicionafip { get; set; }
        public Nullable<System.DateTime> fechanac { get; set; }
        public string email { get; set; }
        public Nullable<bool> used { get; set; }
        public Nullable<bool> aportes { get; set; }
        public Nullable<System.DateTime> cambioos { get; set; }
        public Nullable<System.DateTime> lastcall { get; set; }
        public Nullable<System.DateTime> lastcom { get; set; }
        public Nullable<bool> conformeos { get; set; }
        public Nullable<bool> apto { get; set; }
        public Nullable<bool> hijos { get; set; }
        public string canthijos { get; set; }
        public Nullable<bool> pareja { get; set; }
        public Nullable<int> idbd { get; set; }

        public MPersona(long pIdPersona, int? pIdPerfilVenta, string pNombre, string pSexo,
            string pTel1, string pTel2, string pTel3, string pTel4, string pTel5,string pTel6, byte pTelDefault,
            string pDni, string pCuil, string pProv, string pPart, string pLocal, string pZona,
            string pCalle, string pAltura, string pPiso, string pCp, string pCbu, string pTarjeta,
            string pCodTarjeta, string pCodOS, string pCondAfip,
            DateTime? pFechaNac, string pEmail, bool? pUsed, bool? pAportes, DateTime? pCambioOS,
            DateTime? pLastCall, DateTime? pLastCom, bool? pConformeOS, bool? pApto, bool? pHijos,
            string pCantHijos, bool? pPareja,
            int? pIdbd, string pDpto)
        {
            this.idpersona = pIdPersona;
            this.idperfilventa = pIdPerfilVenta;
            this.nombre = pNombre;
            this.sexo = pSexo;
            this.telefono1 = pTel1;
            this.telefono2 = pTel2;
            this.telefono3 = pTel3;
            this.telefono4 = pTel4;
            this.telefono5 = pTel5;
            this.telefono6 = pTel6;
            this.telefonodefault = pTelDefault;
            this.dni = pDni;
            this.cuil = pCuil;
            this.provincia = pProv;
            this.partido = pPart;
            this.localidad = pLocal;
            this.zona = pZona;
            this.calle = pCalle;
            this.altura = pAltura;
            this.piso = pPiso;
            this.cp = pCp;
            this.cbu = pCbu;
            this.tarjeta = pTarjeta;
            this.codtarjeta = pCodTarjeta;
            this.codobrasocial = pCodOS;
            this.condicionafip = pCondAfip;
            this.fechanac = pFechaNac;
            this.email = pEmail;
            this.used = pUsed;
            this.aportes = pAportes;
            this.cambioos = pCambioOS;
            this.lastcall = pLastCall;
            this.lastcom = pLastCom;
            this.conformeos = pConformeOS;
            this.apto = pApto;
            this.hijos = pHijos;
            this.canthijos = pCantHijos;
            this.pareja = pPareja;
            this.idbd = pIdbd;
            this.dpto = pDpto;



        }
    }
}
