using enova365.PocztaExt.WiadomosciExt;
using Soneta.Business;
using Soneta.CRM;
using Soneta.Handel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: NewRow(typeof(WiadomoscExt))]

namespace enova365.PocztaExt.WiadomosciExt
{
    public class WiadomoscExt : PocztaExtModule.WiadomoscExtRow
    {
        public WiadomoscExt(RowCreator creator) : base(creator)
        {
        }
        public WiadomoscExt(WiadomoscEmail wiadomosc, DokumentHandlowy dokument) : base(wiadomosc, dokument)
        {
        }

        public override string ToString()
        {
            return (Wiadomosc == null) ? "" : Wiadomosc.ToString();
        }
    }
}
