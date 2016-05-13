using enova365.PocztaExt.WiadomosciExt;
using Soneta.Business;
using Soneta.Handel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

[assembly: Service(typeof(IZmianaDokumentuHandlowego), typeof(ZatwierdzanieFVService))]

namespace enova365.PocztaExt.WiadomosciExt
{
    public class ZatwierdzanieFVService : IZmianaDokumentuHandlowego
    {
        public void WyliczenieCenyPozycji(WyliczenieCenyPozycjiDokumentuArgs args)
        {
        }

        public void Zatwierdzanie(ZmianaDokumentuHandlowegoArgs args)
        {
            Trace.WriteLine("Zatwierdzanie " + args.Dokument + ", edycja: " + args.Edycja, "Zmiana dokumentu");
        }

        public void Zatwierdzony(ZmianaDokumentuHandlowegoArgs args)
        {
            PrzeliczanieDniHelper.Przelicz(args.Dokument);
        }

        public void ZmianaPozycji(ZmianaPozycjiDokumentuArgs args)
        {
        }

        public void ZmianaPłatności(ZmianaDokumentuHandlowegoArgs args)
        {
        }

        public void ZmianaStanu(ZmianaStanuDokumentuHandlowegoArgs args)
        {
        }

        public void ZmianaWartości(ZmianaDokumentuHandlowegoArgs args)
        {
        }
    }
}
