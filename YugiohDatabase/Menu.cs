using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YugiohDatabase.Enum;

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
            Console.WriteLine("0 - Voltar");

            op = Console.ReadLine()[0];

            switch (op) {
                case '1': {
                    MenuAddMonstro(cartas); 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Monstro Adicionado com Sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                case '2': {
                    MenuAddSpell(cartas);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Magia Adicionada com Sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                case '3': {
                    MenuAddTrap(cartas);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Armadilha Adicionada com Sucesso!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                case '0': Console.Clear(); break;
                default: {
                    Console.WriteLine("Opção Invália");
                    Console.ReadKey();
                    Console.Clear();
                    MenuAddCarta(cartas);
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

            List<Cards> consult = cartas.FindAll(carta => carta.Nome.Contains(pesquisa));

            if (consult.Count() == 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não existe nenhuma carta com esse nome na base de dados!");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }

            else {
                Console.Clear();
                Console.WriteLine("RESULTADO");
                Console.WriteLine("");
                foreach (Cards card in consult) {
                    Console.WriteLine(card.ToString());
                    Console.WriteLine();
                }
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

            Cards edit = cartas.Find(carta => carta.Nome == pesquisa);

            if (edit == null) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Essa carta ainda não foi adicionada a base de dados!");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            else {
                if (edit.GetType().Equals(new MonsterCard().GetType())) {
                    Console.WriteLine("Insira as novas Informações");
                    MenuAddMonstro(cartas);
                    cartas.Remove(edit);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Dados do Monstro Foram Atualizados!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (edit.GetType().Equals(new SpellCard().GetType())) {
                    Console.WriteLine("Insira as Novas Informações");
                    MenuAddSpell(cartas);
                    cartas.Remove(edit);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Dados da Magia Foram Atualizados!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();

                }
                else {
                    Console.WriteLine("Insira as Novas Informações");
                    MenuAddTrap(cartas);
                    cartas.Remove(edit);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Dados da Armadilha Foram Atualizados!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            return cartas;
        }

        public List<Cards> MenuRemoveCarta(List<Cards> cartas) {
            try {
                Console.Clear();
                Console.WriteLine("REMOVER CARTA");
                Console.Write("Nome: ");
                string pesquisa = Console.ReadLine();

                Cards remove = cartas.Find(card => card.Nome == pesquisa);

                if (remove == null) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Essa carta ainda não foi adicionada a base de dados!");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }
                else {
                    Console.Write("Você tem certeza que quer excluir {0}? (y/n): ",remove.Nome);
                    char confirm = Convert.ToChar(Console.ReadLine());
                    if(confirm == 'y' || confirm == 'Y'){
                        cartas.Remove(remove);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("A carta foi excluída do Banco de Dados");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Remoção Cancelada!");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    
                }
            }
            catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insira Um nome válido");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }

            return cartas;
        }

        private List<Cards> MenuAddMonstro(List<Cards> cartas) {
            try {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Ataque: ");
                int atk = Convert.ToInt32(Console.ReadLine());

                Console.Write("Defesa: ");
                int def = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(MostraTipos());
                MonsterType tipo = (MonsterType)Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Atributo: ");
                Console.WriteLine("1 - Luz");
                Console.WriteLine("2 - Trevas");
                Console.WriteLine("3 - Água");
                Console.WriteLine("4 - Terra");
                Console.WriteLine("5 - Fogo");
                Console.WriteLine("6 - Vento");
                Console.WriteLine("7 - Divino");
                MonsterAttribute atributo = (MonsterAttribute)Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Level (1-12): ");
                int lvl = Convert.ToInt32(Console.ReadLine());
                if (lvl < 1 || lvl > 12) {
                    throw new FormatException();
                }

                MonsterCard monster = new MonsterCard(nome, atk, def, lvl, tipo, atributo);
                cartas.Add(monster);
            }
            catch (FormatException e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O valor atribuído é inválido!");
                Console.ReadKey();
                Console.ResetColor();
                MenuAddMonstro(cartas);
            }

            return cartas;
        }

        private List<Cards> MenuAddSpell(List<Cards> cartas) {

            try {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Escolha a Categoria da Carta Mágica:");
                Console.WriteLine("1 - Normal");
                Console.WriteLine("2 - Contínua");
                Console.WriteLine("3 - Jogo Rápido");
                Console.WriteLine("4 - Equipamento");
                Console.WriteLine("5 - Campo");
                Console.WriteLine("6 - Ritual");
                int cat = Convert.ToInt32(Console.ReadLine());
                
                if (cat > 6 || cat < 1) {
                    throw new FormatException();
                }
                
                SpellCategory categoria = (SpellCategory)cat;
                
                Console.Write("Efeito: ");
                string efeito = Console.ReadLine();

                SpellCard spell = new SpellCard(nome, efeito, categoria);
                cartas.Add(spell);
            }
            catch (FormatException e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O valor atribuído é inválido!");
                Console.ReadKey();
                Console.ResetColor();
                Console.Clear();
                MenuAddSpell(cartas);
            }
            return cartas;
        }

        private List<Cards> MenuAddTrap(List<Cards> cartas) {
            try {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Escolha a Categoria da Carta Armadilha:");
                Console.WriteLine("1 - Normal");
                Console.WriteLine("2 - Contínua");
                Console.WriteLine("3 - Resposta");

                TrapCategory categoria = (TrapCategory)Convert.ToInt32(Console.ReadLine());

                Console.Write("Efeito: ");
                string efeito = Console.ReadLine();

                TrapCard trap = new TrapCard(nome, efeito, categoria);
                cartas.Add(trap);
            }
            catch (FormatException e) {

            }
            return cartas;
        }

        private string MostraTipos() {

            string l01 = String.Format("01 - Aqua            |02 - Besta            |03 - Besta Guerreira |04 - Criador         |05 - Cyberse        ");
            string l02 = String.Format("06 - Dinossauro      |07 - Besta Divina     |08 - Dragão          |09 - Fada            |10 - Demonio        ");
            string l03 = String.Format("11 - Peixe           |12 - Inseto           |13 - Máquina         |14 - Planta          |15 - Psíquico       ");
            string l04 = String.Format("16 - Pyro            |17 - Réptil           |18 - Pedra           |19 - Serpente Marinha|20 - Trovão         ");
            string l05 = String.Format("21 - Mago            |22 - Guerreiro        |23 - Besta Alada     |24 - Wyrm            |25 - Zumbi          ");

            return String.Format("Tipo: \n{0}\n{1}\n{2}\n{3}\n{4}", l01, l02, l03, l04, l05);
        }
    }
}
