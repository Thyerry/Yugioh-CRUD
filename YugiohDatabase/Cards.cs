using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohDatabase {
    class Cards : IComparable <Cards>{
        private string _nome { get; set; }

        public string Nome{
            get {
                return string.Format("{0}", this._nome);
            }
            set {
                this._nome = value;
            }
            
        }
        public Cards() {

        }

        public Cards(string nome) {
            _nome = nome;
        }

        public int CompareTo(Cards other)
        {
            if(other == null)
                return 1;
            
            else 
                return this._nome.CompareTo(other.Nome);
        }
    }
}
