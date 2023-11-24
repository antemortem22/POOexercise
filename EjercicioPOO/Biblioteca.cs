using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EjercicioPoo
{
    internal class Biblioteca
    {
        public List<Libro> libros {  get; set; }

        public Biblioteca() 
        {
            libros = new List<Libro>();
        }

        public void ListarLibros()
        {
            Console.WriteLine("Lista de libros:");
            foreach (var libro in libros)
            {
                Console.WriteLine($"Titulo: {libro.nombre}");
                Console.WriteLine($"Autor: {libro.autor} ");
                Console.WriteLine($"Descripcion: {libro.descripcion}");
                Console.WriteLine($"Prestado: {libro.prestado}");
            }
            Console.WriteLine();
        }

        public void PrestarLibro(string titulo, string nombreEstudiante)
        {
            var libro = libros.Find(l => l.nombre == titulo);
            if (libro != null && !libro.prestado) 
            {
                libro.prestado = true;
                Console.WriteLine($"El libro '{titulo}' ha sido prestado correctamente");
            }
            else
            {
                Console.WriteLine($"El libro '{titulo}' no esta disponible");
            }
        }

        public void DevolverLibro(string titulo) 
        {
            var libro = libros.Find(l => l.nombre == titulo);
            if ( libro != null && libro.prestado)
            {
                libro.prestado = false;
                Console.WriteLine($"El libro '{titulo}' ha sido devuelto correctamente");
            }
            else
            {
                Console.WriteLine($"El libro '{titulo}' no existe o no ha sido prestado");
            }
        }

        public void ConsultarLibrosPrestados(string nombreEstudiante)
        {
            var librosPrestados = libros.FindAll(l => l.prestado);
            if (librosPrestados.Count > 0)
            {
                Console.WriteLine($"Libros prestados a {nombreEstudiante}:");
                foreach (var libro in librosPrestados)
                {
                    Console.WriteLine($"Titulo: {libro.nombre}");
                    Console.WriteLine($"Autor: {libro.autor}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"No hay libros prestados a {nombreEstudiante}.");
            }
            Console.WriteLine();
        }

    }
}
