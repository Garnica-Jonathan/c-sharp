using System.Data.SqlClient;
namespace Primer_Proyecto_Final
{
    public class ProductosVendidoHandler : DbHandler
    {
        public List<ProductosVendido> GetProductosVendidoo()
        {
            List<ProductosVendido> resultado = new List<ProductosVendido>();

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
                                ProductosVendido prodVend = new ProductosVendido();

                                prodVend.Id = Convert.ToInt32(dataReader["Id"]);
                                prodVend.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                prodVend.Nombre = dataReader["Nombre"].ToString();
                                prodVend.Apellido = dataReader["Apellido"].ToString();
                                prodVend.Contraseña = dataReader["Contraseña"].ToString();
                                prodVend.Mail = dataReader["Mail"].ToString();

                                resultado.Add(prodVend);
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