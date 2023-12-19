using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using static Program;

public class Program
{
    private static void Main(string[] args)
    {
        Menu();
       







    }




    static void Menu() 
    {
        Console.WriteLine("1 - Administración del centro\r\n 2 - Administración de adopciones\r\n 3 - Administración de bienestar animal\r\n 4 - Simulación de interacciones\r\n 5 - Finalizar programa");
        int opc = int.Parse(Console.ReadLine());
        switch (opc)
        {
            case 1:
                Console.WriteLine("1 - Administración de personas\r\n2 - Administración de mascotas\r\n3 - Regresar a menú anterior");
                int opc2 = int.Parse(Console.ReadLine());
                switch (opc2)
                {
                    case 1:
                        Console.WriteLine("1 - Mostrar todas la personas registradas\r\n2 - Registrar persona nueva\r\n3 - Buscar personas por nombre\r\n4 - Examinar persona\r\n5 - Regresar al menú anterior");
                        int opc3 = int.Parse(Console.ReadLine());
                        switch (opc3)
                        {
                            case 1:

                            //    MostrarPersonas();

                                break;
                            case 2:
                             //   RegistrarPersona();
                                break;
                            case 3:
                              //  BuscarPersonaPorNombre();

                                break;
                        }
                                break;
                            
                        
                                
                    case 2:
                        Console.WriteLine("1 - Mostrar todas las mascotas registradas\r\n2 - Registrar mascota nueva\r\n3 - Buscar mascotas por especie\r\n4 - Buscar mascotas por nombre\r\n5 - Examinar mascota\r\n6 - Volver al menú anterior");
                        break;

                                                   
                        int opc4 = int.Parse(Console.ReadLine());
                        switch (opc4)
                        {
                            case 1:
                                Console.WriteLine("1 - Ver mascotas disponibles para adoptar\r\n2 - Adoptar mascota\r\n3 - Regresar al menú anterior");
                                break;
                        }
                           
        

                    case 3:
                        Console.WriteLine("1 - Ver mascotas disponibles para adoptar\r\n2 - Adoptar mascota\r\n3 - Regresar al menú anterior");
                        break;



                
                        }
                break;
            case 2:
                Console.WriteLine();
                break; 
            case 3:
                Console.WriteLine();
                break;
            case 4:
                Console.WriteLine();
                break;
            case 5:
                Console.WriteLine();
                break;
        }
    }

    public interface IMascota
    {
        void HacerRuido();
    }
    public interface IAcariciable
    {
        void ResponderACaricia();
    }

    public class Mascota : IMascota
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


        public class Perro : Mascota, IAcariciable
        {
            public Perro(string nombre, int edad, TemperamentoEnum temperamento, string dueño)
                : base(nombre, edad, temperamento, dueño, EspecieMascotaEnum.Perro, 14)
            {
            }

            public void MoverCola()
            {
                Console.WriteLine("Moviendo cola");
            }

            public void HacerRuido()
            {
                Console.WriteLine("¡Guau! ¡Guau! ");
            }

            public void ResponderACaricia()
            {
                MoverCola();
            }
        }

        public class Gato : Mascota, IAcariciable
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

            public void ResponderACaricia()
            {
                if (Temperamento == TemperamentoEnum.Amable.ToString())
                {
                    Ronronear();
                }
                else if (Temperamento == TemperamentoEnum.Nervioso.ToString())
                {
                    Ronronear();
                }
                else if (Temperamento == TemperamentoEnum.Agresivo.ToString())
                {
                    Rasguñar();
                }
            }
        }

        public class Capibara : Mascota
        {
            public Capibara(string nombre, int edad, string dueño)
                : base(nombre, edad, TemperamentoEnum.Amable, dueño, EspecieMascotaEnum.Capibara, 11)
            {
            }

            public void HacerRuido()
            {
                Console.WriteLine("¡Cui! ¡Cui! ");
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

        void IMascota.HacerRuido()
        {
            throw new NotImplementedException();
        }
    }





    public class Persona
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
                    throw new Exception("El nombre de una Persona no puede estar en blanco.");
                }

                _nombre = value;
            }
        }


        private List<IMascota> mascotas;

        public Persona(string nombre)
        {
            Id = lastIdAdded + 1;
            lastIdAdded++;
            Nombre = nombre;
            mascotas = new List<IMascota>();
        }

        public List<IMascota> ObtenerMascotas()
        {
            return mascotas;
        }

        public IMascota ObtenerMascotaPorId(int id)
        {
            return mascotas.Find(m => m is Mascota && ((Mascota)m).Id == id);
        }

        public void AgregarMascota(IMascota nuevaMascota, string nombreDueño)
        {
            mascotas.Add(nuevaMascota);
            Console.WriteLine($"{nombreDueño} agrega a {((Mascota)nuevaMascota).Nombre} a sus mascotas.");
            nuevaMascota.HacerRuido();
        }

        public void AcariciarMascota(IAcariciable mascota, string nombreDueño)
        {
            Console.Write($"{nombreDueño} acaricia a {((Mascota)mascota).Nombre}. ");
            mascota.ResponderACaricia();
        }

        public void AcariciarMascotas(string nombreDueño)
        {
            foreach (var mascota in mascotas)
            {
                if (mascota is IAcariciable)
                {
                    AcariciarMascota((IAcariciable)mascota, nombreDueño);
                }
                else
                {
                    Console.WriteLine($"{nombreDueño} intenta acariciar a una mascota, pero no es posible.");
                }
            }
        }
    }





    // Funciones Menu- administracion de personas
    class FuncioneMenu
    {
        private static void MostrarPersonas(List<Persona> personas)
        {
            Console.WriteLine("Personas registradas en el centro:");
            foreach (var persona in personas)
            {
                Console.WriteLine($"Id: {persona.Id}, Nombre: {persona.Nombre}");
            }
        }

        private static void RegistrarPersona(List<Persona> personas)
        {
            Console.Write("Ingrese el nombre de la nueva persona: ");
            string nombre = Console.ReadLine();

            try
            {
                Persona nuevaPersona = new Persona(nombre);
                personas.Add(nuevaPersona);
                Console.WriteLine($"Persona registrada exitosamente. Id: {nuevaPersona.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar persona: {ex.Message}");
            }
        }

        private static void BuscarPersonaPorNombre(List<Persona> personas)
        {
            Console.Write("Ingrese el nombre a buscar: ");
            string nombreBusqueda = Console.ReadLine();

            Console.WriteLine($"Personas cuyo nombre contiene '{nombreBusqueda}':");
            foreach (var persona in personas)
            {
                if (persona.Nombre.Contains(nombreBusqueda, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Id: {persona.Id}, Nombre: {persona.Nombre}");
                }
            }
        }

    }




}




















