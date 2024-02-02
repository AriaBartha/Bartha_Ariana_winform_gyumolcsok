using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_gyumolcsok
{
    internal class Gyumolcs
    {
        ulong code;
        string name;
        int amount;

        public ulong Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public int Amount { get => amount; set => amount = value; }

        public Gyumolcs(ulong code, string name, int amount)
        {
            Code = code;
            Name = name;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"Termék kód: {this.Code}   Termék név: {this.Name} ({this.Amount} db)";
        }

        public string toTxt()
        {
            return $"{code};{name};{amount.ToString()}";
        }
    }
}
