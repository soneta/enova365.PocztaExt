using enova365.PocztaExt.WiadomosciExt;
using Soneta.Business;
using Soneta.Handel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

[assembly: Worker(
    typeof(WiadomosciDokumentuWorker),
    typeof(DokumentHandlowy))]

namespace enova365.PocztaExt.WiadomosciExt
{
    public class WiadomosciDokumentuWorker
    {
        [Context]
        public DokumentHandlowy Dokument { get; set; }

        [Description("Lista wiadomosci związanych z danym dokumentem handlowym.")]
        public SubTable Wiadomosci
        {
            get
            {
                var WiadomosciModule = PocztaExtModule.GetInstance(Dokument);
                return WiadomosciModule.WiadomosciExt.WgDokument[Dokument];
            }
        }
    }
}
