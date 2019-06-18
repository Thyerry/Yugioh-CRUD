using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohDatabase {
    class Menu {
        public List<Cards> MenuAddCarta(List<Cards> cartas) {
            char op;
            Console.Clear();
            Console.WriteLine("ADICIONAR NOVA CARTA");
            Console.WriteLine("Categoria:");
            Console.WriteLine("1 - Monstro");
            Console.WriteLine("2 - Magia");
            Console.WriteLine("3 - Armadilha");

            op = Convert.ToChar(Console.ReadLine());

            switch (op) {
                case '1': MenuAddMonstro(cartas); break;
                case '2': MenuAddSpell(cartas); break;
                case '3': MenuAddTrap(cartas); break;
                default: {
                    Console.WriteLine("Opção Invália");
                    break;
                }
            }

            return cartas;
        }

        public List<Cards> MenuConsultaCarta(List<Cards> cartas) {
            Console.Clear();
            Console.WriteLine("CONSULTAR CARTA");
            Console.Write("Nome: ");
            string pesquisa = Console.ReadLine();
            int indice = 0;

            for (int i = 0; i < cartas.Count(); i++) {
                if (cartas.ElementAt(i) != null && cartas.ElementAt(i).Nome == pesquisa) {
                    indice = i;
                    i = cartas.Count;
                }
                else {
                    indice = -1;
                }

            }

            if (indice == -1) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Essa carta ainda não foi adicionada a base de dados!");
                Console.ResetColor();
            }

            else {
                Console.Clear();
                Console.WriteLine("CONSULTAR CARTA");
                Console.WriteLine(cartas.ElementAt(indice).ToString());
                Console.ReadKey();
                Console.Clear();
            }
            return cartas;
        }

        public List<Cards> MenuEditaCarta(List<Cards> cartas) {
            Console.Clear();
            Console.WriteLine("EDITAR CARTA");
            Console.Write("Nome: ");
            string pesquisa = Console.ReadLine();

            Cards edit = cartas.Find(x => x.Nome == pesquisa);

            if (edit.Nome != "") {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Essa carta ainda não foi adicionada a base de dados!");
                Console.ResetColor();
            }
            else {
                if (edit.GetType().Equals(new MonsterCard().GetType())) {
                    Console.WriteLine("Insira as Novas Informações");
                    Console.Write("Nome: ");
                    string novoNome = Console.ReadLine();
                    Console.Write("Ataque: ");
                    int novoAtk = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Defesa: ");
                    int novoDef = Convert.ToInt32(Console.ReadLine());

                    MonsterCard monstro = new MonsterCard(novoNome, novoAtk, novoDef);
                    cartas.Remove(edit);
                    cartas.Add(monstro);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Dados do Monstro Foram Atualizados!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (edit.GetType().Equals(new SpellCard().GetType())) {
                    Console.WriteLine("Insira as Novas Informações");
                    Console.Write("Nome: ");
                    string novoNome = Console.ReadLine();

                    Console.WriteLine("Categoria:");
                    Console.WriteLine("1 - Normal");
                    Console.WriteLine("2 - Contínua");
                    Console.WriteLine("3 - Jogo Rápido");
                    Console.WriteLine("4 - Equipamento");
                    Console.WriteLine("5 - Campo");
                    Console.WriteLine("6 - Ritual");

                    SpellCategory novaCategoria = (SpellCategory)Convert.ToInt32(Console.ReadLine());

                    Console.Write("Efeito: ");
                    string novoEfeito = Console.ReadLine();

                    SpellCard spell = new SpellCard(novoNome, novoEfeito, novaCategoria);
                    cartas.Remove(edit);
                    cartas.Add(spell);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Dados da Magia Foram Atualizados!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();

                }
                else {
                    Console.WriteLine("Insira as Novas Informações");
                    Console.Write("Nome: ");
                    string novoNome = Console.ReadLine();

                    Console.WriteLine("Escolha a Categoria da Carta Armadilha:");
                    Console.WriteLine("1 - Normal");
                    Console.WriteLine("2 - Contínua");
                    Console.WriteLine("3 - Resposta");

                    TrapCategory categoria = (TrapCategory)Convert.ToInt32(Console.ReadLine());

                    Console.Write("Efeito: ");
                    string novoEfeito = Console.ReadLine();

                    TrapCard trap = new TrapCard(novoNome, novoEfeito, categoria);
                    cartas.Remove(edit);
                    cartas.Add(trap);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Dados da Foram Atualizados!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }

            }

            return cartas;
        }

        public List<Cards> MenuRemoveCarta(List<Cards> cartas) {
            Console.Clear();
            Console.WriteLine("REMOVER CARTA");
            Console.Write("Nome: ");
            string pesquisa = Console.ReadLine();
            
            Cards remove = cartas.Find(card => card.Nome == pesquisa);

            if (remove.Nome != pesquisa) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Essa carta ainda não foi adicionada a base de dados!");
                Console.ResetColor();
            }
            else {
                cartas.Remove(remove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A carta foi excluída do Banco de Dados");
                Console.ResetColor();
            }


            return cartas;
        }

        public List<Cards> MenuAddMonstro(List<Cards> cartas) {
            string nome;
            int atk, def;
            Console.Write("Nome: ");
            nome = Console.ReadLine();

            Console.Write("Qual o valor de ataque: ");
            atk = Convert.ToInt32(Console.ReadLine());

            Console.Write("Qual o valor de defesa: ");
            def = Convert.ToInt32(Console.ReadLine());


            MonsterCard monster = new MonsterCard(nome, atk, def);
            cartas.Add(monster);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Monstro Adicionado com Sucesso!");
            Console.ResetColor();
            Console.ReadKey();

            Console.Clear();
            return cartas;
        }

        public List<Cards> MenuAddSpell(List<Cards> cartas) {
            string nome, efeito;

            Console.Write("Nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Escolha a Categoria da Carta Mágica:");
            Console.WriteLine("1 - Normal");
            Console.WriteLine("2 - Contínua");
            Console.WriteLine("3 - Jogo Rápido");
            Console.WriteLine("4 - Equipamento");
            Console.WriteLine("5 - Campo");
            Console.WriteLine("6 - Ritual");

            SpellCategory categoria = (SpellCategory)Convert.ToInt32(Console.ReadLine());

            Console.Write("Efeito: ");
            efeito = Console.ReadLine();

            SpellCard spell = new SpellCard(nome, efeito, categoria);
            cartas.Add(spell);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Magia Adicionada com Sucesso!");
            Console.ResetColor();
            Console.ReadKey();

            Console.Clear();
            return cartas;
        }

        public List<Cards> MenuAddTrap(List<Cards> cartas) {
            string nome, efeito;
            Console.Write("Nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Escolha a Categoria da Carta Armadilha:");
            Console.WriteLine("1 - Normal");
            Console.WriteLine("2 - Contínua");
            Console.WriteLine("3 - Resposta");

            TrapCategory categoria = (TrapCategory)Convert.ToInt32(Console.ReadLine());

            Console.Write("Efeito: ");
            efeito = Console.ReadLine();

            TrapCard trap = new TrapCard(nome, efeito, categoria);
            cartas.Add(trap);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Armadilha Adicionada com Sucesso!");
            Console.ResetColor();
            Console.ReadKey();

            Console.Clear();
            return cartas;
        }
    }
}
