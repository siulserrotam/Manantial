using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Infraestructure.Data;

namespace Infraestructure.Data
{
    public class SemillaContextoTienda
    {
        // Método estático asincrónico para sembrar los datos en la base de datos.
        public static async Task SembrarDatosAsync(ContextoTienda contexto, ILoggerFactory loggerFactory)
        {
            try
            {
                // Sembrar Categorías
                if (!contexto.Categorias.Any())
                {
                    var categoriasData = File.ReadAllText("../Infraestructure/Data/Seed/categorias.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriasData);

                    // Itera a través de las categorías deserializadas y las agrega a la base de datos.
                    foreach (var item in categorias)
                    {
                        contexto.Categorias.Add(item);
                    }

                    // Guarda los cambios en la base de datos de forma asincrónica.
                    await contexto.SaveChangesAsync();
                }

                // Sembrar Marcas
                if (!contexto.Marcas.Any())
                {
                    var marcasData = File.ReadAllText("../Infraestructure/Data/Seed/marcas.json");
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(marcasData);

                    // Itera a través de las marcas deserializadas y las agrega a la base de datos.
                    foreach (var item in marcas)
                    {
                        contexto.Marcas.Add(item);
                    }
                    await contexto.SaveChangesAsync();  // Guarda las marcas primero
                }

                // Sembrar Departamentos
                if (!contexto.Departamentos.Any())
                {
                    var departamentosData = File.ReadAllText("../Infraestructure/Data/Seed/departamentos.json");
                    var departamentos = JsonSerializer.Deserialize<List<Departamento>>(departamentosData);
                    foreach (var item in departamentos)
                    {
                        contexto.Departamentos.Add(item);
                    }
                    await contexto.SaveChangesAsync();
                }

                // Sembrar Ciudades
                if (!contexto.Ciudades.Any())
                {
                    var ciudadesData = File.ReadAllText("../Infraestructure/Data/Seed/ciudades.json");
                    var ciudades = JsonSerializer.Deserialize<List<Ciudad>>(ciudadesData);
                    foreach (var item in ciudades)
                    {
                        contexto.Ciudades.Add(item);
                    }
                    await contexto.SaveChangesAsync();
                }

                // Sembrar Barrios
                if (!contexto.Barrios.Any())
                {
                    var barriosData = File.ReadAllText("../Infraestructure/Data/Seed/barrios.json");
                    var barrios = JsonSerializer.Deserialize<List<Barrio>>(barriosData);

                    foreach (var item in barrios)
                    {
                        // Verificar si las claves foráneas existen antes de agregar el barrio
                        var departamento = await contexto.Departamentos.FindAsync(item.Fk_IdDepartamento);
                        var ciudad = await contexto.Ciudades.FindAsync(item.Fk_IdCiudad);

                        if (departamento != null && ciudad != null)
                        {
                            contexto.Barrios.Add(item);
                        }
                    }

                    await contexto.SaveChangesAsync();
                }

                // Sembrar Productos
                if (!contexto.Productos.Any())
                {
                    var productosData = File.ReadAllText("../Infraestructure/Data/Seed/productos.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productosData);

                    // Verificar que las marcas y categorías existen antes de insertar los productos
                    foreach (var item in productos)
                    {
                        var marca = contexto.Marcas.FirstOrDefault(m => m.Id == item.Fk_IdMarca);
                        var categoria = contexto.Categorias.FirstOrDefault(c => c.Id == item.Fk_IdCategoria);

                        if (marca != null && categoria != null)
                        {
                            item.Marca = marca;  // Establecer relación con Marca
                            item.Categoria = categoria;  // Establecer relación con Categoría
                            contexto.Productos.Add(item);
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger<SemillaContextoTienda>();
                            if (marca == null)
                            {
                                logger.LogWarning($"Marca con Id {item.Fk_IdMarca} no encontrada para el producto {item.Nombre}");
                            }
                            if (categoria == null)
                            {
                                logger.LogWarning($"Categoría con Id {item.Fk_IdCategoria} no encontrada para el producto {item.Nombre}");
                            }
                        }
                    }
                    await contexto.SaveChangesAsync();
                }

                // Sembrar Clientes
                if (!contexto.Clientes.Any())
                {
                    var clientesData = File.ReadAllText("../Infraestructure/Data/Seed/clientes.json");
                    var clientes = JsonSerializer.Deserialize<List<Cliente>>(clientesData);

                    // Itera a través de los clientes deserializados y los agrega a la base de datos.
                    foreach (var item in clientes)
                    {
                        contexto.Clientes.Add(item);
                    }

                    // Guarda los cambios en la base de datos de forma asincrónica.
                    await contexto.SaveChangesAsync();
                }

                // Sembrar Usuarios
                if (!contexto.Usuarios.Any())
                {
                    var usuariosData = File.ReadAllText("../Infraestructure/Data/Seed/usuarios.json");
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
                    var barriosData = File.ReadAllText("../Infraestructure/Data/Seed/barrios.json");

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
