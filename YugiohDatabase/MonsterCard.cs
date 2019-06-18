using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YugiohDatabase.Enum;

namespace YugiohDatabase {
    class MonsterCard : Cards {
        private int _atkValue { get; set; }
        private int _defValue { get; set; }
        private MonsterType _type { get; set; }
        private MonsterAttribute _attribute { get; set; }

        public int AtkValue {
            get { return this._atkValue; }
            set { this._atkValue = value; }
        }

        public int DefValue {
            get { return this._defValue; }
            set { this._defValue = value; }
        }

        public MonsterType Type {
            get { return this._type; }
            set { this._type = value; }
        }

        public MonsterAttribute Attribute {
            get { return this._attribute; }
            set { this._attribute = value; }
        }
        public MonsterCard() { }
        public MonsterCard(string _nome, int atkValue, int defValue, MonsterType tipo, MonsterAttribute atributo) : base(_nome) {
            this._atkValue = atkValue;
            this._defValue = defValue;
            this._type = tipo;
            this._attribute = atributo;
        }

        public override string ToString() {
            string nome = String.Format("Nome: {0}", this.Nome);
            string tipo = String.Format("Tipo: {0}", this.Type);
            string atributo = String.Format("Atributo: {0}", this.Attribute);
            string ataque = String.Format("ATK: {0}", this.AtkValue);
            string defesa = String.Format("DEF: {0}", this.DefValue);

            return String.Format("{0}\n{1}\n{2}\n{3}\t{4}", nome, tipo, atributo, ataque, defesa);
        }
    }
}
