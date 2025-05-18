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
        
        Public enum Menu
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

        }
    }
}
