﻿using Bunifu.UI.WinForms;
using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Funciones.Mantenimiento
{
    public class FConceptosContables
    {
        public static string query;

        public DataSet listaConceptosContables(string Descri)
        {
            DataSet ds = new DataSet();
            string Query = $"SELECT * FROM ConceptoCont left join PCuenta ON coc_ctacont = PCuenta.pcu_cuenta left join (select * from PCuenta) AS Comando ON coc_contrap = Comando.pcu_cuenta WHERE coc_descri LIKE'%{Descri}%'";
            query = Query;
            ds = AccesoBase.ListarDatos(Query);
            return ds;
        }

        public DataSet listaCuentas(string txtbusqueda)
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT pcu_codigo as Código, pcu_cuenta as Cuenta, pcu_descri as Descripción FROM PCuenta { txtbusqueda }");
            return ds;
        }

        public DataSet listaCuentasActivasMovimiento(string txtbusqueda, BunifuCheckBox checkActivas, BunifuCheckBox checkMovimiento)
        {
            DataSet ds = new DataSet();
            if (checkActivas.Checked && checkMovimiento.Checked == false)
            {
                ds = AccesoBase.ListarDatos($"SELECT pcu_codigo as Código, pcu_cuenta as Cuenta, pcu_descri as Descripción FROM PCuenta WHERE pcu_estado = 1 {txtbusqueda}");
            }
            else if (checkMovimiento.Checked && checkActivas.Checked == false)
            {
                ds = AccesoBase.ListarDatos($"SELECT pcu_codigo as Código, pcu_cuenta as Cuenta, pcu_descri as Descripción FROM PCuenta WHERE pcu_hija = 0 {txtbusqueda}");
            }
            else
            {
                ds = AccesoBase.ListarDatos($"SELECT pcu_codigo as Código, pcu_cuenta as Cuenta, pcu_descri as Descripción FROM PCuenta WHERE pcu_estado = 1 AND pcu_hija = 0 {txtbusqueda}");
            }
            return ds;
        }

        public string descripcionCuenta(int idCuenta)
        {
            string Descripcion = "";
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM PCuenta WHERE pcu_cuenta = {idCuenta}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Descripcion = dr["pcu_descri"].ToString();
            }
            return Descripcion;
        }

        public MConceptoContable conceptoContableParticular(int codigo)
        {
            MConceptoContable concepto = new MConceptoContable();
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos($"SELECT * FROM ConceptoCont WHERE coc_codigo = {codigo}");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MConceptoContable mConceptoContable = new MConceptoContable()
                {
                    coc_codigo = codigo,
                    coc_descri = dr["coc_descri"].ToString(),
                    coc_vta = Convert.ToInt32(dr["coc_vta"].ToString()),
                    coc_cpa = Convert.ToInt32(dr["coc_cpa"].ToString()),
                    coc_caja = Convert.ToInt32(dr["coc_caja"].ToString()),
                    coc_banco = Convert.ToInt32(dr["coc_banco"].ToString()),
                    coc_ctacont = Convert.ToInt32(dr["coc_ctacont"].ToString()),
                    pcu_descriCuenta = descripcionCuenta(Convert.ToInt32(dr["coc_ctacont"].ToString())),
                    coc_contrap = Convert.ToInt32(dr["coc_contrap"].ToString()),
                    coc_cccta = Convert.ToInt32(dr["coc_cccta"].ToString()),
                    coc_cccontrap = Convert.ToInt32(dr["coc_cccontrap"].ToString()),
                    pcu_descriContrap = descripcionCuenta(Convert.ToInt32(dr["coc_contrap"].ToString()))
                };
                concepto = mConceptoContable;
            }
            return concepto;
        }

        public DataSet listaCentroC()
        {
            DataSet ds = new DataSet();
            ds = AccesoBase.ListarDatos("SELECT * FROM CentroC");
            return ds;
        }

        public void agregarConceptoCont(MConceptoContable mConceptoContable)
        {
            AccesoBase.InsertUpdateDatos($"INSERT INTO ConceptoCont(coc_codigo, coc_descri, coc_vta, coc_cpa, coc_caja, coc_banco, coc_ctacont, coc_contrap, coc_vigencia, coc_cccta, coc_cccontrap) " +
            $"VALUES({mConceptoContable.coc_codigo},'{mConceptoContable.coc_descri}',{mConceptoContable.coc_vta},{mConceptoContable.coc_cpa},{mConceptoContable.coc_caja},{mConceptoContable.coc_banco},{mConceptoContable.coc_ctacont},{mConceptoContable.coc_contrap},1,{mConceptoContable.coc_cccta},{mConceptoContable.coc_cccontrap})");
        }

        public void modificarConceptoCont(MConceptoContable mConceptoContable)
        {
            AccesoBase.InsertUpdateDatos($"UPDATE ConceptoCont SET coc_descri = '{mConceptoContable.coc_descri}', coc_vta = {mConceptoContable.coc_vta}, coc_cpa = {mConceptoContable.coc_cpa}, coc_caja = {mConceptoContable.coc_caja}, coc_banco = {mConceptoContable.coc_banco}, coc_ctacont = {mConceptoContable.coc_ctacont}, coc_contrap = {mConceptoContable.coc_contrap}, coc_cccta = {mConceptoContable.coc_cccta}, coc_cccontrap = {mConceptoContable.coc_cccontrap} WHERE coc_codigo = {mConceptoContable.coc_codigo}");
        }

        public void eliminarConceptoCont(int cocCodigo)
        {
            AccesoBase.InsertUpdateDatos($"DELETE FROM ConceptoCont WHERE coc_codigo = {cocCodigo}");
        }
    }
}
