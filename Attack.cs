using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokodigon
{
    class Attack
    {
        public string Name { get; set; }
        public int Value { get; set; }
       

        public Attack(string name)
        {
            Name = name;          
        }

        public Attack()
        {

        }

        public override string ToString()
        {
            return string.Format("  {0} Valor: {1}",Name,Value);
        }
    }
}
