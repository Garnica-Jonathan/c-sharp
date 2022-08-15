using System.Data.SqlClient;
namespace Primer_Proyecto_Final
{
    public class ProductoHandler : DbHandler
    {
        public List<Producto> GetProductosVendidoo()
        {
            List<Producto> resultado = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto Prod = new Producto();

                                Prod.Id = Convert.ToInt32(dataReader["Id"]);
                                Prod.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                Prod.Nombre = dataReader["Nombre"].ToString();
                                Prod.Apellido = dataReader["Apellido"].ToString();
                                Prod.Contraseña = dataReader["Contraseña"].ToString();
                                Prod.Mail = dataReader["Mail"].ToString();

                                resultado.Add(Prod);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultado;

        }
    }

}