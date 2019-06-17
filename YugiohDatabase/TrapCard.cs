using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohDatabase {
    class TrapCard : Cards {
        private string _effect { get; set; }
        private TrapCategory _category { get; set; }

        public TrapCard() { }
        public TrapCard(string nome, string effect, TrapCategory category) : base(nome) {
            this._effect = effect;
            this._category = category;
        }

        public string Effect {
            get { return _effect; }
            set { this._effect = value; }
        }

        public TrapCategory Category {
            get { return this._category; }
            set { this._category = value; }
        }

        public override string ToString(){
            return String.Format("Nome: {0}\nCategoria: {1}\nEfeito: {2}", this.Nome, this.Category, this.Effect);
        }

    }
}
