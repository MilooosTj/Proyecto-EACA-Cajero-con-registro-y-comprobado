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

            while (true)
            {

            }
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


    }
}
