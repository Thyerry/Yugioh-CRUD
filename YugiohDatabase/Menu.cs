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

            switch(op){
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
                }
                else {
                    indice = i + 1;
                }
            }

            if (indice > cartas.Count()) {
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

            Cards search = cartas.Find(x => x.Nome == pesquisa);

            if (search == null) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Essa carta ainda não foi adicionada a base de dados!");
                Console.ResetColor();
            }
            else {
                if (/*Se for monstro segue aqui */ true) {
                    Console.WriteLine("Insira as Novas Informações");
                    Console.Write("Nome: ");
                    string novoNome = Console.ReadLine();
                    Console.Write("Ataque: ");
                    int novoAtk = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Defesa: ");
                    int novoDef = Convert.ToInt32(Console.ReadLine());

                    MonsterCard monster = (MonsterCard)search;

                    monster.Nome = novoNome;
                    monster.AtkValue = novoAtk;
                    monster.DefValue = novoDef;
                    cartas.Remove(search);
                    cartas.Add(monster);

                }
                else if (/*Se for Spell ou Trap */ true) {
                    Console.WriteLine("Insira as Novas Informações");
                    Console.Write("Nome: ");
                    string novoNome = Console.ReadLine();
                    Console.Write("Efeito: ");
                    string novoEfeito = Console.ReadLine();

                    SpellCard sp = (SpellCard)search;
                    sp.Nome = novoNome;
                    sp.Effect = novoEfeito;
                    cartas.Remove(search);
                    cartas.Add(sp);

                }

            }

            return cartas;
        }

        public List<Cards> MenuRemoveCarta(List<Cards> cartas) {
            Console.Clear();
            Console.WriteLine("REMOVER CARTA");
            Console.Write("Nome: ");
            string pesquisa = Console.ReadLine();

            Cards search = cartas.Find(x => x.Nome == pesquisa);

            if (search.Nome == "") {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Essa carta ainda não foi adicionada a base de dados!");
                Console.ResetColor();
            }
            else {
                cartas.Remove(search);
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
            Console.WriteLine("Monstro Adicionada com Sucesso!");
            Console.ReadKey();

            Console.Clear();
            return cartas;
        }

        public List<Cards> MenuAddSpell(List<Cards> cartas) {
            string nome, efeito;

            Console.Write("Nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Escolha a Categoria da Carta Armadilha:");
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
            Console.WriteLine("Armadilha Adicionada com Sucesso!");
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
            Console.WriteLine("Magia Adicionada com Sucesso!");
            Console.ResetColor();
            Console.ReadKey();

            Console.Clear();
            return cartas;
        }
    }
}
