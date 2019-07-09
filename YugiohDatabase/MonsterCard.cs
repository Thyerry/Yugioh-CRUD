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

        public MonsterCard() { }
        public MonsterCard(string _nome, int atkValue, int defValue, int level, MonsterType tipo, MonsterAttribute atributo) : base(_nome) {
            this._atkValue = atkValue;
            this._defValue = defValue;
            this._level = level;
            this._type = tipo;
            this._attribute = atributo;
        }
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
        public override string ToString() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Monstro:");
            Console.ResetColor();
            Console.WriteLine("Nome: {0}", this.Nome);
            Console.WriteLine("Tipo: {0}", this.Type);
            Console.WriteLine("Level: {0}", this.Level);
            Console.WriteLine("Atributo: {0}", this.Attribute);
            Console.WriteLine("ATK: {0}", this.AtkValue);
            Console.WriteLine("DEF: {0}", this.DefValue);
            
            return null/*String.Format("Monstro:\nNome: {0}\nTipo: {1}\nLevel: {2}\nAtributo: {3}\nATK: {4}\nDEF: {5}", this.Nome, this.Type, this.Level, this.Attribute, this.AtkValue, this.DefValue)*/;
        }
    }
}
