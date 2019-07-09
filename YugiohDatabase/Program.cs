using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace YugiohDatabase {
    class Program {
        static void Main(string[] args) {
            char op = '1';
            List<Cards> cartas = new List<Cards>();
            Menu menu = new Menu();
            Console.Title = "Yu-Gi-Oh! Database";

            do {
                Console.WriteLine("Yu-Gi-Oh! Database");
                Console.WriteLine("Opções:");
                Console.WriteLine("1 - Adicionar Carta");
                Console.WriteLine("2 - Consultar Carta");
                Console.WriteLine("3 - Editar Carta");
                Console.WriteLine("4 - Remover Carta");
                Console.WriteLine("5 - Ordenar Lista");
                Console.WriteLine("0 - Sair");

                try {
                    op = Convert.ToChar(Console.ReadLine());
                    
                    switch (op) {
                        case '1': menu.MenuAddCarta(cartas); break;
                        case '2': menu.MenuConsultaCarta(cartas); break;
                        case '3': menu.MenuEditaCarta(cartas); break;
                        case '4': menu.MenuRemoveCarta(cartas); break;
                        case '5': menu.MenuOrdena(cartas); break;
                        case '0': break;
                        default: throw new FormatException("Insira uma opção válida!"); 
                    }
                } catch (FormatException e){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.Clear();
                }
            } while (op != '0');
        }
        public void Initializate() {

        }

    }
}
