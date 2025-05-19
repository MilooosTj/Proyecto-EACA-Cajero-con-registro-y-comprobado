using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Proyecto_EACA_Cajero_con_registro_y_comprobado
{
    internal class Program
    {
        //Proyecto EACA Cajero con registro y comprobado                ime112768

        public enum Menu
        {
            Consultarcuenta = 1,
            depositar,
            retirar,
            revisarhistorialIngresos,
            revisarhistorialRetiros,
            salir
        }
        static Dictionary<DateTime, Double> revisarhistorialIngresos = new Dictionary<DateTime, Double>();
        static Dictionary<DateTime, Double> revisarhistorialRetiros = new Dictionary<DateTime, Double>();
        static Double saldo = 0.0;


        static void Main(string[] args)
        {
            int intentos = 3;

            do
            {
                if (login())
                {
                    Console.WriteLine("Bienvenido");
                    bool bandera = true;
                    while (bandera)
                    {
                        switch (menu())
                        {
                            case 1:
                                Console.WriteLine("Asistente");
                                asistente();
                                bandera = false;
                                break;
                            case 2:
                                Console.WriteLine("Programador");
                                programador();
                                bandera = false;
                                break;
                            case 3:
                                Console.WriteLine("Contralor");
                                contralor();
                                bandera = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    intentos--;
                    Console.WriteLine($"Te quedan {intentos} intentos");
                }

            } while (intentos >= 1);
            Environment.Exit(0);

        }

        static Menu Men()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("1) Consultar saldo actual");
            Console.WriteLine("2) Depositar dinero");
            Console.WriteLine("3) Retirar dinero");
            Console.WriteLine("4) Revisar historial de depósitos");
            Console.WriteLine("5) Revisar historial de retiros");
            Console.WriteLine("6) Salir");
            Console.WriteLine("------------------------------");
            Menu opc = (Menu)Convert.ToInt32(Console.ReadLine());
            return opc;
        }
        static bool login()
        {
            Console.WriteLine("Ingresa tu usurario");
            string user = Convert.ToString(Console.ReadLine());
            Console.WriteLine("contraseña");
            double contraseña = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cúal es tu edad?");
            double edad = Convert.ToDouble(Console.ReadLine());

            if (user == "Emilio" && contraseña == "123" && edad >= 18)
            {
                Console.WriteLine("Bienvenido cumples");
            }
            else
            {
                Console.WriteLine("No puedes entrar");
            }
            Console.ReadKey();
        }

    }
}
