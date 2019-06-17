﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohDatabase {
    class Program {
        static void Main(string[] args) {
            char op;
            List<Cards> cartas = new List<Cards>();
            Menu menu = new Menu();


            do {
                Console.WriteLine("Yu-Gi-Oh! Database");
                Console.WriteLine("Opções:");
                Console.WriteLine("1 - Adicionar Carta");
                Console.WriteLine("2 - Consultar Carta");
                Console.WriteLine("3 - Editar Carta");
                Console.WriteLine("4 - Remover Carta");
                Console.WriteLine("0 - Sair");


                op = Convert.ToChar(Console.ReadLine());
                switch (op) {
                    case '1': menu.MenuAddCarta(cartas); break;
                    case '2': menu.MenuConsultaCarta(cartas); break;
                    case '3': menu.MenuEditaCarta(cartas); break;
                    case '4': menu.MenuRemoveCarta(cartas); break;

                    default: {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("INSIRA UMA OPÇÃO VÁLIDA\n");
                        Console.ResetColor();
                        break;
                    }
                }
            } while (op != '0');
        }

        public void initializate() {

        }

    }
}
