using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }



    public class Mascota
    {
        private static int lastIdAdded = 0;

        private int _id;
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }


        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El nombre de una Mascota no puede estar en blanco.");
                }

                _nombre = value;
            }
        }


        private int _edad;
        public int Edad
        {
            get { return _edad; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("La edad debe ser mayor a 0.");
                }
                _edad = value;
            }
        }



        private string _temperamento;
        public string Temperamento
        {
            get { return _temperamento; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El temperamneto no puede estar en blanco.");
                }

                _temperamento = value;
            }
        }

        private string _dueño;
        public string Dueño
        {
            get { return _dueño; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("EL perro debe tener dueño.");
                }

                _dueño = value;
            }
        }


        public Mascota(string nombre, int edad, string temperamento,string dueño)
        {
            Nombre = nombre;
            Edad = edad;
            Temperamento = temperamento;
            Dueño = dueño;

            Id = lastIdAdded + 1;
            lastIdAdded++;
        }


    }














    private void HacerRuido()
    {

    }

    private void CambarDueño()
    {

    }




    public class Perros
    {
     

    }

    public class Gatos
    {


    }

    public class Capibaras
    {


    }



}