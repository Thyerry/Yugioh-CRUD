using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohDatabase {
    class SpellCard : Cards {
        private string _effect { get; set; }
        private SpellCategory _category { get; set; }

        public string Effect {
            get { return this._effect; }
            set { this._effect = value; }
        }

        public SpellCategory Category {
            get { return _category; }
            set { this._category = value; }
        }
        public SpellCard() { }
        public SpellCard(string nome, string effect, SpellCategory category) : base(nome) {
            this._effect = effect;
            this._category = category;
        }

        public override string ToString() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Mágica:");
            Console.ResetColor();
            Console.WriteLine("Nome: {0}", this.Nome);
            Console.WriteLine("Categoria: {0}", this.Category);
            Console.WriteLine("Efeito: {0}", this.Effect);
            return null;/*String.Format("Mágica: \nNome: {0}\nCategoria: {1}\nEfeito: {2}", this.Nome, this.Category, this.Effect) */;
        }
    }
}
