using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class OperacionBusiness
    {
        private OperacionRepository operacionRepository;

        public OperacionBusiness()
        {
            operacionRepository = new OperacionRepository();
        }

        public void Create(tboperaciones operacion)
        {
            operacionRepository.Create(operacion);
        }

        public void Update(tboperaciones operacion)
        {
            operacionRepository.Update(operacion);
        }

        #region Actualizar Operaciones

        public void Update(tboperaciones _operacion, tbtasacion _tasacion)
        {
            TasacionBusiness tasacionBusiness = new TasacionBusiness();
            tasacionBusiness.Update(_tasacion);
        }

        public void Update(tboperaciones _operacion, tbreservaventa _reservaVenta)
        {
            ReservaVentaBusiness reservaVentaBusiness = new ReservaVentaBusiness();
            reservaVentaBusiness.Update(_reservaVenta);
        }

        public void Update(tboperaciones _operacion, tbenventa _enVenta)
        {
            //Actualizo tbenventa
            EnVentaBusiness enVentaBusiness = new EnVentaBusiness();
            enVentaBusiness.Update(_enVenta);

            //Actualizo tbClienteOperacion
            ClienteOperacionBusiness clienteOperacionBusiness = new ClienteOperacionBusiness();
            
            List<tbclienteoperacion> operacionClienteExistentes =
                ((List<tbclienteoperacion>)clienteOperacionBusiness.GetListByIdOperacion(_operacion.ope_id))
                        .Where(x => x.ope_id == _operacion.ope_id).ToList();

            var autorizantesExistentes = operacionClienteExistentes.Where(x => x.stc_id == 1);
            var idsAutorizantesExistentes = autorizantesExistentes.Select(x => x.cli_id);

            var autorizantesActualizados = _operacion.tbclienteoperacion.Where(x => x.stc_id == 1);
            var idsAutorizantesActualizados = autorizantesActualizados.Select(x => x.cli_id);

            var autorizantesNuevos = autorizantesActualizados.Where(x => !idsAutorizantesExistentes.Contains(x.cli_id));
            var autorizantesEliminados = autorizantesExistentes.Where(x => !idsAutorizantesActualizados.Contains(x.cli_id));

            if (autorizantesNuevos.Count() > 0)
                foreach (tbclienteoperacion obj in autorizantesNuevos)
                    clienteOperacionBusiness.Create(obj);

            if (autorizantesEliminados.Count() > 0)
                foreach (tbclienteoperacion obj in autorizantesEliminados)
                    clienteOperacionBusiness.Delete(obj);

        }

        public void Update(tboperaciones _operacion, tbventa _venta, int _codigoOperador)
        {
            //Actualizo tbventa
            VentaBusiness ventaBusiness = new VentaBusiness();
            ventaBusiness.Update(_venta);

            //Actualizo tbClienteOperacion
            UpdateClienteOperacionOperador(_operacion, _codigoOperador);
        }

        public void Update(tboperaciones _operacion, tbenalquiler _enAlquiler)
        {
            EnAlquilerBusiness enAlquilerBusiness = new EnAlquilerBusiness();
            enAlquilerBusiness.Update(_enAlquiler);
        }

        public void Update(tboperaciones _operacion, tbreservaalquiler _reservaAlquiler)
        {
            ReservaAlquilerBusiness reservaAlquilerBusiness = new ReservaAlquilerBusiness();
            reservaAlquilerBusiness.Update(_reservaAlquiler);
        }

        public void Update(tboperaciones _operacion, tbalquilada _alquilada)
        {
            AlquiladaBusiness alquiladaBusiness = new AlquiladaBusiness();
            alquiladaBusiness.Update(_alquilada);
        }

        public void Update(tboperaciones _operacion, tbencuesta _encuesta)
        {
            EncuestaBusiness encuestaBusiness = new EncuestaBusiness();
            encuestaBusiness.Update(_encuesta);
        }

        private static void UpdateClienteOperacionOperador(tboperaciones _operacion, int _codigoOperador)
        {
            ClienteOperacionBusiness clienteOperacionBusiness = new ClienteOperacionBusiness();

            List<tbclienteoperacion> operacionClienteExistentes =
                (List<tbclienteoperacion>)clienteOperacionBusiness.GetListByIdOperacion(_operacion.ope_id);

            var operadoresExistentes = operacionClienteExistentes.Where(x => x.stc_id == _codigoOperador);
            var idsOperadoresExistentes = operadoresExistentes.Select(x => x.cli_id);

            var operadoresActualizados = _operacion.tbclienteoperacion.Where(x => x.stc_id == _codigoOperador);
            var idsOperadoresActualizados = operadoresActualizados.Select(x => x.cli_id);

            var operadoresNuevos = operadoresActualizados.Where(x => !idsOperadoresExistentes.Contains(x.cli_id));
            var operadoresEliminados = operadoresExistentes.Where(x => !idsOperadoresActualizados.Contains(x.cli_id));

            if (operadoresNuevos.Count() > 0)
                foreach (tbclienteoperacion obj in operadoresNuevos)
                    clienteOperacionBusiness.Create(obj);

            if (operadoresEliminados.Count() > 0)
                foreach (tbclienteoperacion obj in operadoresEliminados)
                    clienteOperacionBusiness.Delete(obj);
        }
        #endregion

        public void Delete(tboperaciones operacion)
        {
            DetectarOperacionAEliminar(operacion);
        }

        #region Elminar operacion y sus relaciones
        private void DetectarOperacionAEliminar(tboperaciones _operacion)
        {
            if (_operacion.tas_id != null)
                this.Delete(_operacion, _operacion.tbtasacion);
            if (_operacion.env_id != null)
                this.Delete(_operacion, _operacion.tbenventa);
            if (_operacion.rev_id != null)
                this.Delete(_operacion, _operacion.tbreservaventa);
            if (_operacion.ven_id != null)
                this.Delete(_operacion, _operacion.tbventa);
            if (_operacion.ena_id != null)
                this.Delete(_operacion, _operacion.tbenalquiler);
            if (_operacion.rea_id != null)
                this.Delete(_operacion, _operacion.tbreservaalquiler);
            if (_operacion.alq_id != null)
                this.Delete(_operacion, _operacion.tbalquilada);
            if (_operacion.enc_id != null)
                this.Delete(_operacion, _operacion.tbencuesta);
        }

        public void Delete(tboperaciones _operacion, tbtasacion _tasacion)
        {
            try
            {
                //Traigo registro de la tabla tbtasacion
                TasacionBusiness tasacionBusiness = new TasacionBusiness();
                tbtasacion tasacion = (tbtasacion)tasacionBusiness.GetElementByKey(
                new tbtasacion() { tas_id = _tasacion.tas_id });

                EliminoClienteOperacionDeLaOperacion(_operacion);
                DeleteSoloOperacion(_operacion);
                tasacionBusiness.Delete(tasacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Delete(tboperaciones _operacion, tbenventa _enventa)
        {
            //Traigo registro de la tabla EnVenta
            EnVentaBusiness enVentaBusiness = new EnVentaBusiness();
            tbenventa enVenta = (tbenventa)enVentaBusiness.GetElementByKey(
                new tbenventa() { env_id = _enventa.env_id });

            EliminoClienteOperacionDeLaOperacion(_operacion);
            DeleteSoloOperacion(_operacion);

            //Elimino tbenventa
            enVentaBusiness.Delete(enVenta);
        }

        private void Delete(tboperaciones _operacion, tbreservaventa _reservaVenta)
        {
            //Traigo registro de la tabla Reserva Venta
            ReservaVentaBusiness reservaVentaBusiness = new ReservaVentaBusiness();
            tbreservaventa reservaVenta = (tbreservaventa)reservaVentaBusiness.GetElementByKey(
                new tbreservaventa() { rev_id = _reservaVenta.rev_id });

            EliminoClienteOperacionDeLaOperacion(_operacion);
            DeleteSoloOperacion(_operacion);

            //Elimino tbreservaventa
            reservaVentaBusiness.Delete(reservaVenta);
        }

        private void Delete(tboperaciones _operacion, tbventa _venta)
        {
            //Traigo registro de la tabla Reserva Venta
            VentaBusiness ventaBusiness = new VentaBusiness();
            tbventa venta = (tbventa)ventaBusiness.GetElementByKey(
                new tbventa() { ven_id = _venta.ven_id });

            EliminoClienteOperacionDeLaOperacion(_operacion);
            DeleteSoloOperacion(_operacion);

            //Elimino tbventa
            ventaBusiness.Delete(venta);
        }

        private void Delete(tboperaciones _operacion, tbenalquiler _enAlquiler)
        {
            //Traigo registro de la tabla Reserva Venta
            EnAlquilerBusiness enAlquilerBusiness = new EnAlquilerBusiness();
            tbenalquiler enAlquiler = (tbenalquiler)enAlquilerBusiness.GetElementByKey(
                new tbenalquiler() { ena_id = _enAlquiler.ena_id });

            EliminoClienteOperacionDeLaOperacion(_operacion);
            DeleteSoloOperacion(_operacion);

            //Elimino tbenalquiler
            enAlquilerBusiness.Delete(enAlquiler);
        }

        private void Delete(tboperaciones _operacion, tbreservaalquiler _reservaAlquiler)
        {
            //Traigo registro de la tabla Reserva Venta
            ReservaAlquilerBusiness reservaAlquilerBusiness = new ReservaAlquilerBusiness();
            tbreservaalquiler reservaAlquiler = (tbreservaalquiler)reservaAlquilerBusiness.GetElementByKey(
                new tbreservaalquiler() { rea_id = _reservaAlquiler.rea_id });

            EliminoClienteOperacionDeLaOperacion(_operacion);
            DeleteSoloOperacion(_operacion);

            //Elimino tbreservaalquiler
            reservaAlquilerBusiness.Delete(reservaAlquiler);
        }

        private void Delete(tboperaciones _operacion, tbalquilada _alquilada)
        {
            //Traigo registro de la tabla Reserva Venta
            AlquiladaBusiness alquiladaBusiness = new AlquiladaBusiness();
            tbalquilada alquilada = (tbalquilada)alquiladaBusiness.GetElementByKey(
                new tbalquilada() { alq_id = _alquilada.alq_id });

            EliminoClienteOperacionDeLaOperacion(_operacion);
            DeleteSoloOperacion(_operacion);

            //Elimino tbalquilada
            alquiladaBusiness.Delete(alquilada);
        }

        private void Delete(tboperaciones _operacion, tbencuesta _encuesta)
        {
            //Traigo registro de la tabla Reserva Venta
            EncuestaBusiness encuestaBusiness = new EncuestaBusiness();
            tbencuesta encuesta = (tbencuesta)encuestaBusiness.GetElementByKey(
                new tbencuesta() { enc_id = _encuesta.enc_id });

            EliminoClienteOperacionDeLaOperacion(_operacion);
            DeleteSoloOperacion(_operacion);

            //Elimino tbencuesta
            encuestaBusiness.Delete(encuesta);
        }

        private static void EliminoClienteOperacionDeLaOperacion(tboperaciones _operacion)
        {
            try
            {
                //Guardo los tbclienteoperacion en una lista, para no modificar el ObjectSateManager
                ClienteOperacionBusiness clienteOperacionBusiness = new ClienteOperacionBusiness();
                List<tbclienteoperacion> listaClienteOperacion = new List<tbclienteoperacion>();

                //Agrego cliente operación a la lista
                foreach (tbclienteoperacion obj in _operacion.tbclienteoperacion)
                    listaClienteOperacion.Add(
                        (tbclienteoperacion)clienteOperacionBusiness.GetElementByKey(obj));

                //Elimino tbclienteoperacion
                foreach (var obj in listaClienteOperacion)
                    clienteOperacionBusiness.Delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteSoloOperacion(tboperaciones _operacion)
        {
            //Elimino tboperacion
            operacionRepository = new OperacionRepository();
            operacionRepository.Delete(new tboperaciones() { ope_id = _operacion.ope_id });
        }
        #endregion

        public object GetElement(tboperaciones operacion)
        {
            return operacionRepository.GetElement(operacion);
        }

        public object GetList()
        {
            return operacionRepository.GetList();
        }

        public object GetListByPropiedadId(int _idPropidad)
        {
            return operacionRepository.GetListByPropiedadId(_idPropidad);
        }

        public object GetList(Func<tboperaciones, bool> funcion)
        {
            return operacionRepository.GetList(funcion);
        }

        #region Obtener operaciones por id de propiedad

        public object GetOperacionesByIdPropiedad(int _idPropiedad)
        {
            Func<tboperaciones, bool> whereClausule = x => x.pro_id == _idPropiedad;
            return operacionRepository.GetList(whereClausule) as List<tboperaciones>;
        }

        #endregion
    }
}
