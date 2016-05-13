
//----------------------------------------------------------------------------------
// <autogenerated>
//		This code was generated by a tool.
//		Changes to this file may cause incorrect behaviour and will be lost 
//		if the code is regenerated.
// </autogenerated>
//----------------------------------------------------------------------------------

using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using Soneta.Types;
using Soneta.Business;
using Soneta.Handel;
using Soneta.CRM;
using Soneta.Business.App;
using enova365.PocztaExt.WiadomosciExt;

[assembly: ModuleType("PocztaExt", typeof(enova365.PocztaExt.WiadomosciExt.PocztaExtModule), 2, "PocztaExt", 2, VersionNumber=2)]

namespace enova365.PocztaExt.WiadomosciExt {

	/// <summary>
	/// Moduł PocztaExt.
	/// <seealso cref="Soneta.Handel"/>
	/// <seealso cref="Soneta.CRM"/>
	/// <seealso cref="Soneta.Business.App"/>
	/// </summary>
	/// <seealso cref="Soneta.Business.Module"/>
	/// <seealso cref="Soneta.Business.Session"/>
	[System.CodeDom.Compiler.GeneratedCode("Soneta.Generator", "2")]
	public partial class PocztaExtModule : Module {

		public static PocztaExtModule GetInstance(ISessionable session) {
			if (session == null || session.Session == null) return null;
			return (PocztaExtModule)session.Session.Modules[typeof(PocztaExtModule)];
		}

		/// <summary>
		/// Standardowy kontruktor modułu sesji.
		/// </summary>
		/// <param name="session">Sesja w której jest tworzony ten moduł.</param>
		public PocztaExtModule(Session session) : base(session, "PocztaExt") {
			AddTable(tableWiadomoscExt);
			AddTable(tableWydrukWiadomosci);
			Initialize();
		}

		HandelModule moduleHandel = null;

		[Browsable(false)]
		public HandelModule Handel {
			get {
				if (moduleHandel==null)
				    moduleHandel = HandelModule.GetInstance(Session);
				return moduleHandel;
			}
		}

		CRMModule moduleCRM = null;

		[Browsable(false)]
		public CRMModule CRM {
			get {
				if (moduleCRM==null)
				    moduleCRM = CRMModule.GetInstance(Session);
				return moduleCRM;
			}
		}

		static int handleWiadomosciExt = 0;

		private WiadomosciExt tableWiadomoscExt = new WiadomosciExt();
		/// <summary>
		/// Tabela WiadomoscExt.
		/// </summary>
		public WiadomosciExt WiadomosciExt {
			get { return tableWiadomoscExt; } 
		}

		/// <summary>
		/// Klasa implementująca standardową obsługę tabeli obiektów WiadomoscExt.
		/// Dziedzicząca klasa <see cref="WiadomosciExt"/> zawiera kod użytkownika
		/// zawierający specyficzną funkcjonalność tabeli, która nie zawiera się w funkcjonalności
		/// biblioteki <see cref="Soneta.Business"/>.
		/// </summary>
		/// <seealso cref="WiadomosciExt"/>
		/// <seealso cref="WiadomoscExtRow"/>
		/// <seealso cref="WiadomoscExt"/>
		/// <seealso cref="Soneta.Business.Table"/>
		[TableName("WiadomoscExt", "Wiadomos", "WiadomosciExt", typeof(WiadomoscExt))]
		public abstract partial class WiadomoscExtTable : GuidedTable {

			protected WiadomoscExtTable() : base(false, false) {
			}

			public class WiadomoscRelation : SimpleRelation {
				protected override object [] GetData(Row row, Record rec) {
					return new object[] {
						((WiadomoscExtRecord)rec).Wiadomosc,
						row.ID};
				}
				public WiadomoscRelation(WiadomoscExtTable table) {
					Table = table;
					Name = "Dokumenty związane z wiadomością";
					ParentName = "WiadomoscEmail";
					ChildColumn = "Wiadomosc";
					InitFields("Wiadomosc", "ID");
					table.Session.Keys.Add(this);
				}

				public SubTable this[WiadomoscEmail wiadomosc] {
					get {
						return new SubTable(this, wiadomosc);
					}
				}
			}

			WiadomoscRelation relationWiadomosc;

			public WiadomoscRelation WgWiadomosc {
				get { return relationWiadomosc; } 
			}

			public class DokumentRelation : SimpleRelation {
				protected override object [] GetData(Row row, Record rec) {
					return new object[] {
						((WiadomoscExtRecord)rec).Dokument,
						row.ID};
				}
				public DokumentRelation(WiadomoscExtTable table) {
					Table = table;
					Name = "Powiązanie dokumentu z wiadomosciąEmail";
					ParentName = "DokumentHandlowy";
					ChildColumn = "Dokument";
					InitFields("Dokument", "ID");
					table.Session.Keys.Add(this);
				}

				public SubTable this[DokumentHandlowy dokument] {
					get {
						return new SubTable(this, dokument);
					}
				}
			}

			DokumentRelation relationDokument;

			public DokumentRelation WgDokument {
				get { return relationDokument; } 
			}

			public class WgWiadomoscDokumentKey : Key {
				protected override object [] GetData(Row row, Record rec) {
					return new object[] {
						((WiadomoscExtRecord)rec).Wiadomosc,
						((WiadomoscExtRecord)rec).Dokument};
				}
				public WgWiadomoscDokumentKey(WiadomoscExtTable table) {
					Table = table;
					Name = "WgWiadomoscDokument";
					Unique = true;
					InitFields("Wiadomosc", "Dokument");
					table.Session.Keys.Add(this);
				}

				public SubTable this[WiadomoscEmail wiadomosc] {
					get {
						return new SubTable(this, wiadomosc);
					}
				}

				public WiadomoscExt this[WiadomoscEmail wiadomosc, DokumentHandlowy dokument] {
					get {
						return (WiadomoscExt)Find(wiadomosc, dokument);
					}
				}
			}

			WgWiadomoscDokumentKey keyWgWiadomoscDokument;

			public WgWiadomoscDokumentKey WgWiadomoscDokument {
				get { return keyWgWiadomoscDokument; } 
			}


			protected override void LoadChildRelations() {
			}

			/// <summary>
			/// Typowane property dostarczające obiekt modułu zawierającegą tą tabelę. Umożliwia dostęp do
			/// innych obiektów znajdujących się w tym samym module.
			/// </summary>
			/// <seealso cref="PocztaExtModule"/>
			public new PocztaExtModule Module {
				get { return (PocztaExtModule)base.Module; } 
			}

			/// <summary>
			/// Typowany indekser dostarczający obiekty znajdujące się w tej tabeli przy pomocy 
			/// ID identyfikującego jednoznacznie obiekt w systemie.
			/// </summary>
			/// <param name="id">Liczba będąca unikalnym identyfikatorem obiektu. Wartości
			/// ujemne identyfikują obiekty, które zostały dodane i nie są jeszcze zapisane do bazy danych.</param>
			/// <seealso cref="WiadomoscExt"/>
			public new WiadomoscExt this[int id] {
				get { return (WiadomoscExt)base[id]; } 
			}

			public new WiadomoscExt this[Guid guid] {
				get { return (WiadomoscExt)base[guid]; } 
			}

			protected override void Adding(Module module) {
				base.Adding(module);
				relationWiadomosc = new WiadomoscRelation(this);
				relationDokument = new DokumentRelation(this);
				keyWgWiadomoscDokument = new WgWiadomoscDokumentKey(this);
				SetPrimaryKey(keyWgWiadomoscDokument);
			}

			protected override Record CreateRecord() {
				return new WiadomoscExtRecord();
			}

			protected override Row CreateRow(RowCreator creator) {
				return new WiadomoscExt(creator);
			}

			/// <summary>
			/// Metoda zwracająca typ wierszy znajdujących się w tej tabeli.
			/// </summary>
			/// <returns>Metoda zwraca zawsze wartość typeof(WiadomoscExt).</returns>
			/// <seealso cref="WiadomoscExt"/>
			public override Type GetRowType() {
				return typeof(WiadomoscExt);
			}

			protected override sealed int GetTableHandle() {
				return handleWiadomosciExt;
			}

			protected override sealed void PrepareNames(StringBuilder names, string divider, bool prepareTextFields) {
				names.Append(divider); names.Append("Guid");
				names.Append(divider); names.Append("Wiadomosc");
				names.Append(divider); names.Append("Dokument");
				names.Append(divider); names.Append("CzasRealizacji");
			}

			protected override sealed void PrepareTypes(System.Collections.Generic.List<Type> types) {
				types.Add(typeof(Guid));
				types.Add(typeof(Row));
				types.Add(typeof(Row));
				types.Add(typeof(int));
			}

		}

		[RecordType(typeof(WiadomoscExtRecord))]
		[Caption("Poziązanie wiadmości z dokumentem handlowym")]
		public abstract partial class WiadomoscExtRow : GuidedRow {

			private WiadomoscExtRecord record = null;


			protected override void AssignRecord(Record rec) {
				record = (WiadomoscExtRecord)rec;
			}

			protected WiadomoscExtRow(RowCreator creator) : base(false) {
			}

			protected WiadomoscExtRow([Required] WiadomoscEmail wiadomosc, [Required] DokumentHandlowy dokument) : base(true) {
				if (wiadomosc==null) throw new RequiredException(this, "Wiadomosc");
				if (dokument==null) throw new RequiredException(this, "Dokument");
				GetRecord();
				record.Wiadomosc = wiadomosc;
				record.Dokument = dokument;
			}

			[Description("Powiązanie wiadomości eMail z Dokumentem handlowym.")]
			[Category("Ogólne")]
			[Caption("WiadomoscEmail")]
			[Required]
			public WiadomoscEmail Wiadomosc {
				get {
					if (record==null) GetRecord();
					if (record.Wiadomosc==null) return null;
					WiadomoscEmail row = (WiadomoscEmail)record.Wiadomosc.Root;
					record.Wiadomosc = row;
					return row;
				}
			}

			[Description("Powiązanie dokumentu z wiadomościami Email")]
			[Category("Ogólne")]
			[Caption("Dokument")]
			[Required]
			public DokumentHandlowy Dokument {
				get {
					if (record==null) GetRecord();
					if (record.Dokument==null) return null;
					DokumentHandlowy row = (DokumentHandlowy)record.Dokument.Root;
					record.Dokument = row;
					return row;
				}
			}

			[Description("Dni oczekiwania do sprzedaży")]
			[Category("Ogólne")]
			[Caption("CzasRealizacji")]
			public int CzasRealizacji {
				get {
					if (record==null) GetRecord();
					return record.CzasRealizacji;
				}
				set {
					if (WiadomoscExtSchema.CzasRealizacjiBeforeEdit!=null)
						WiadomoscExtSchema.CzasRealizacjiBeforeEdit((WiadomoscExt)this, ref value);
					GetEdit(record==null, false);
					record.CzasRealizacji = value;
					if (WiadomoscExtSchema.CzasRealizacjiAfterEdit!=null)
						WiadomoscExtSchema.CzasRealizacjiAfterEdit((WiadomoscExt)this);
				}
			}

			[Browsable(false)]
			public new WiadomosciExt Table {
				get { return (WiadomosciExt)base.Table; }
			}

			[Browsable(false)]
			public PocztaExtModule Module {
				get { return Table.Module; }
			}

			protected override sealed int GetTableHandle() {
				return handleWiadomosciExt;
			}

			protected override Record CreateRecord() {
				return new WiadomoscExtRecord();
			}

			public sealed override AccessRights GetObjectRight() {
				AccessRights ar = CalcObjectRight();
				if (WiadomoscExtSchema.OnCalcObjectRight!=null)
					WiadomoscExtSchema.OnCalcObjectRight((WiadomoscExt)this, ref ar);
				return ar;
			}

			protected sealed override AccessRights GetParentsObjectRight() {
				AccessRights result = CalcParentsObjectRight();
				if (WiadomoscExtSchema.OnCalcParentsObjectRight!=null)
					WiadomoscExtSchema.OnCalcParentsObjectRight((WiadomoscExt)this, ref result);
				return result;
			}

			protected override void OnAdded() {
				base.OnAdded();
				System.Diagnostics.Debug.Assert(record.Wiadomosc==null || record.Wiadomosc.State==RowState.Detached || Session==record.Wiadomosc.Session);
				System.Diagnostics.Debug.Assert(record.Dokument==null || record.Dokument.State==RowState.Detached || Session==record.Dokument.Session);
				if (WiadomoscExtSchema.OnAdded!=null)
					WiadomoscExtSchema.OnAdded((WiadomoscExt)this);
			}

			protected override void OnLoaded() {
				base.OnLoaded();
				if (WiadomoscExtSchema.OnLoaded!=null)
					WiadomoscExtSchema.OnLoaded((WiadomoscExt)this);
			}

			protected override void OnEditing() {
				base.OnEditing();
				if (WiadomoscExtSchema.OnEditing!=null)
					WiadomoscExtSchema.OnEditing((WiadomoscExt)this);
			}

			protected override void OnDeleting() {
				base.OnDeleting();
				if (WiadomoscExtSchema.OnDeleting!=null)
					WiadomoscExtSchema.OnDeleting((WiadomoscExt)this);
			}

			protected override void OnDeleted() {
				base.OnDeleted();
				if (WiadomoscExtSchema.OnDeleted!=null)
					WiadomoscExtSchema.OnDeleted((WiadomoscExt)this);
			}

		}

		[ParentTable("WiadomoscExt")]
		public sealed class WiadomoscExtRecord : GuidedRecord {
			[Required]
			[ParentTable("WiadomoscEmail")]
			public IRow Wiadomosc;
			[Required]
			[ParentTable("DokumentHandlowy")]
			public IRow Dokument;
			public int CzasRealizacji;

			public override Record Clone() {
				WiadomoscExtRecord rec = (WiadomoscExtRecord)MemberwiseClone();
				return rec;
			}

			public override void Load(RowCreator creator, int delta) {
				System.Diagnostics.Debug.Assert(delta==0);
				Guid = creator.Load_guid(1);
				Wiadomosc = creator.Load_Row(2, "WiadomosciEmail");
				Dokument = creator.Load_Row(3, "DokHandlowe");
				CzasRealizacji = creator.Load_int(4);
			}
		}

		public static class WiadomoscExtSchema {

			internal static RowDelegate<WiadomoscExtRow, int> CzasRealizacjiBeforeEdit;
			public static void AddCzasRealizacjiBeforeEdit(RowDelegate<WiadomoscExtRow, int> value) {
				CzasRealizacjiBeforeEdit = (RowDelegate<WiadomoscExtRow, int>)Delegate.Combine(CzasRealizacjiBeforeEdit, value);
			}

			internal static RowDelegate<WiadomoscExtRow> CzasRealizacjiAfterEdit;
			public static void AddCzasRealizacjiAfterEdit(RowDelegate<WiadomoscExtRow> value) {
				CzasRealizacjiAfterEdit = (RowDelegate<WiadomoscExtRow>)Delegate.Combine(CzasRealizacjiAfterEdit, value);
			}

			internal static RowDelegate<WiadomoscExtRow> OnLoaded;
			public static void AddOnLoaded(RowDelegate<WiadomoscExtRow> value) {
				OnLoaded = (RowDelegate<WiadomoscExtRow>)Delegate.Combine(OnLoaded, value);
			}

			internal static RowDelegate<WiadomoscExtRow> OnAdded;
			public static void AddOnAdded(RowDelegate<WiadomoscExtRow> value) {
				OnAdded = (RowDelegate<WiadomoscExtRow>)Delegate.Combine(OnAdded, value);
			}

			internal static RowDelegate<WiadomoscExtRow> OnEditing;
			public static void AddOnEditing(RowDelegate<WiadomoscExtRow> value) {
				OnEditing = (RowDelegate<WiadomoscExtRow>)Delegate.Combine(OnEditing, value);
			}

			internal static RowDelegate<WiadomoscExtRow> OnDeleting;
			public static void AddOnDeleting(RowDelegate<WiadomoscExtRow> value) {
				OnDeleting = (RowDelegate<WiadomoscExtRow>)Delegate.Combine(OnDeleting, value);
			}

			internal static RowDelegate<WiadomoscExtRow> OnDeleted;
			public static void AddOnDeleted(RowDelegate<WiadomoscExtRow> value) {
				OnDeleted = (RowDelegate<WiadomoscExtRow>)Delegate.Combine(OnDeleted, value);
			}

			internal static RowAccessRightsDelegate<WiadomoscExtRow> OnCalcObjectRight;
			public static void AddOnCalcObjectRight(RowAccessRightsDelegate<WiadomoscExtRow> value) {
				OnCalcObjectRight = (RowAccessRightsDelegate<WiadomoscExtRow>)Delegate.Combine(OnCalcObjectRight, value);
			}

			internal static RowAccessRightsDelegate<WiadomoscExtRow> OnCalcParentsObjectRight;
			public static void AddOnCalcParentsObjectRight(RowAccessRightsDelegate<WiadomoscExtRow> value) {
				OnCalcParentsObjectRight = (RowAccessRightsDelegate<WiadomoscExtRow>)Delegate.Combine(OnCalcParentsObjectRight, value);
			}

		}

		static int handleWydrukiWiad = 0;

		private WydrukiWiad tableWydrukWiadomosci = new WydrukiWiad();
		/// <summary>
		/// Tabela WydrukWiadomosci.
		/// </summary>
		public WydrukiWiad WydrukiWiad {
			get { return tableWydrukWiadomosci; } 
		}

		/// <summary>
		/// Klasa implementująca standardową obsługę tabeli obiektów WydrukWiadomosci.
		/// Dziedzicząca klasa <see cref="WydrukiWiad"/> zawiera kod użytkownika
		/// zawierający specyficzną funkcjonalność tabeli, która nie zawiera się w funkcjonalności
		/// biblioteki <see cref="Soneta.Business"/>.
		/// </summary>
		/// <seealso cref="WydrukiWiad"/>
		/// <seealso cref="WydrukWiadomosciRow"/>
		/// <seealso cref="WydrukWiadomosci"/>
		/// <seealso cref="Soneta.Business.Table"/>
		[TableName("WydrukWiadomosci", "WydrukWi", "WydrukiWiad", typeof(WydrukWiadomosci))]
		public abstract partial class WydrukWiadomosciTable : GuidedTable {

			protected WydrukWiadomosciTable() : base(false, false) {
			}

			public class DefinicjaRelation : SimpleRelation {
				protected override object [] GetData(Row row, Record rec) {
					return new object[] {
						((WydrukWiadomosciRecord)rec).Definicja,
						row.ID};
				}
				public DefinicjaRelation(WydrukWiadomosciTable table) {
					Table = table;
					ParentName = "DefDokHandlowego";
					ChildColumn = "Definicja";
					InitFields("Definicja", "ID");
					table.Session.Keys.Add(this);
				}

				public SubTable this[DefDokHandlowego definicja] {
					get {
						return new SubTable(this, definicja);
					}
				}
			}

			DefinicjaRelation relationDefinicja;

			public DefinicjaRelation WgDefinicja {
				get { return relationDefinicja; } 
			}

			public class OperatorRelation : SimpleRelation {
				protected override object [] GetData(Row row, Record rec) {
					return new object[] {
						((WydrukWiadomosciRecord)rec).Operator,
						row.ID};
				}
				public OperatorRelation(WydrukWiadomosciTable table) {
					Table = table;
					ParentName = "Operator";
					ChildColumn = "Operator";
					InitFields("Operator", "ID");
					table.Session.Keys.Add(this);
				}

				public SubTable this[Operator _operator] {
					get {
						return new SubTable(this, _operator);
					}
				}
			}

			OperatorRelation relationOperator;

			public OperatorRelation WgOperator {
				get { return relationOperator; } 
			}

			public class WgDefinicjaOperatorKey : Key {
				protected override object [] GetData(Row row, Record rec) {
					return new object[] {
						((WydrukWiadomosciRecord)rec).Definicja,
						((WydrukWiadomosciRecord)rec).Operator};
				}
				public WgDefinicjaOperatorKey(WydrukWiadomosciTable table) {
					Table = table;
					Name = "WgDefinicjaOperator";
					Unique = true;
					InitFields("Definicja", "Operator");
					table.Session.Keys.Add(this);
				}

				public SubTable this[DefDokHandlowego definicja] {
					get {
						return new SubTable(this, definicja);
					}
				}

				public WydrukWiadomosci this[DefDokHandlowego definicja, Operator _operator] {
					get {
						return (WydrukWiadomosci)Find(definicja, _operator);
					}
				}
			}

			WgDefinicjaOperatorKey keyWgDefinicjaOperator;

			public WgDefinicjaOperatorKey WgDefinicjaOperator {
				get { return keyWgDefinicjaOperator; } 
			}


			protected override void LoadChildRelations() {
			}

			/// <summary>
			/// Typowane property dostarczające obiekt modułu zawierającegą tą tabelę. Umożliwia dostęp do
			/// innych obiektów znajdujących się w tym samym module.
			/// </summary>
			/// <seealso cref="PocztaExtModule"/>
			public new PocztaExtModule Module {
				get { return (PocztaExtModule)base.Module; } 
			}

			/// <summary>
			/// Typowany indekser dostarczający obiekty znajdujące się w tej tabeli przy pomocy 
			/// ID identyfikującego jednoznacznie obiekt w systemie.
			/// </summary>
			/// <param name="id">Liczba będąca unikalnym identyfikatorem obiektu. Wartości
			/// ujemne identyfikują obiekty, które zostały dodane i nie są jeszcze zapisane do bazy danych.</param>
			/// <seealso cref="WydrukWiadomosci"/>
			public new WydrukWiadomosci this[int id] {
				get { return (WydrukWiadomosci)base[id]; } 
			}

			public new WydrukWiadomosci this[Guid guid] {
				get { return (WydrukWiadomosci)base[guid]; } 
			}

			protected override void Adding(Module module) {
				base.Adding(module);
				relationDefinicja = new DefinicjaRelation(this);
				relationOperator = new OperatorRelation(this);
				keyWgDefinicjaOperator = new WgDefinicjaOperatorKey(this);
				SetPrimaryKey(keyWgDefinicjaOperator);
			}

			protected override Record CreateRecord() {
				return new WydrukWiadomosciRecord();
			}

			protected override Row CreateRow(RowCreator creator) {
				return new WydrukWiadomosci(creator);
			}

			/// <summary>
			/// Metoda zwracająca typ wierszy znajdujących się w tej tabeli.
			/// </summary>
			/// <returns>Metoda zwraca zawsze wartość typeof(WydrukWiadomosci).</returns>
			/// <seealso cref="WydrukWiadomosci"/>
			public override Type GetRowType() {
				return typeof(WydrukWiadomosci);
			}

			protected override sealed int GetTableHandle() {
				return handleWydrukiWiad;
			}

			protected override sealed void PrepareNames(StringBuilder names, string divider, bool prepareTextFields) {
				names.Append(divider); names.Append("Guid");
				names.Append(divider); names.Append("Definicja");
				names.Append(divider); names.Append("Operator");
				names.Append(divider); names.Append("Wzorzec");
			}

			protected override sealed void PrepareTypes(System.Collections.Generic.List<Type> types) {
				types.Add(typeof(Guid));
				types.Add(typeof(Row));
				types.Add(typeof(Row));
				types.Add(typeof(string));
			}

		}

		[RecordType(typeof(WydrukWiadomosciRecord))]
		[Caption("Definicja wydruków pod wysyłkę wiadomosci")]
		public abstract partial class WydrukWiadomosciRow : GuidedRow {

			private WydrukWiadomosciRecord record = null;


			protected override void AssignRecord(Record rec) {
				record = (WydrukWiadomosciRecord)rec;
			}

			protected WydrukWiadomosciRow(RowCreator creator) : base(false) {
			}

			protected WydrukWiadomosciRow([Required] DefDokHandlowego definicja, [Required] Operator _operator) : base(true) {
				if (definicja==null) throw new RequiredException(this, "Definicja");
				if (_operator==null) throw new RequiredException(this, "Operator");
				GetRecord();
				record.Definicja = definicja;
				record.Operator = _operator;
			}

			[Description("Definicja dok han")]
			[Category("Ogólne")]
			[Caption("Definicja")]
			[Required]
			public DefDokHandlowego Definicja {
				get {
					if (record==null) GetRecord();
					if (record.Definicja==null) return null;
					DefDokHandlowego row = (DefDokHandlowego)record.Definicja.Root;
					record.Definicja = row;
					return row;
				}
			}

			[Description("Operator.")]
			[Category("Ogólne")]
			[Caption("Operator")]
			[Required]
			public Operator Operator {
				get {
					if (record==null) GetRecord();
					if (record.Operator==null) return null;
					Operator row = (Operator)record.Operator.Root;
					record.Operator = row;
					return row;
				}
			}

			[Description("Wzorzec wydruku")]
			[Category("Ogólne")]
			[MaxLength(255)]
			public string Wzorzec {
				get {
					if (record==null) GetRecord();
					return record.Wzorzec;
				}
				set {
					if (WydrukWiadomosciSchema.WzorzecBeforeEdit!=null)
						WydrukWiadomosciSchema.WzorzecBeforeEdit((WydrukWiadomosci)this, ref value);
					if (value!=null) value = value.TrimEnd();
					if (value.Length>WzorzecLength) throw new ValueToLongException(this, "Wzorzec", WzorzecLength);
					GetEdit(record==null, false);
					record.Wzorzec = value;
					if (WydrukWiadomosciSchema.WzorzecAfterEdit!=null)
						WydrukWiadomosciSchema.WzorzecAfterEdit((WydrukWiadomosci)this);
				}
			}

			public const int WzorzecLength = 255;

			[Browsable(false)]
			public new WydrukiWiad Table {
				get { return (WydrukiWiad)base.Table; }
			}

			[Browsable(false)]
			public PocztaExtModule Module {
				get { return Table.Module; }
			}

			protected override sealed int GetTableHandle() {
				return handleWydrukiWiad;
			}

			protected override Record CreateRecord() {
				return new WydrukWiadomosciRecord();
			}

			public sealed override AccessRights GetObjectRight() {
				AccessRights ar = CalcObjectRight();
				if (WydrukWiadomosciSchema.OnCalcObjectRight!=null)
					WydrukWiadomosciSchema.OnCalcObjectRight((WydrukWiadomosci)this, ref ar);
				return ar;
			}

			protected sealed override AccessRights GetParentsObjectRight() {
				AccessRights result = CalcParentsObjectRight();
				if (WydrukWiadomosciSchema.OnCalcParentsObjectRight!=null)
					WydrukWiadomosciSchema.OnCalcParentsObjectRight((WydrukWiadomosci)this, ref result);
				return result;
			}

			protected override void OnAdded() {
				base.OnAdded();
				System.Diagnostics.Debug.Assert(record.Definicja==null || record.Definicja.State==RowState.Detached || Session==record.Definicja.Session);
				System.Diagnostics.Debug.Assert(record.Operator==null || record.Operator.State==RowState.Detached || Session==record.Operator.Session);
				if (WydrukWiadomosciSchema.OnAdded!=null)
					WydrukWiadomosciSchema.OnAdded((WydrukWiadomosci)this);
			}

			protected override void OnLoaded() {
				base.OnLoaded();
				if (WydrukWiadomosciSchema.OnLoaded!=null)
					WydrukWiadomosciSchema.OnLoaded((WydrukWiadomosci)this);
			}

			protected override void OnEditing() {
				base.OnEditing();
				if (WydrukWiadomosciSchema.OnEditing!=null)
					WydrukWiadomosciSchema.OnEditing((WydrukWiadomosci)this);
			}

			protected override void OnDeleting() {
				base.OnDeleting();
				if (WydrukWiadomosciSchema.OnDeleting!=null)
					WydrukWiadomosciSchema.OnDeleting((WydrukWiadomosci)this);
			}

			protected override void OnDeleted() {
				base.OnDeleted();
				if (WydrukWiadomosciSchema.OnDeleted!=null)
					WydrukWiadomosciSchema.OnDeleted((WydrukWiadomosci)this);
			}

		}

		[ParentTable("WydrukWiadomosci")]
		public sealed class WydrukWiadomosciRecord : GuidedRecord {
			[Required]
			[ParentTable("DefDokHandlowego")]
			public IRow Definicja;
			[Required]
			[ParentTable("Operator")]
			public IRow Operator;
			[MaxLength(255)]
			public string Wzorzec = "";

			public override Record Clone() {
				WydrukWiadomosciRecord rec = (WydrukWiadomosciRecord)MemberwiseClone();
				return rec;
			}

			public override void Load(RowCreator creator, int delta) {
				System.Diagnostics.Debug.Assert(delta==0);
				Guid = creator.Load_guid(1);
				Definicja = creator.Load_Row(2, "DefDokHandlowych");
				Operator = creator.Load_Row(3, "Operators");
				Wzorzec = creator.Load_string(4);
			}
		}

		public static class WydrukWiadomosciSchema {

			internal static RowDelegate<WydrukWiadomosciRow, string> WzorzecBeforeEdit;
			public static void AddWzorzecBeforeEdit(RowDelegate<WydrukWiadomosciRow, string> value) {
				WzorzecBeforeEdit = (RowDelegate<WydrukWiadomosciRow, string>)Delegate.Combine(WzorzecBeforeEdit, value);
			}

			internal static RowDelegate<WydrukWiadomosciRow> WzorzecAfterEdit;
			public static void AddWzorzecAfterEdit(RowDelegate<WydrukWiadomosciRow> value) {
				WzorzecAfterEdit = (RowDelegate<WydrukWiadomosciRow>)Delegate.Combine(WzorzecAfterEdit, value);
			}

			internal static RowDelegate<WydrukWiadomosciRow> OnLoaded;
			public static void AddOnLoaded(RowDelegate<WydrukWiadomosciRow> value) {
				OnLoaded = (RowDelegate<WydrukWiadomosciRow>)Delegate.Combine(OnLoaded, value);
			}

			internal static RowDelegate<WydrukWiadomosciRow> OnAdded;
			public static void AddOnAdded(RowDelegate<WydrukWiadomosciRow> value) {
				OnAdded = (RowDelegate<WydrukWiadomosciRow>)Delegate.Combine(OnAdded, value);
			}

			internal static RowDelegate<WydrukWiadomosciRow> OnEditing;
			public static void AddOnEditing(RowDelegate<WydrukWiadomosciRow> value) {
				OnEditing = (RowDelegate<WydrukWiadomosciRow>)Delegate.Combine(OnEditing, value);
			}

			internal static RowDelegate<WydrukWiadomosciRow> OnDeleting;
			public static void AddOnDeleting(RowDelegate<WydrukWiadomosciRow> value) {
				OnDeleting = (RowDelegate<WydrukWiadomosciRow>)Delegate.Combine(OnDeleting, value);
			}

			internal static RowDelegate<WydrukWiadomosciRow> OnDeleted;
			public static void AddOnDeleted(RowDelegate<WydrukWiadomosciRow> value) {
				OnDeleted = (RowDelegate<WydrukWiadomosciRow>)Delegate.Combine(OnDeleted, value);
			}

			internal static RowAccessRightsDelegate<WydrukWiadomosciRow> OnCalcObjectRight;
			public static void AddOnCalcObjectRight(RowAccessRightsDelegate<WydrukWiadomosciRow> value) {
				OnCalcObjectRight = (RowAccessRightsDelegate<WydrukWiadomosciRow>)Delegate.Combine(OnCalcObjectRight, value);
			}

			internal static RowAccessRightsDelegate<WydrukWiadomosciRow> OnCalcParentsObjectRight;
			public static void AddOnCalcParentsObjectRight(RowAccessRightsDelegate<WydrukWiadomosciRow> value) {
				OnCalcParentsObjectRight = (RowAccessRightsDelegate<WydrukWiadomosciRow>)Delegate.Combine(OnCalcParentsObjectRight, value);
			}

		}

	}
}

