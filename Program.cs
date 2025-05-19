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
        //Proyecto EACA Cajero con registro y comprobado                         ime112768

        public enum Menu
        {
            Consultarcuenta = 1, depositar, retirar, revisarhistorialIngresos, revisarhistorialRetiros,salir
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
                    while (true)
                    {
                        switch (opc)
                        {
                            case 1:
                                Consultarsaldoactual();
                                break;
                            case 2:
                                Mostrar();
                                break;
                            case Menu.Eliminar:
                                Eliminar();
                                break;
                            case Menu.Actualizar:
                                Actualizar();
                                break;
                            case Menu.Contar:
                                Console.WriteLine($"El numero de elementos es: {Contar()}");
                                break;
                            case Menu.Enviarcorreo:
                                Enviarcorreo();
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
           int opc = Convert.ToInt32(Console.ReadLine());
            return opc;
        }
        static bool login()
        {
            Console.WriteLine("Ingresa tu usurario");
            string user = Convert.ToString(Console.ReadLine());
            Console.WriteLine("contraseña");
            int contraseña = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cúal es tu edad?");
            int edad = Convert.ToInt32(Console.ReadLine());

            if (user == "Emilio" && contraseña == "123" && edad >= 18)
            {
                Console.WriteLine("Bienvenido al bieneestar");
                return true;
            }
            else
            {
                Console.WriteLine("No puedes entrar");
                return false;
            }
            Console.ReadKey();

            static double Consultarsaldoactual()
            {
                Console.WriteLine($"Tu saldo actual es: {saldo}");
                return true;
            }

        }

    }
}
