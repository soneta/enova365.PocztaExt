using enova365.PocztaExt.WiadomosciExt;
using Soneta.Business;
using Soneta.Business.App;
using Soneta.Handel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: NewRow(typeof(WydrukWiadomosci))]

namespace enova365.PocztaExt.WiadomosciExt
{
    public class WydrukWiadomosci : PocztaExtModule.WydrukWiadomosciRow
    {
        public WydrukWiadomosci(RowCreator creator) : base(creator)
        {
        }
        public WydrukWiadomosci(DefDokHandlowego def, Operator op) : base(def, op)
        {
        }
        protected override void OnAdded()
        {
            base.OnAdded();

        }
        public override string ToString()
        {
            return Wzorzec;
        }
    }
}
