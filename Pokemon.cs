using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokodigon
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Life { get; set; }
        public Attack[] attacks ;
        public int index;

        public Pokemon(string name, string type)
        {
            Name = name;
            Type = type;
            attacks = new Attack[2];
            index = 0;
            Life = 150;
        }
        public void AddAttack(Attack attack) {
            attacks[index] = attack;
            index++;
         }

        public Pokemon()
        {
        }
        public void DamagePoints(int damage) {
            Life -= damage;
        }
        public override string ToString()
        {
            return string.Format("Nombre Pokemon: {0}, Tipo: {1}, LP {2}\n",Name,Type,Life) + stringAttack(attacks); 
        }
        public string stringAttack(Attack[] attack) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < index; i++) { 
                if (attack[i] == null) { continue; }
                string dato = string.Format("{0}. {1}", i + 1, attack[i]);
                sb.AppendLine(dato);
            }

            return sb.ToString();
        }
    }
}
