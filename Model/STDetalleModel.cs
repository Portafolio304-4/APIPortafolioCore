using DTOs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class STDetalleModel
    {
        private Conexion conn;
        private STDetalle st_detalle;
        public STDetalleModel(STDetalle st_detalle)
        {
            this.STDetalle = st_detalle;
        }

        public Conexion Conn { get => conn; set => conn = value; }
        public STDetalle STDetalle { get => st_detalle; set => st_detalle = value; }

        public List<STDetalle> GetSTDetalles()
        {
            this.Conn = new Conexion();

            List<STDetalle> lista_st_detalle = new List<STDetalle>();
            string sql = "SELECT * FROM ST_DETALLE std" +
                "JOIN SERVICIO_TURISTICO st" +
                "ON(std.id_servicio_turistico = st._id_servicio_turisitico) " +
                "WHERE st.habilitado=1";

            OracleCommand command = new OracleCommand(sql, this.Conn.Connection);
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int id_actividad = reader.GetInt32(1);
                int id_servicio_turistico = reader.GetInt32(2);
                int id_transporte = reader.GetInt32(3);
                int id_estadia = reader.GetInt32(4);
                int id_seguro_viaje = reader.GetInt32(5);

                STDetalle st_detalle = new STDetalle(id, id_actividad, id_servicio_turistico, id_transporte, id_estadia, id_seguro_viaje);
                lista_st_detalle.Add(st_detalle);

            }

            this.Conn.Connection.Close();
            command.Dispose();

            return lista_st_detalle;
        }


        public bool ReadById()
        {
            bool found = false;
            this.Conn = new Conexion();

            string sql = "SELECT * FROM ST_DETALLE WHERE id_st_detalle=:id";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.STDetalle.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    this.STDetalle.Id = reader.GetInt32(0);
                    this.STDetalle.Id_actividad = reader.GetInt32(1);
                    this.STDetalle.Id_servicio_turistico = reader.GetInt32(2);
                    this.STDetalle.Id_transporte = reader.GetInt32(3);
                    this.STDetalle.Id_estadia = reader.GetInt32(4);
                    this.STDetalle.Id_seguro_viaje = reader.GetInt32(5);

                }
                if (reader.HasRows)
                    found = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.Conn.Connection.Close();
            command.Dispose();

            return found;
        }

        public bool Create()
        {
            bool created = false;
            this.Conn = new Conexion();

            string sql = "INSERT INTO ST_DETALLE " +
                "(id_actividad,id_servicio_turistico,id_transporte,id_estadia,id_seguro_viaje)" +
                " VALUES" +
                "(:id_actividad,:id_servicio_turistico,:id_transporte,:id_estadia,:id_seguro_viaje)";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("rut", OracleDbType.Int32)).Value = this.STDetalle.Id_actividad;
            command.Parameters.Add(new OracleParameter("id_servicio_turistico", OracleDbType.Int32)).Value = this.STDetalle.Id_servicio_turistico;
            command.Parameters.Add(new OracleParameter("id_transporte", OracleDbType.Int32)).Value = this.STDetalle.Id_transporte;
            command.Parameters.Add(new OracleParameter("id_estadia", OracleDbType.Int32)).Value = this.STDetalle.Id_estadia;
            command.Parameters.Add(new OracleParameter("id_seguro_viaje", OracleDbType.Int32)).Value = this.STDetalle.Id_seguro_viaje;

            try
            {
                int rowsUpdated = command.ExecuteNonQuery();
                if (rowsUpdated > 0)
                {
                    created = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.Conn.Connection.Close();
            command.Dispose();

            return created;
        }

        public bool Update()
        {
            bool updated = false;
            this.Conn = new Conexion();

            string sql = "UPDATE ST_DETALLE SET " +
                "id_actividad=:id_actividad " +
                "id_servicio_turistico=:id_servicio_turistico " +
                "id_transporte=:id_transporte " +
                "id_estadia=:id_estadia " +
                "id_seguro_viaje=:id_seguro_viaje " +
                " WHERE id_st_detalle=:id_st_detalle";

            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id_actividad", OracleDbType.Int32)).Value = this.STDetalle.Id_actividad;
            command.Parameters.Add(new OracleParameter("id_servicio_turistico", OracleDbType.Int32)).Value = this.STDetalle.Id_servicio_turistico;
            command.Parameters.Add(new OracleParameter("id_transporte", OracleDbType.Int32)).Value = this.STDetalle.Id_transporte;
            command.Parameters.Add(new OracleParameter("id_estadia", OracleDbType.Int32)).Value = this.STDetalle.Id_estadia;
            command.Parameters.Add(new OracleParameter("id_st_detalle", OracleDbType.Int32)).Value = this.STDetalle.Id;

            try
            {
                int rowsUpdated = command.ExecuteNonQuery();
                if (rowsUpdated > 0)
                    updated = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.Conn.Connection.Close();
            command.Dispose();

            return updated;
        }

        public int PrecioSTSinSeguro()
        { 
            this.Conn = new Conexion();
            int precio = -1;
            string sql = "SELECT (a.precio_por_persona + e.precio_por_persona + t.precio_por_persona) " +
                "precio_por_persona FROM ST_DETALLE st " +
                "JOIN ACTIVIDAD a " +
                "ON(a.id_actividad = st.id_actividad) " +
                "JOIN ESTADIA e " +
                "ON(e.id_estadia = st.id_estadia) " +
                "JOIN TRANSPORTE t " +
                "ON(t.id_transporte = st.id_transporte) " +
                "WHERE id_st_detalle=:";


            OracleCommand command = new OracleCommand();
            command.CommandText = sql;
            command.Connection = this.Conn.Connection;
            command.Parameters.Add(new OracleParameter("id", OracleDbType.Int32)).Value = this.STDetalle.Id;
            OracleDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    precio = reader.GetInt32(0);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            this.Conn.Connection.Close();
            command.Dispose();

            return precio;

        }
    }
}
