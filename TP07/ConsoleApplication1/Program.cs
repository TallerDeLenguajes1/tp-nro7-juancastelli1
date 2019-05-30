using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static string[] estado = new string[]{ "casado", "soltero" };
        public enum Cargo {Auxiliar, Administrativo, Ingeniero, Especialista, Investigador };
        public static string[] genero = new string[]{ "masculino", "femenino" };
        public static string[] nombre = new string[] { "Juan", "Nacho", "Roberto", "Eustaquio", "Luna", "Angel", "Martin", "Javier" };
        public static string[] apellido = new string[] { "Naval", "Castelli", "Villafañe", "Perdigon", "Perez", "Arcucci", "Lauriano", "Paz" };
        public struct DatosEmpleado
        {
            public string nombre;
            public string apellido;
            public DateTime fechanac;
            public string estadocivil;
            public string genero;
            public DateTime fechaingreso;
            public Cargo cargo;
            public DatosEmpleado(string _nombre, string _apellido, DateTime _fechanac, string _estadocivil, string _genero, DateTime _fechaingreso, Cargo _cargo){
                this.nombre = _nombre;
                this.apellido = _apellido;
                this.fechanac = _fechanac;
                this.estadocivil = _estadocivil;
                this.genero = _genero;
                this.fechaingreso = _fechaingreso;
                this.cargo = _cargo;
            }
            public void MostrarEmpleado()
            {
                Console.Write("\n{0}",this.nombre);
                Console.Write("\n{0}", this.apellido);
                Console.Write("\n{0}", this.fechanac.Date.ToShortDateString());
                Console.Write("\n{0}", this.estadocivil);
                Console.Write("\n{0}", this.genero);
                Console.Write("\n{0}", this.fechaingreso.Date.ToShortDateString());
                Console.Write("\n{0}", this.cargo);
                Console.Write("\nLa antiguedad del empleado es de {0} años", Antiguedad());
                Console.Write("\nLa Edad del empleado es de {0} años", Edad());
                Console.Write("\nPara jubilarse le faltan {0} años", Jubila());
                Console.Write("\nSalario: ${0}", Salario());
            }
            public double Salario()
            {
                double Adicional, basico = 15000,Sueldo;
                Random gen = new Random();
                int hijos = gen.Next(0, 11);
                if (Antiguedad() < 25)
                {
                    Adicional = basico * (0.2 * Antiguedad());
                }else
                {
                    Adicional = basico * 0.25;
                }
                if((cargo == (Cargo)2) || (cargo == (Cargo)3)){
                    Adicional = Adicional * 1.50;
                }
                if(estadocivil == "casado")
                {
                    if (hijos > 2)
                    {
                        Adicional = Adicional + 5000;
                    }
                }
                Sueldo = basico + Adicional;
                return Sueldo;
            }
            public int Antiguedad()
            {
                int Antig;
                Antig = (DateTime.Today - fechaingreso).Days / 365;
                return Antig;
            }
            public int Edad()
            {
                int Antig;
                Antig = (DateTime.Today - fechanac).Days / 365;
                return Antig;
            }
            public int Jubila()
            {
                int Antig;

                if(genero == "masculino"){
                    Antig = 65 - Edad();
                }
                else
                {
                    Antig = 60 - Edad();
                }
                return Antig;
            }
        }
       
        static DateTime RandomBirthDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1963, 1, 1);
            DateTime EndDay = new DateTime(1970, 1, 1);
            int rango = (EndDay - start).Days;
            return start.AddDays(gen.Next(rango));
        }
        static DateTime RandomIngressDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1990, 1, 1);
            int rango = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(rango));
        }

         static void Main(string[] args)
        {
            List<DatosEmpleado> empleados = new List<DatosEmpleado>();
            Random gen = new Random();
            DateTime Fechanac = new DateTime();
            Fechanac = RandomBirthDay();
            DateTime Fechaing = new DateTime();
            Fechaing = RandomIngressDay();
            DatosEmpleado Nuevo = new DatosEmpleado();
            for(int k = 0; k < 20; k++)
            {
                Nuevo = new DatosEmpleado(nombre[gen.Next() % 8], apellido[gen.Next() % 8], Fechanac, estado[gen.Next() % 2], genero[gen.Next() % 2], Fechaing, (Cargo)gen.Next(0, 4));
                empleados.Add(Nuevo);
            }
            double SueldoTot = 0;
            int i = 0;
            foreach (DatosEmpleado emple in empleados){
                Console.Write("\n\nEmpleado {0}", i+1);
                emple.MostrarEmpleado();
                SueldoTot = SueldoTot + emple.Salario();
                i++;
            }
            Console.Write("\n\n\nCantidad de empleados en la empresa{0}", i);
            Console.Write("\n\n\nMonto de Sueldos Total: ${0}", SueldoTot);
            Console.Write("\n\nDe que empleado desea ver los datos?:");
            i = int.Parse(Console.ReadLine());
            empleados[i-1].MostrarEmpleado();
            Console.ReadKey();

        }
        
    }
}
