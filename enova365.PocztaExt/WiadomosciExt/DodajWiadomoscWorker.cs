using enova365.PocztaExt.WiadomosciExt;
using Soneta.Business;
using Soneta.Business.Licence;
using Soneta.Commands;
using Soneta.CRM;
using Soneta.Handel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Worker(
    typeof(DodajWiadomoscWorker),
    typeof(DokumentHandlowy))]

namespace enova365.PocztaExt.WiadomosciExt
{
    public class DodajWiadomoscWorker
    {
        [Context]
        public DokumentHandlowy Dokument { get; set; }

        [Action("Nowa wiadomość", Target = ActionTarget.ToolbarWithText, Mode = ActionMode.SingleSession,
        CommandShortcut = CommandShortcut.F8, Priority = 10,
        Contexts = new object[] { LicencjeModułu.CRM | LicencjeModułu.HAN })]
        public WiadomoscRobocza NowaWiadomosc()
        {
            WiadomoscRobocza Wiadomosc;
            using (ITransaction t = Dokument.Session.Logout(true))
            {
                Wiadomosc = new WiadomoscRobocza();
                CRMModule.GetInstance(Dokument).WiadomosciEmail.AddRow(Wiadomosc);
                if (Dokument.Kontrahent != null)
                {
                    Wiadomosc.Temat += "[" + Dokument.Numer + "]";
                    Wiadomosc.Tresc += "Witaj," + System.Environment.NewLine + Dokument.Kontrahent.NazwaFormatowana;
                    if (Dokument.Kontrahent.EMAIL != null) Wiadomosc.Do = Dokument.Kontrahent.EMAIL;

                }
                Wiadomosc.KontoPocztowe = Soneta.Zadania.ZadaniaModule.GetInstance(Dokument).Config.Operatorzy[Dokument.Session.Login.Operator].DomyslneKontoPocztowe;

                var WiadomoscDokumentu = new WiadomoscExt(Wiadomosc, Dokument);
                PocztaExtModule.GetInstance(Dokument).WiadomosciExt.AddRow(WiadomoscDokumentu);
                t.CommitUI();
            }
            return Wiadomosc;
        }
    }
}
