using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Proyecto_EACA_Cajero_con_registro_y_comprobado
{
    internal class Program
    {
        // Proyecto EACA Cajero con registro y comprobado                               IME112768  

        public enum Menu
        {
            Consultarcuenta = 1, depositar, retirar, revisarhistorialIngresos, revisarhistorialRetiros, salir
        }
        static Dictionary<DateTime, Double> revisarhistorialIngresos = new Dictionary<DateTime, Double>();
        static Dictionary<DateTime, Double> revisarhistorialRetiros = new Dictionary<DateTime, Double>();
        static Double saldo = 0.0;

        //checar static

        static void Main(string[] args)
        {
            int intentos = 3;

            do
            {
                if (loggin())
                {
                    while (true)
                    {
                        switch (Men())
                        {

                            case Menu.Consultarcuenta:
                                ConsultarSaldoActual();
                                break;
                            case Menu.depositar:
                                Depositar();
                                break;
                            case Menu.retirar:
                                Retirar();
                                break;
                            case Menu.revisarhistorialIngresos:
                                RevisarHistorialIngresos();
                                break;
                            case Menu.revisarhistorialRetiros:
                                RevisarHistorialRetiros();
                                break;
                            case Menu.salir:
                                Console.WriteLine("¡Hasta luego!");
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Opción no válida.");
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

        static bool loggin()
        {
            Console.WriteLine("Ingresa tu usuario");
            string user = Console.ReadLine();
            Console.WriteLine("Contraseña");
            string contraseña = Console.ReadLine();
            Console.WriteLine("¿Cuál es tu fecha de nacimiento?");
            DateTime fecha = Convert.ToDateTime(Console.ReadLine());
            DateTime fechaActual = DateTime.Now;
            int anios = fechaActual.Year - fecha.Year;

            if (user == "Emilio" && contraseña == "123" && anios >= 18)
            {
                Console.WriteLine("Bienvenido al cajero del BIENESTAR");
                return true;
            }
            else
            {
                Console.WriteLine("No puedes entrar");
                return false;
            }
        }

        static void ConsultarSaldoActual()
        {
            Console.WriteLine($"Tu saldo actual es: {saldo}");
        }

        static void Depositar()
        {
            Console.WriteLine("¿Cuánto deseas depositar?");
            double cantidad = Convert.ToDouble(Console.ReadLine());
            saldo += cantidad;
            revisarhistorialIngresos[DateTime.Now] = cantidad;
            Console.WriteLine($"Has depositado {cantidad}. Tu nuevo saldo es {saldo}.");
        }

        static void Retirar()
        {
            Console.WriteLine("¿Cuánto deseas retirar?");
            double cantidad = Convert.ToDouble(Console.ReadLine());
            if (cantidad <= saldo)
            {
                saldo -= cantidad;
                revisarhistorialRetiros[DateTime.Now] = cantidad;
                Console.WriteLine($"Has retirado {cantidad}. Tu nuevo saldo es {saldo}.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
            }
        }

        static void RevisarHistorialIngresos()
        {
            Console.WriteLine("Historial de ingresos:");
            foreach (var ingreso in revisarhistorialIngresos)
            {
                Console.WriteLine($"{ingreso.Key}: {ingreso.Value}");
            }

            Console.WriteLine("Deseas enviar el historial de ingresos a tu correo?");
            Console.WriteLine("1)Si");
            Console.WriteLine("2)No");
            int opc = Convert.ToInt32(Console.ReadLine());

            if (opc == 1)
            {
                CorreoINGRESOS(revisarhistorialIngresos);

                Console.WriteLine("Correo enviado con éxito");
            }
            else if (opc == 2)
                Console.WriteLine("No se enviará el correo, Muchas gracias!.");

        }
        static void RevisarHistorialRetiros()
        {
            Console.WriteLine("Historial de retiros:");
            foreach (var retiro in revisarhistorialRetiros)
            {
                Console.WriteLine($"{retiro.Key}: {retiro.Value}");
            }

            Console.WriteLine("Deseas enviar el historial de Retiros a tu correo?");
            Console.WriteLine("1)Si");
            Console.WriteLine("2)No");
            int opc = Convert.ToInt32(Console.ReadLine());

            if (opc == 1)
            {
                CorreoRETIROS(revisarhistorialRetiros);

                Console.WriteLine("Correo enviado con éxito");
            }
            else if (opc == 2)
                Console.WriteLine("No se enviará el correo, Muchas gracias!.");
        }

        static bool CorreoINGRESOS(Dictionary<DateTime, double> Ingresos)
        {
            string servidorSmtp = "smtp.office365.com";
            int puerto = 587;
            string usuario = "112768@alumnouninter.mx";
            string contrasena = "FamiliaC0rtes";


            SmtpClient smtp = new SmtpClient(servidorSmtp)
            {
                Port = puerto,
                Credentials = new NetworkCredential(usuario, contrasena),
                EnableSsl = true
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress(usuario),
                Subject = "Historial de Ingresos en tu cuenta",
                IsBodyHtml = false
            };

            string cuerpoMensaje = "Ingresos de tu cuenta:\n\n";
            foreach (var tarea in Ingresos)
            {
                cuerpoMensaje += $"{tarea.Key}. {tarea.Value}\n";
            }
            mail.Body = cuerpoMensaje;

            mail.To.Add("112768@alumnouninter.mx");

            smtp.Send(mail);
            return true;
        }

        static bool CorreoRETIROS(Dictionary<DateTime, double> Retiros)
        {
            string servidorSmtp = "smtp.office365.com";
            int puerto = 587;
            string usuario = "112768@alumnouninter.mx";
            string contrasena = "FamiliaC0rtes";


            SmtpClient smtp = new SmtpClient(servidorSmtp)
            {
                Port = puerto,
                Credentials = new NetworkCredential(usuario, contrasena),
                EnableSsl = true
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress(usuario),
                Subject = "Historial de Retiros en tu cuenta",
                IsBodyHtml = false
            };


            string cuerpoMensaje = "Retiros de tu cuenta:\n\n";
            foreach (var tarea in Retiros)
            {
                cuerpoMensaje += $"{tarea.Key}. {tarea.Value}\n";
            }
            mail.Body = cuerpoMensaje;

            mail.To.Add("112768@alumnouninter.mx");


            smtp.Send(mail);
            return true;
        }


    }
}
