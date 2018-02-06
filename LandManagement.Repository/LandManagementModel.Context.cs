//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;
using LandManagement.Entities;

namespace LandManagement.Repository
{
    public partial class landmanagementbdEntities : ObjectContext
    {
        public const string ConnectionString = "name=landmanagementbdEntities";
        public const string ContainerName = "landmanagementbdEntities";
    
        #region Constructors
    
        public landmanagementbdEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public landmanagementbdEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public landmanagementbdEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<tbalquilada> tbalquilada
        {
            get { return _tbalquilada  ?? (_tbalquilada = CreateObjectSet<tbalquilada>("tbalquilada")); }
        }
        private ObjectSet<tbalquilada> _tbalquilada;
    
        public ObjectSet<tbcarta> tbcarta
        {
            get { return _tbcarta  ?? (_tbcarta = CreateObjectSet<tbcarta>("tbcarta")); }
        }
        private ObjectSet<tbcarta> _tbcarta;
    
        public ObjectSet<tbcliente> tbcliente
        {
            get { return _tbcliente  ?? (_tbcliente = CreateObjectSet<tbcliente>("tbcliente")); }
        }
        private ObjectSet<tbcliente> _tbcliente;
    
        public ObjectSet<tbclienteoperacion> tbclienteoperacion
        {
            get { return _tbclienteoperacion  ?? (_tbclienteoperacion = CreateObjectSet<tbclienteoperacion>("tbclienteoperacion")); }
        }
        private ObjectSet<tbclienteoperacion> _tbclienteoperacion;
    
        public ObjectSet<tbdomicilio> tbdomicilio
        {
            get { return _tbdomicilio  ?? (_tbdomicilio = CreateObjectSet<tbdomicilio>("tbdomicilio")); }
        }
        private ObjectSet<tbdomicilio> _tbdomicilio;
    
        public ObjectSet<tbenalquiler> tbenalquiler
        {
            get { return _tbenalquiler  ?? (_tbenalquiler = CreateObjectSet<tbenalquiler>("tbenalquiler")); }
        }
        private ObjectSet<tbenalquiler> _tbenalquiler;
    
        public ObjectSet<tbencuesta> tbencuesta
        {
            get { return _tbencuesta  ?? (_tbencuesta = CreateObjectSet<tbencuesta>("tbencuesta")); }
        }
        private ObjectSet<tbencuesta> _tbencuesta;
    
        public ObjectSet<tbenventa> tbenventa
        {
            get { return _tbenventa  ?? (_tbenventa = CreateObjectSet<tbenventa>("tbenventa")); }
        }
        private ObjectSet<tbenventa> _tbenventa;
    
        public ObjectSet<tbmenu> tbmenu
        {
            get { return _tbmenu  ?? (_tbmenu = CreateObjectSet<tbmenu>("tbmenu")); }
        }
        private ObjectSet<tbmenu> _tbmenu;
    
        public ObjectSet<tboperaciones> tboperaciones
        {
            get { return _tboperaciones  ?? (_tboperaciones = CreateObjectSet<tboperaciones>("tboperaciones")); }
        }
        private ObjectSet<tboperaciones> _tboperaciones;
    
        public ObjectSet<tbpropiedad> tbpropiedad
        {
            get { return _tbpropiedad  ?? (_tbpropiedad = CreateObjectSet<tbpropiedad>("tbpropiedad")); }
        }
        private ObjectSet<tbpropiedad> _tbpropiedad;
    
        public ObjectSet<tbprovincia> tbprovincia
        {
            get { return _tbprovincia  ?? (_tbprovincia = CreateObjectSet<tbprovincia>("tbprovincia")); }
        }
        private ObjectSet<tbprovincia> _tbprovincia;
    
        public ObjectSet<tbreservaalquiler> tbreservaalquiler
        {
            get { return _tbreservaalquiler  ?? (_tbreservaalquiler = CreateObjectSet<tbreservaalquiler>("tbreservaalquiler")); }
        }
        private ObjectSet<tbreservaalquiler> _tbreservaalquiler;
    
        public ObjectSet<tbreservaventa> tbreservaventa
        {
            get { return _tbreservaventa  ?? (_tbreservaventa = CreateObjectSet<tbreservaventa>("tbreservaventa")); }
        }
        private ObjectSet<tbreservaventa> _tbreservaventa;
    
        public ObjectSet<tbservicios> tbservicios
        {
            get { return _tbservicios  ?? (_tbservicios = CreateObjectSet<tbservicios>("tbservicios")); }
        }
        private ObjectSet<tbservicios> _tbservicios;
    
        public ObjectSet<tbsyscliente> tbsyscliente
        {
            get { return _tbsyscliente  ?? (_tbsyscliente = CreateObjectSet<tbsyscliente>("tbsyscliente")); }
        }
        private ObjectSet<tbsyscliente> _tbsyscliente;
    
        public ObjectSet<tbsyslicencia> tbsyslicencia
        {
            get { return _tbsyslicencia  ?? (_tbsyslicencia = CreateObjectSet<tbsyslicencia>("tbsyslicencia")); }
        }
        private ObjectSet<tbsyslicencia> _tbsyslicencia;
    
        public ObjectSet<tbsystipocliente> tbsystipocliente
        {
            get { return _tbsystipocliente  ?? (_tbsystipocliente = CreateObjectSet<tbsystipocliente>("tbsystipocliente")); }
        }
        private ObjectSet<tbsystipocliente> _tbsystipocliente;
    
        public ObjectSet<tbsysversion> tbsysversion
        {
            get { return _tbsysversion  ?? (_tbsysversion = CreateObjectSet<tbsysversion>("tbsysversion")); }
        }
        private ObjectSet<tbsysversion> _tbsysversion;
    
        public ObjectSet<tbtasacion> tbtasacion
        {
            get { return _tbtasacion  ?? (_tbtasacion = CreateObjectSet<tbtasacion>("tbtasacion")); }
        }
        private ObjectSet<tbtasacion> _tbtasacion;
    
        public ObjectSet<tbtipofamiliar> tbtipofamiliar
        {
            get { return _tbtipofamiliar  ?? (_tbtipofamiliar = CreateObjectSet<tbtipofamiliar>("tbtipofamiliar")); }
        }
        private ObjectSet<tbtipofamiliar> _tbtipofamiliar;
    
        public ObjectSet<tbtipopropiedad> tbtipopropiedad
        {
            get { return _tbtipopropiedad  ?? (_tbtipopropiedad = CreateObjectSet<tbtipopropiedad>("tbtipopropiedad")); }
        }
        private ObjectSet<tbtipopropiedad> _tbtipopropiedad;
    
        public ObjectSet<tbusuario> tbusuario
        {
            get { return _tbusuario  ?? (_tbusuario = CreateObjectSet<tbusuario>("tbusuario")); }
        }
        private ObjectSet<tbusuario> _tbusuario;
    
        public ObjectSet<tbventa> tbventa
        {
            get { return _tbventa  ?? (_tbventa = CreateObjectSet<tbventa>("tbventa")); }
        }
        private ObjectSet<tbventa> _tbventa;
    
        public ObjectSet<tbversion> tbversion
        {
            get { return _tbversion  ?? (_tbversion = CreateObjectSet<tbversion>("tbversion")); }
        }
        private ObjectSet<tbversion> _tbversion;

        #endregion

    }
}
