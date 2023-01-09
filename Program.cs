namespace PROYECTO;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[][] matrizPeliculas = new string[10][];
        SortedList<string, listaPeliculas> listaEnlazadaPeliculas = new SortedList<string, listaPeliculas>();


        using (StreamReader reader = new StreamReader("peliculas.txt"))
        {
            // Declara una lista para almacenar los elementos leídos
            List<string> elementos = new List<string>();

            // Lee cada línea del archivo
            string linea;
            while ((linea = reader.ReadLine()) != null)
            {
                // Separa la línea por comas y agrega cada elemento a la lista
                string[] elementosLinea = linea.Split(',');
                elementos.AddRange(elementosLinea);
            }

            for (int i = 0; i < matrizPeliculas.Length; i++)
            {
                matrizPeliculas[i] = new string[6];
                for (int j = 0; j < matrizPeliculas[i].Length; j++)
                {
                    matrizPeliculas[i][j] = elementos[i * matrizPeliculas[i].Length + j];
                }
            }
        }

        while (true)
        {
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Mostrar la tabla de informacion; ");
            Console.WriteLine("2. Ordenas la tabla por nombre de pelicula");
            Console.WriteLine("3. Opción ");
            Console.WriteLine("4. Opción ");
            Console.WriteLine("5. Opción ");
            Console.WriteLine("6. Opción ");
            Console.WriteLine("7. Salir");

            string Opcion = Console.ReadLine();

            switch (Opcion)
            {
                case "1":
                    {
                        Console.WriteLine("\n\nN°:                      NOMBRE:                  AÑO:                CALIFICACION:                   GENERO:                DISPONIBILIDAD:");
                        foreach (string[] fila in matrizPeliculas)
                        {
                            foreach (string elemento in fila)
                            {
                                Console.Write(elemento.PadRight(25));//muestra la matriz
                            }
                            Console.WriteLine();
                        }

                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("\n\nESTA ES LA OPCION 2");
                        foreach (string[] fila in matrizPeliculas)
                        {
                            ingresarPeliculas(fila, listaEnlazadaPeliculas);
                        }

                        foreach (KeyValuePair<string, listaPeliculas> peliculas in listaEnlazadaPeliculas)
                        {
                            Console.WriteLine(peliculas);
                        }

                        string campo = "year"; // el campo por el que se debe ordenar (nombrePelicula, year o genero)
                        List<listaPeliculas> values = new List<listaPeliculas>(listaEnlazadaPeliculas.Values);
                        values.Sort(new PeliculaComparer(campo));


/*
                        foreach (listaPeliculas pelicula in values)
                        {
                            Console.WriteLine(pelicula);
                        }*/
                        break;

                    }
                case "3":
                    {
                        Console.WriteLine("ESTA ES LA OPCION 3");
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("ESTA ES LA OPCION 4");
                        break;
                    }
                case "5":
                    {
                        Console.WriteLine("ESTA ES LA OPCION 5");
                        break;
                    }
                case "6":
                    {
                        Console.WriteLine("ESTA ES LA OPCION 6");
                        break;
                    }
                case "7":
                    {
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Opción inválida");
                        break;
                    }
            }
        }
    }
    public static void ingresarPeliculas(string[] fila, SortedList<string, listaPeliculas> movies)
    {
        short idPelicula = short.Parse(fila[0]);
        string nombrePelicula = fila[1];
        short year = short.Parse(fila[2]);
        double calificacion = double.Parse(fila[3], CultureInfo.InvariantCulture);
        string genero = fila[4];
        string estado = fila[5];

        listaPeliculas peliculas = new listaPeliculas(idPelicula, nombrePelicula, year, calificacion, genero, estado);
        movies.Add(nombrePelicula, peliculas);
    }

    public class MovieComparer : IComparer<KeyValuePair<string, listaPeliculas>>
    {
        private bool _sortByTitle;
        private bool _sortByYear;
        private bool _sortByGenre;

        public MovieComparer(bool sortByTitle, bool sortByYear, bool sortByGenre)
        {
            _sortByTitle = sortByTitle;
            _sortByYear = sortByYear;
            _sortByGenre = sortByGenre;
        }

        public int Compare(KeyValuePair<string, listaPeliculas> x, KeyValuePair<string, listaPeliculas> y)
        {
            if (_sortByTitle)
            {
                int result = x.Value.nombrePelicula.CompareTo(y.Value.nombrePelicula);
                if (result != 0)
                {
                    return result;
                }
            }
            if (_sortByYear)
            {
                int result = x.Value.year.CompareTo(y.Value.year);
                if (result != 0)
                {
                    return result;
                }
            }
            if (_sortByGenre)
            {
                int result = x.Value.genero.CompareTo(y.Value.genero);
                if (result != 0)
                {
                    return result;
                }
            }
            return 0;
        }
    }
         /*
         public static void ingresarPeliculas(string[] fila, LinkedList<listaPeliculas> movies)
         {
             short idPelicula = short.Parse(fila[0]);
             string nombrePelicula = fila[1];
             short year = short.Parse(fila[2]);
             double calificacion = double.Parse(fila[3], CultureInfo.InvariantCulture);
             string genero = fila[4];
             string estado = fila[5];


             listaPeliculas peliculas = new listaPeliculas(idPelicula, nombrePelicula, year, calificacion, genero, estado);
             movies.AddLast(peliculas);

         }
*/
    }














