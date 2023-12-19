using System;

public class Program
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

        private EspecieMascotaEnum _especie;
        public EspecieMascotaEnum Especie
        {
            get { return _especie; }
            set { _especie = value; }
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
                if (value <= 0 || value > EdadMaxima)
                {
                    throw new Exception($"La edad debe ser mayor a 0 y no exceder la edad máxima de {EdadMaxima} años.");
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
                    throw new Exception("El temperamento no puede estar en blanco.");
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
                    throw new Exception("La mascota debe tener dueño.");
                }

                _dueño = value;
            }
        }

        public int EdadMaxima { get; protected set; }

        public Mascota(string nombre, int edad, TemperamentoEnum temperamento, string dueño, EspecieMascotaEnum especie, int edadMaxima)
        {
            Id = lastIdAdded + 1;
            lastIdAdded++;

            Nombre = nombre;
            EdadMaxima = edadMaxima;
            Edad = edad;
            Temperamento = temperamento.ToString();
            Dueño = dueño;
            Especie = especie;
        }

     
        public class Perro : Mascota
        {
            public Perro(string nombre, int edad, TemperamentoEnum temperamento, string dueño)
                : base(nombre, edad, temperamento, dueño, EspecieMascotaEnum.Perro, 14)
            {
            }

            public void MoverCola()
            {
                Console.WriteLine("Cola en movimiento.");
            }

            public void Gruñir()
            {
                Console.WriteLine("Grrrrr...");
            }

            public  void HacerRuido()
            {
                Console.WriteLine("¡Guau! ¡Guau! ");
            }
        }

        public class Gato : Mascota
        {
            public Gato(string nombre, int edad, TemperamentoEnum temperamento, string dueño)
                : base(nombre, edad, temperamento, dueño, EspecieMascotaEnum.Gato, 18)
            {
            }

            public void Ronronear()
            {
                Console.WriteLine("Ronroneando...");
            }

            public void Rasguñar()
            {
                Console.WriteLine("¡Rasguño!");
            }

            public void HacerRuido()
            {
                Console.WriteLine("¡Miau! ¡Miau!");
            }
        }

        public class Capibara : Mascota
        {
            public Capibara(string nombre, int edad, string dueño)
                : base(nombre, edad, TemperamentoEnum.Amable, dueño, EspecieMascotaEnum.Capibara, 11)
            {
            }

            public  void HacerRuido()
            {
                Console.WriteLine("¡Cui! ¡Cui!");
            }
        }
    }

   

    public enum EspecieMascotaEnum
    {
        Perro,
        Gato,
        Capibara
    }

    public enum TemperamentoEnum
    {
        Amable,
        Nervioso,
        Agresivo
    }
}
