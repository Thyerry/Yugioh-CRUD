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
        private int _level { get; set; }
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
        public int Level {
            get { return this._level; }
            set { this._level = value; }
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
        public MonsterCard(string _nome, int atkValue, int defValue, int level,MonsterType tipo, MonsterAttribute atributo) : base(_nome) {
            this._atkValue = atkValue;
            this._defValue = defValue;
            this._level = level;
            this._type = tipo;
            this._attribute = atributo;
        }

        public override string ToString() {
            string carta = String.Format("Monstro:");
            string nome = String.Format("Nome: {0}", this.Nome);
            string tipo = String.Format("Tipo: {0}", this.Type);
            string level = String.Format("Level: {0}", this.Level);
            string atributo = String.Format("Atributo: {0}", this.Attribute);
            string ataque = String.Format("ATK: {0}", this.AtkValue);
            string defesa = String.Format("DEF: {0}", this.DefValue);

            return String.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5} {6}", carta, nome, level, tipo, atributo, ataque, defesa);
        }
    }
}
