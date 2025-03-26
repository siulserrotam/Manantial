using Manantial.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Manantial.Infraestructura.Datos;
using Manantial.Infraestructure.Data;  // Ajuste a tu namespace para el contexto de la base de datos

namespace Manantial.Infraestructura.Datos
{
    public class SemillaContextoTienda
    {
        // Método estático asincrónico para sembrar los datos en la base de datos.
        public static async Task SembrarDatosAsync(ContextoTienda contexto, ILoggerFactory loggerFactory)
        {
            try
            {
                // Verificar si la tabla CATEGORIA tiene datos
                if (!contexto.Categorias.Any())
                {
                    // Si no existen categorías, lee el archivo JSON que contiene los datos de las categorías.
                    var categoriasData = File.ReadAllText("../Manantial.Infraestructura/Datos/Seed/categorias.json");

                    // Deserializa el contenido del archivo JSON a una lista de objetos Categoria.
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriasData);

                    // Itera a través de las categorías deserializadas y las agrega a la base de datos.
                    foreach (var item in categorias)
                    {
                        contexto.Categorias.Add(item);
                    }

                    // Guarda los cambios en la base de datos de forma asincrónica.
                    await contexto.SaveChangesAsync();
                }

                // Verificar si la tabla MARCA tiene datos
                if (!contexto.Marcas.Any())
                {
                    // Si no existen marcas, lee el archivo JSON que contiene los datos de las marcas.
                    var marcasData = File.ReadAllText("../Manantial.Infraestructura/Datos/Seed/marcas.json");

                    // Deserializa el contenido del archivo JSON a una lista de objetos Marca.
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(marcasData);

                    // Itera a través de las marcas deserializadas y las agrega a la base de datos.
                    foreach (var item in marcas)
                    {
                        contexto.Marcas.Add(item);
                    }

                    // Guarda los cambios en la base de datos de forma asincrónica.
                    await contexto.SaveChangesAsync();
                }

                // Verificar si la tabla PRODUCTO tiene datos
                if (!contexto.Productos.Any())
                {
                    // Si no existen productos, lee el archivo JSON que contiene los datos de los productos.
                    var productosData = File.ReadAllText("../Manantial.Infraestructura/Datos/Seed/productos.json");

                    // Deserializa el contenido del archivo JSON a una lista de objetos Producto.
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productosData);

                    // Itera a través de los productos deserializados y los agrega a la base de datos.
                    foreach (var item in productos)
                    {
                        contexto.Productos.Add(item);
                    }

                    // Guarda los cambios en la base de datos de forma asincrónica.
                    await contexto.SaveChangesAsync();
                }

                // Verificar si la tabla CLIENTE tiene datos
                if (!contexto.Clientes.Any())
                {
                    // Si no existen clientes, lee el archivo JSON que contiene los datos de los clientes.
                    var clientesData = File.ReadAllText("../Manantial.Infraestructura/Datos/Seed/clientes.json");

                    // Deserializa el contenido del archivo JSON a una lista de objetos Cliente.
                    var clientes = JsonSerializer.Deserialize<List<Cliente>>(clientesData);

                    // Itera a través de los clientes deserializados y los agrega a la base de datos.
                    foreach (var item in clientes)
                    {
                        contexto.Clientes.Add(item);
                    }

                    // Guarda los cambios en la base de datos de forma asincrónica.
                    await contexto.SaveChangesAsync();
                }

                // Verificar si la tabla USUARIO tiene datos
                if (!contexto.Usuarios.Any())
                {
                    // Si no existen usuarios, lee el archivo JSON que contiene los datos de los usuarios.
                    var usuariosData = File.ReadAllText("../Manantial.Infraestructura/Datos/SeedData/usuarios.json");

                    // Deserializa el contenido del archivo JSON a una lista de objetos Usuario.
                    var usuarios = JsonSerializer.Deserialize<List<Usuario>>(usuariosData);

                    // Itera a través de los usuarios deserializados y los agrega a la base de datos.
                    foreach (var item in usuarios)
                    {
                        contexto.Usuarios.Add(item);
                    }

                    // Guarda los cambios en la base de datos de forma asincrónica.
                    await contexto.SaveChangesAsync();
                }

                // Verificar si la tabla BARRIO tiene datos
                if (!contexto.Barrios.Any())
                {
                    // Si no existen barrios, lee el archivo JSON que contiene los datos de los barrios.
                    var barriosData = File.ReadAllText("../Manantial.Infraestructura/Datos/SeedData/barrios.json");

                    // Deserializa el contenido del archivo JSON a una lista de objetos Barrio.
                    var barrios = JsonSerializer.Deserialize<List<Barrio>>(barriosData);

                    // Itera a través de los barrios deserializados y los agrega a la base de datos.
                    foreach (var item in barrios)
                    {
                        contexto.Barrios.Add(item);
                    }

                    // Guarda los cambios en la base de datos de forma asincrónica.
                    await contexto.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Si ocurre algún error, se captura la excepción y se registra en el log.
                var logger = loggerFactory.CreateLogger<SemillaContextoTienda>();
                logger.LogError(ex.Message);  // Registra el mensaje de error.
            }
        }
    }
}
