using enova365.PocztaExt.WiadomosciExt;
using Soneta.Business;
using Soneta.CRM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

[assembly: Worker(
    typeof(DokumentyWiadomosciWorker),
    typeof(WiadomoscEmail))]

namespace enova365.PocztaExt.WiadomosciExt
{
    public class DokumentyWiadomosciWorker
    {
        [Context]
        public WiadomoscEmail Wiadomosc { get; set; }

        [Description("Lista dokumentów powiązanych z wiadomością Email.")]
        public SubTable Dokumenty
        {
            get
            {
                var WiadomosciModule = PocztaExtModule.GetInstance(Wiadomosc);
                return WiadomosciModule.WiadomosciExt.WgWiadomosc[Wiadomosc];
            }
        }
    }
}
