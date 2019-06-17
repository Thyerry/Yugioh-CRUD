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
            get {
                return this._effect;
            }
            set {
                this._effect = value;
            }
        }

        public SpellCategory Category {
            get {
                return _category;
            }
            set {
                this._category = value;
            }
        }
        public SpellCard() { }
        public SpellCard(string nome, string effect, SpellCategory category) : base(nome) {
            this._effect = effect;
            this._category = category;
        }

        public override string ToString() {
            return String.Format("Nome: {0}\nCategoria: {1}\nEfeito: {2}", this.Nome, this.Category, this.Effect);
        }
    }
}
