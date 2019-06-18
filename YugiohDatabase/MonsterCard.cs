using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohDatabase
{
    class MonsterCard : Cards
    {
        private int _atkValue { get; set; }
        private int _defValue { get; set; }

        public int AtkValue
        {
            get { return this._atkValue; }
            set { this._atkValue = value; }
        }

        public int DefValue
        {
            get { return this._defValue; }
            set { this._defValue = value; }
        }

        public MonsterCard() { }
        public MonsterCard(string _nome, int atkValue, int defValue) : base(_nome)
        {
            _atkValue = atkValue;
            _defValue = defValue;
        }

        public override string ToString()
        {
            return String.Format("Nome: {0}\nAtaque: {1}\nDefesa: {2}", this.Nome, this._atkValue, this._defValue);
        }
    }
}
