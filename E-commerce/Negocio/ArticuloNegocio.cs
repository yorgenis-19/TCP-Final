﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConexion("SELECT A.ID_Articulo,A.NombreArticulo,A.Descripcion,A.Estado,A.Talla, C.NombreCategoria AS Categoria,M.NombreMarca AS Marca,A.Precio,A.Stock,STRING_AGG(I.Url_Imagen, ';') AS Imagenes\r\nFROM Articulos A INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca LEFT JOIN Imagenes I ON I.ID_Articulo = A.ID_Articulo WHERE A.Estado= 1\r\nGROUP BY A.ID_Articulo, A.NombreArticulo, A.Descripcion, A.Talla, A.Estado, C.NombreCategoria, M.NombreMarca, A.Precio, A.Stock");
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                    articulo.marca = new Marca();
                    articulo.marca.nombreMarca = (string)datos.Lector["Marca"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["stock"];
                    articulo.talle = (string)datos.Lector["Talla"];
                    articulo.Estado = (int)datos.Lector["Estado"];
                    articulo.listaImagenes = new List<Imagen>();
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Imagenes")))
                    {
                        Imagen imagen = new Imagen();
                        imagen.UrlImagen = (string)datos.Lector["Imagenes"];
                        articulo.listaImagenes.Add(imagen);
                    }
                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> BuscarPorMarca(int idMarca)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            MarcaNegocio marcaDB = new MarcaNegocio();
            CategoriaNegocio categoriaDB = new CategoriaNegocio();

            try
            {
                if (idMarca == 0)
                {
                    datos.setearConsulta("SELECT * FROM ARTICULOS");
                }
                else
                {
                    datos.setConexion("SELECT a.ID_Articulo, a.NombreArticulo, a.Descripcion, a.Precio, a.stock, a.Talla, i.Url_Imagen as ImagenUrl FROM ARTICULOS as a inner join Imagenes as i on i.ID_Articulo = a.ID_Articulo where a.ID_Marca = @IdMarca");
                    datos.setearParametro("@IdMarca", idMarca);
                    datos.abrirConexion();
                }

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["stock"];
                    articulo.talle = (string)datos.Lector["Talla"];

                    articulo.listaImagenes = new List<Imagen>();

                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("ImagenUrl")))
                    {
                        Imagen imagen = new Imagen();
                        imagen.UrlImagen = (string)datos.Lector["ImagenUrl"];
                        articulo.listaImagenes.Add(imagen);
                    }

                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> BuscarPorNombre(string nombre)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            MarcaNegocio marcaDB = new MarcaNegocio();
            CategoriaNegocio categoriaDB = new CategoriaNegocio();

            try
            {
                datos.setearConsulta("SELECT * FROM ARTICULOS WHERE Nombre LIKE @Nombre");
                datos.setearParametro("@Nombre", "%" + nombre + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = Convert.ToInt32(datos.Lector["IdArticulo"]);
                    articulo.nombreArticulo = Convert.ToString(datos.Lector["Nombre"]);
                    articulo.descripcion = Convert.ToString(datos.Lector["Descripcion"]);
                    articulo.precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    articulo.stock = Convert.ToInt32(datos.Lector["Stock"]);
                    articulo.talle = Convert.ToString(datos.Lector["Talle"]);
                    articulo.Estado = Convert.ToInt32(datos.Lector["Estado"]);



                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Articulo> ListarconSP()

        {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("sp_ListarArticulos");
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                    articulo.marca = new Marca();
                    articulo.marca.nombreMarca = (string)datos.Lector["Marca"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["stock"];
                    articulo.Estado = int.Parse(datos.Lector["Estado"].ToString());
                    articulo.listaImagenes = new List<Imagen>();
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Imagenes")))
                    {
                        Imagen imagen = new Imagen();
                        imagen.UrlImagen = (string)datos.Lector["Imagenes"];
                        articulo.listaImagenes.Add(imagen);
                    }

                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Articulo buscarPorID(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConexion("SELECT A.ID_Articulo, A.NombreArticulo, A.Descripcion, A.Talla, C.ID_Categoria, C.NombreCategoria AS Categoria, M.ID_Marca, M.NombreMarca AS Marca, A.Precio, A.Stock, A.Estado, I.Url_Imagen FROM Articulos A INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca LEFT JOIN Imagenes I ON I.ID_Articulo = A.ID_Articulo WHERE A.ID_Articulo = @ID");
                datos.setearParametro("@ID", Id);
                datos.abrirConexion();

                Articulo articulo = null;

                while (datos.Lector.Read())
                {
                    if (articulo == null)
                    {
                        articulo = new Articulo();
                        articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                        articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                        articulo.descripcion = (string)datos.Lector["Descripcion"];
                        articulo.categoria = new Categoria();
                        articulo.categoria.idCategoria = (int)datos.Lector["ID_Categoria"];
                        articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                        articulo.marca = new Marca();
                        articulo.marca.idMarca = (int)datos.Lector["ID_Marca"];
                        articulo.marca.nombreMarca = (string)datos.Lector["Marca"];
                        articulo.precio = (decimal)datos.Lector["Precio"];
                        articulo.stock = (int)datos.Lector["Stock"];
                        articulo.talle = (string)datos.Lector["Talla"];
                        articulo.Estado = (int)datos.Lector["Estado"];
                        articulo.listaImagenes = new List<Imagen>();
                    }

                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Url_Imagen")))
                    {
                        Imagen imagen = new Imagen();
                        imagen.UrlImagen = (string)datos.Lector["Url_Imagen"];
                        articulo.listaImagenes.Add(imagen);
                    }
                }

                return articulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Articulo> buscarPorCategoria(string categoria)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
             ///datos.setConexion("SELECT A.ID_Articulo, A.NombreArticulo, A.Descripcion, C.ID_Categoria ,C.NombreCategoria AS Categoria, M.ID_Marca ,M.NombreMarca AS Marca, A.Precio, A.Stock, A.Estado FROM Articulos A INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca WHERE C.NombreCategoria = @Categoria");
             ///datos.setConexion("SELECT A.ID_Articulo as id, A.NombreArticulo, A.Descripcion, C.ID_Categoria ,C.NombreCategoria AS Categoria, M.ID_Marca ,M.NombreMarca AS Marca, I.ID_Imagen, I.Url_Imagen as ImagenUrl, A.Precio, A.Stock, A.Estado FROM Articulos A INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca Right JOIN Imagenes I on I.ID_Articulo = A.ID_Articulo WHERE C.NombreCategoria = @Categoria");
                datos.setConexion("SELECT A.ID_Articulo as id, A.NombreArticulo, A.Descripcion, C.ID_Categoria, C.NombreCategoria AS Categoria, M.ID_Marca, M.NombreMarca AS Marca, STRING_AGG(I.Url_Imagen, ';') AS Imagenes, A.Precio, A.Stock, A.Estado FROM  Articulos A INNER JOIN  Categorias C ON C.ID_Categoria = A.ID_Categoria INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca LEFT JOIN Imagenes I ON I.ID_Articulo = A.ID_Articulo WHERE C.NombreCategoria = @Categoria GROUP BY A.ID_Articulo, A.NombreArticulo, A.Descripcion, C.ID_Categoria, C.NombreCategoria, M.ID_Marca, M.NombreMarca, A.Precio, A.Stock, A.Estado ");
                datos.setearParametro("@Categoria", categoria);
                datos.abrirConexion();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["id"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombreCategoria = (string)datos.Lector["Categoria"];
                    articulo.marca = new Marca();
                    articulo.marca.nombreMarca = (string)datos.Lector["Marca"];
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["stock"];
                    articulo.listaImagenes = new List<Imagen>();
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Imagenes")))
                    {
                        string imagenes = (string)datos.Lector["Imagenes"];
                        string[] urls = imagenes.Split(';');
                        foreach (string url in urls)
                        {
                            Imagen imagen = new Imagen();
                            imagen.UrlImagen = url;
                            articulo.listaImagenes.Add(imagen);
                        }
                        /*Imagen imagen = new Imagen();
                        imagen.UrlImagen = (string)datos.Lector["ImagenUrl"];
                        articulo.listaImagenes.Add(imagen);*/
                    }
                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int agregar(Articulo nuevo)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConexion("INSERT INTO Articulos (NombreArticulo, Descripcion, ID_Categoria, ID_Marca, Precio, Stock, Talla, Estado) output inserted.ID_Articulo VALUES (@NombreArticulo, @Descripcion, @ID_Categoria, @ID_Marca, @Precio, @Stock, @Talla, @Estado);");
                datos.setearParametro("@NombreArticulo", nuevo.nombreArticulo);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@ID_Categoria", nuevo.categoria.idCategoria);
                datos.setearParametro("@ID_Marca", nuevo.marca.idMarca);
                datos.setearParametro("@Precio", nuevo.precio);
                datos.setearParametro("@Stock", nuevo.stock);
                datos.setearParametro("@Talla", nuevo.talle);
                datos.setearParametro("@Estado", nuevo.Estado);
                int ultimaFila = datos.ejecutarAccionConOutput();
                return ultimaFila;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void modificarConSP(Articulo arti)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("sp_ModificarArticulo");
                datos.setearParametro("@ID_Articulo", arti.idArticulo);
                datos.setearParametro("@NombreArticulo", arti.nombreArticulo);
                datos.setearParametro("@Descripcion", arti.descripcion);
                datos.setearParametro("@ID_Categoria", arti.categoria.idCategoria);
                datos.setearParametro("@ID_Marca", arti.marca.idMarca);
                datos.setearParametro("@Precio", arti.precio);
                datos.setearParametro("@Stock", arti.stock);
                datos.setearParametro("@Talla", arti.talle);
                datos.setearParametro("@Estado", arti.Estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }


        public void EliminarArticulo(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("sp_EliminarArticulo");
                datos.setearParametro("@ID_Articulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int generarNumPedido(Articulo compra, int idUsuario)
        {
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setConexion("insert into Pedidos(ID_Usuario,Importe) output inserted.ID_Pedido values(@idUsuario,@importe)");
                datos2.setearParametro("@idUsuario", idUsuario);
                datos2.setearParametro("@importe", compra.precio);
                int idPedido = datos2.ejecutarAccionConOutput();
                return idPedido;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos2.cerrarConexion();
            }
        }

        public void modificarEstadoCompra(int idPedido, int estado)
        {
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setConexion("update Pedidos set Estado=@estado where ID_Pedido=@idPedido");
                datos2.setearParametro("@idPedido", idPedido);
                datos2.setearParametro("@estado", estado);
                datos2.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos2.cerrarConexion();
                /*if (estado == 4)
                {
                    modificarDetalleCompra(idPedido,0);
                }*/
            }
        }

        public void modificarDetalleCompra(int idPedido, int estado)
        {
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setConexion("update DetallePedidos set Estado=@estado where ID_Pedido=@idPedido");
                datos2.setearParametro("@idPedido", idPedido);
                datos2.setearParametro("@estado", estado);
                datos2.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos2.cerrarConexion();
            }
        }

        public void insertarDetallePedido(Articulo articulo, int idPedido)
        {
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setConexion("insert into DetallePedidos(Cantidad,Talle,ID_Articulo,ID_Pedido,Importe) values(@cantidad,@talle,@idArticulo,@idPedido,@importe)");
             datos2.setearParametro("@cantidad", articulo.Cantidad);
            datos2.setearParametro("@talle", articulo.talle);
                datos2.setearParametro("@idArticulo", articulo.idArticulo);
                datos2.setearParametro("@idPedido", idPedido);
                datos2.setearParametro("@importe", articulo.precio);
                datos2.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos2.cerrarConexion();
            }
        }


        public void actualizarDetallePedido(Articulo articulo, int idPedido)
        {
            AccesoDatos datos2 = new AccesoDatos();
            try
            {
                datos2.setConexion("update DetallePedidos set Cantidad=@cantidad,Importe=@importe where ID_Articulo=@idArticulo and Talle like @talle and ID_Pedido=@idPedido");
             datos2.setearParametro("@cantidad", articulo.Cantidad);
            datos2.setearParametro("@talle", articulo.talle);
                datos2.setearParametro("@idArticulo", articulo.idArticulo);
                datos2.setearParametro("@idPedido", idPedido);
                datos2.setearParametro("@importe", articulo.precio);
                datos2.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos2.cerrarConexion();
            }
        }

        public Articulo buscarPorId(int Id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            MarcaNegocio marcaService = new MarcaNegocio();
            CategoriaNegocio categoriaService = new CategoriaNegocio();

            try
            {
                connection.ConnectionString = "server=.\\SQLEXPRESS; database=Ecommerce; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM [dbo].[Articulos] WHERE ID_Articulo = @Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = connection;

                connection.Open();
                reader = cmd.ExecuteReader();
                Dominio.Articulo articulo;

                while (reader.Read())
                {
                    articulo = new Dominio.Articulo();
                    articulo.marca = new Marca();
                    articulo.categoria = new Dominio.Categoria();
                    articulo.idArticulo = reader.GetInt32(0);

                    articulo.nombreArticulo = (string)reader["Nombre"];
                    articulo.descripcion = (string)reader["Descripcion"];
                    int idMarca = (int)reader["IdMarca"];
                    articulo.marca.nombreMarca = marcaService.obtener(idMarca);
                    int idCategoria = (int)reader["IdCategoria"];
                    articulo.categoria.nombreCategoria = categoriaService.obtener(idCategoria);
                    articulo.precio = (decimal)reader["Precio"];
                    if (articulo.idArticulo == Id)
                    {
                        return articulo;
                    }
                }
                //MessageBox.Show("Articulo no encontrado");
                return articulo = null;


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Articulo> FiltrarArticulos(string categoria, List<int> marcas, List<int> tallas)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT A.ID_Articulo, A.NombreArticulo, A.Descripcion, C.ID_Categoria, C.NombreCategoria AS Categoria, M.ID_Marca, M.NombreMarca AS Marca, STRING_AGG(I.Url_Imagen, ';') AS Imagenes, A.Precio, A.Stock, A.Estado ");
                query.Append("FROM Articulos A ");
                query.Append("INNER JOIN Categorias C ON C.ID_Categoria = A.ID_Categoria ");
                query.Append("INNER JOIN Marcas M ON M.ID_Marca = A.ID_Marca ");
                query.Append("LEFT JOIN Imagenes I ON I.ID_Articulo = A.ID_Articulo ");
                query.Append("WHERE A.Estado = 1 AND A.Stock > 0 ");

                if (!string.IsNullOrEmpty(categoria))
                {
                    query.Append("AND C.NombreCategoria = @Categoria ");
                }

                if (marcas != null && marcas.Count > 0)
                {
                    query.Append("AND M.ID_Marca IN (" + string.Join(",", marcas) + ") ");
                }

                if (tallas != null && tallas.Count > 0)
                {
                    query.Append("AND A.Talla IN (" + string.Join(",", tallas) + ") ");
                }

                query.Append("GROUP BY A.ID_Articulo, A.NombreArticulo, A.Descripcion, C.ID_Categoria, C.NombreCategoria, M.ID_Marca, M.NombreMarca, A.Precio, A.Stock, A.Estado ");

                datos.setConexion(query.ToString());

                if (!string.IsNullOrEmpty(categoria))
                {
                    datos.setearParametro("@Categoria", categoria);
                }

                datos.abrirConexion();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.idArticulo = (int)datos.Lector["ID_Articulo"];
                    articulo.nombreArticulo = (string)datos.Lector["NombreArticulo"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.categoria = new Categoria
                    {
                        idCategoria = (int)datos.Lector["ID_Categoria"],
                        nombreCategoria = (string)datos.Lector["Categoria"]
                    };
                    articulo.marca = new Marca
                    {
                        idMarca = (int)datos.Lector["ID_Marca"],
                        nombreMarca = (string)datos.Lector["Marca"]
                    };
                    articulo.precio = (decimal)datos.Lector["Precio"];
                    articulo.stock = (int)datos.Lector["Stock"];
                    articulo.Estado = (int)datos.Lector["Estado"];
                    articulo.listaImagenes = new List<Imagen>();

                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Imagenes")))
                    {
                        string imagenes = (string)datos.Lector["Imagenes"];
                        string[] urls = imagenes.Split(';');
                        foreach (string url in urls)
                        {
                            Imagen imagen = new Imagen
                            {
                                UrlImagen = url
                            };
                            articulo.listaImagenes.Add(imagen);
                        }
                    }

                    lista.Add(articulo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        
    }
    }
}
