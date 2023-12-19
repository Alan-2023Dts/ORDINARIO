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

        public Mascota(string nombre, int edad, TemperamentoEnum temperamento, string dueño, EspecieMascotaEnum especie)
        {
            Id = lastIdAdded + 1;
            lastIdAdded++;

            Nombre = nombre;
            Edad = edad;
            Temperamento = temperamento.ToString();
            Dueño = dueño;
            Especie = especie;
        }

        public void HacerRuido()
        {
            switch (Especie)
            {
                case EspecieMascotaEnum.Perro:
                    Console.WriteLine("¡Guau!");
                    break;
                case EspecieMascotaEnum.Gato:
                    Console.WriteLine("¡Miau! ");
                    break;
                case EspecieMascotaEnum.Capibara:
                    Console.WriteLine("cui cui");
                    break;
                default:
                    Console.WriteLine("¡Haciendo ruido!");
                    break;
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

    public class Perro : Mascota
    {
        public Perro(string nombre, int edad, TemperamentoEnum temperamento, string dueño)
            : base(nombre, edad, temperamento, dueño, EspecieMascotaEnum.Perro)
        {
       
        }
    }

    public class Gato : Mascota
    {
        public Gato(string nombre, int edad, TemperamentoEnum temperamento, string dueño)
            : base(nombre, edad, temperamento, dueño, EspecieMascotaEnum.Gato)
        {
           
        }
    }

    public class Capibara : Mascota
    {
        public Capibara(string nombre, int edad, TemperamentoEnum temperamento, string dueño)
            : base(nombre, edad, temperamento, dueño, EspecieMascotaEnum.Capibara)
        {

        }
    }
}
