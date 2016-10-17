using DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Reflection;

namespace DataLayer
{
	public class DBInitializer : CreateDatabaseIfNotExists<DBNewsdeskModel>
	{
		protected override void Seed(DBNewsdeskModel context)
		{
			string dir = AppDomain.CurrentDomain.BaseDirectory;
			DirectoryInfo parentDir = Directory.GetParent(dir);
			DirectoryInfo parentDirDir = Directory.GetParent(parentDir.ToString());
			DirectoryInfo parentDirDirDir = Directory.GetParent(parentDirDir.ToString());
			
			
			string password = Common.CreateCryptoPasswordFromString("123");
			List<Category> category = new List<Category>
			{
				new Category{Name="Aktuellt"},
				new Category{Name="Sport"},
				new Category{Name="Kultur"},
				new Category{Name="Världen"},
				new Category{Name="Motor"},
				new Category{Name="Resor"},
				new Category{Name="Mat"},
			
		};
			category.ForEach(i => context.Categories.Add(i));
			context.SaveChanges();
			List<Subscriber> Subscribers = new List<Subscriber>
			{
				new Subscriber{Email="eva.svesson@hotmail.com"},
				new Subscriber{Email="pelle.nilsson@hotmail.com"},
				new Subscriber{Email="siv.carlsson@hotmail.com"},
				new Subscriber{Email="lena.bjork@hotmail.com"},
				new Subscriber{Email="testnyheter3@gmail.com"},
			};
			Subscribers.ForEach(i => context.Subscribers.Add(i));
			context.SaveChanges();
			List<Author> authors = new List<Author>
			{
				
				new Author{FirstName="Jojje", LastName="Larsson", Password=password, Email="testnyheter3@gmail.com", IsEditor=true, IsApproved=true},
				new Author{FirstName="Zlatan", LastName="Ibrahimovic", Password=password, Email="testnyheter3@gmail.com", IsEditor=false, IsApproved=true},
				new Author{FirstName="Ingmar", LastName="Nevéus", Password=password, Email="mikael@charleston.se", IsEditor=false, IsApproved=true},
				new Author{FirstName="Åsa", LastName="Fredriksson", Password=password, Email="mikael@charleston.se", IsEditor=false, IsApproved=false},
				new Author{FirstName="Sebastian", LastName="Cederholm", Password=password, Email="mikael@charleston.se", IsEditor=false, IsApproved=false},
			};
			authors.ForEach(i => context.Authors.Add(i));
			context.SaveChanges();

			List<Category> listAktuellt = new List<Category>();
			listAktuellt.Add(category[0]);
			List<Category> listSport = new List<Category>();
			listSport.Add(category[1]);
			List<Category> listCulture = new List<Category>();
			listCulture.Add(category[2]);
			List<Category> listWorld = new List<Category>();
			listWorld.Add(category[3]);
			List<Category> listCars = new List<Category>();
			listCars.Add(category[4]);
			List<Category> listTravel = new List<Category>();
			listTravel.Add(category[5]);
			List<Category> listFood = new List<Category>();
			listFood.Add(category[6]);

			List<Author> authorTest = new List<Author>();
			authorTest.Add(authors[0]);
			List<Author> authorIbra = new List<Author>();
			authorIbra.Add(authors[1]);
			List<Author> authorNeveus = new List<Author>();
			authorNeveus.Add(authors[3]);


			//List<Category> listEva = new List<Category>();
			//listEva.Add(category[0]);
			//listEva.Add(category[6]);

			//List<Category> listPelle = new List<Category>();
			//listPelle.Add(category[1]);
			//listPelle.Add(category[3]);

			//List<Category> listSiv = new List<Category>();
			//listSiv.Add(category[2]);
			//listSiv.Add(category[4]);

			//List<Category> listLena = new List<Category>();
			//listLena.Add(category[7]);
			//listLena.Add(category[8]);

			//List<Subscriber> Subscribers = new List<Subscriber>
			//{
			//	new Subscriber{UserId=1,Categories=listEva},
			//	new Subscriber{UserId=2,Categories=listPelle},
			//	new Subscriber{UserId=3,Categories=listSiv},
			//	new Subscriber{UserId=4,Categories=listLena}

			//};
			//Subscribers.ForEach(i => context.Subscribers.Add(i));
			//context.SaveChanges();

			List<Article> Articles = new List<Article>{
				new Article{
					Title="Försvarsexpert: Putin vill visa musklerna",
					Preamble="Efter norsk storövning – rysk flotta i full stridsberedskap.",
					ArticleBody="<P><FONT face=\"Bookman Old Style\"><STRONG>38 000 ryska soldater och 41 örlogsfartyg sätts i stridsberedskap i en militär övning i Arktis. ”Ryssland vill visa musklerna. Det kan vara så att man vill markera mot den stora norska aktiviteten i området”, säger Stefan Ring, generalsekreterare i Allmänna försvarsföreningen.</STRONG></FONT> </P>"+
					"<IMG alt=\"Rabiessmittad hund som delikatess\" src=\"file:///"+ parentDirDirDir+"/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/putintal.jpg\">"+
					"<P>Enligt ryska nyhetsbyråer ska president Vladimir Putin ha gett order om att hela Norra flottan ska sättas i stridsberedskap. <BR>Försvarsminister Sergej Shoigu "+
					"säger samtidigt att Ryssland står inför nya hot som tvingar landet att öka sin militära styrka och kapacitet.<BR>"+
					"Kraftsamlingen kommer efter att Norge genomfört ”Joint Viking”, sin största militära övning sedan kalla kriget, i landets nordligaste provins Finnmark."+
					"5 000 norska soldater och 400 fordon har ingått i aktiviteten som hållits i det område som gränsar till den ryska Kolahalvön.</p>",
					CreatedDate=Convert.ToDateTime("2015-03-16 21:29:29.080"),
					UpdatedDate=Convert.ToDateTime("2015-03-16 21:29:29.080"),
					PublishDate=Convert.ToDateTime("2015-03-16 21:29:29.080"),
					IsApproved=true,
					Categories =listWorld,
					Authors=authorTest
				},
				new Article{
					Title="Rädslan växer för IS-terror i Sydostasien",
					Preamble="Annorlunda hotbild: ”Finns mängd potentiella måltavlor”",
					ArticleBody="<P><FONT face=\"Bookman Old Style\"><STRONG>Sydostasien höjer beredskapen för IS-inspirerade terrordåd. Hundratals människor har rest till Irak och Syrien för att ansluta till IS kamp och ett antal lokala extremistgrupper har svurit lojalitet till kalifatet.</STRONG></FONT> </P>"+
					"<DIV class=articletext><P></P><P><STRONG><IMG alt=\"Rädslan växer för IS-terror i Sydostasien \" "+
					"src=\"file:///"+ parentDirDirDir+"/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/IS.jpg\"></STRONG></P>"+
					"<P><STRONG>En grupp unga</STRONG> män kommer gående längs en strand. Vattnet är kristallklart. De bär kalasjnikovs och Islamiska Statens svartvita flagga. "+
					"I nästa klipp sitter de på knä i vattenbrynet.</P><P>– Vi är era bröder från Indonesien, säger en svartklädd man som kallar sig Abu Muhammad al Indonesi på bahasa. "+
					"Vi sänder våra salam till er alla.</P><P>Gradvis byter han sin kamratliga ton mot en känslostormande vädjan.</P><P>&nbsp;</P><P>– Var är er ilska när taghuf hånar Allah och hans "+
					"budbärare, ryter han och hytter med pekfingret mot kameran. Älskar ni ert hem, företag och välstånd mer än Allah, hans budbärare och jihad?</P></DIV>",
					CreatedDate=Convert.ToDateTime("2015-03-14 07:38:23.623"),
					UpdatedDate=Convert.ToDateTime("2015-03-14 07:38:23.623"),
					PublishDate=Convert.ToDateTime("2015-03-14 07:38:23.623"),
					IsApproved=true,
					Categories =listWorld,
					Authors=authorTest
				},
				new Article{
					Title="Rabiessmittad hund åts upp som delikatess",
					Preamble="Fyra vuxna och nio barn i Filippinerna vårdas efter att ha ätit kött från en rabiessmittad hund.",
					ArticleBody="<P><FONT face=\"Bookman Old Style\"><STRONG></STRONG></FONT>Hunden dog under oklara former i förra veckan i utkanten av staden Zamboanga, och först därefter upptäcktes det att den hade rabies. När lokalborna som hade hjälpt veterinären genom att skicka en del av hunden för analys fick veta att den hade rabies berättade de att de hade ätit upp resterna av den. </P>"+
					"<IMG alt=\"Rabiessmittad hund som delikatess\" src=\"file:///"+ parentDirDirDir+"/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/rabies.jpg\">"+
					"<p>Det är olagligt att slakta hundar för att äta dem i Filippinerna, men hundkött anses i vissa kretsar vara en delikatess.</p>",
					CreatedDate=Convert.ToDateTime("2015-03-15 13:06:38.680"),
					UpdatedDate=Convert.ToDateTime("2015-03-15 13:06:38.680"),
					PublishDate=Convert.ToDateTime("2015-03-15 13:06:38.680"),
					IsApproved=true,
					Categories =listFood,
					Authors=authorIbra
				},
				new Article{
					Title="Nya Suneboken utspelas i Ullared",
					Preamble="Sune i Ullared",
					ArticleBody="<P><FONT face=\"Bookman Old Style\"><STRONG></STRONG></FONT><IMG alt=Ullared src=\"file:///"+ parentDirDirDir+"/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/ullared.jpg\"></SPAN></P> </P>"+
					"Böckerna och filmerna om den busige Sune hör till de mest populära barn- och ungdomsböckerna de senaste 30 åren. I höstas startade en skrivartävling där barn och unga fick lämna förslag på vad nästa bok skulle handla om.<BR><BR> Av över 1 500 bidrag valdes en vinnaridé ut: den om att Sune ska åka till shoppingmeckat Ullared med sin familj."+
					"<BR><BR>Bakom idén står <STRONG>Jenny Bågenstål</STRONG>, 14, från Vällingby. <BR><BR>– Hennes förslag var klockrent, nästan som om vi kommit på det själva. Familjen Andersson representerar vanligheten och Ullared är bland det vanligaste man kan tänka sig."+
					"<BR><BR>– Vi såg genast bilder och situationer framför oss och kunde föreställa oss pappa Rudolf drabbas av shoppingbegär och handla trettiosex par jeans, säger Anders Jacobsson, som är författare till Suneböckerna tillsammans med Sören Olsson, i ett pressmeddelande."+
					"Jenny Bågenholm inspirerades både av tv-serien Ullared och av ett eget besök i somras.<p>Boken <EM>Sune i Ullared</EM> beräknas vara klar till Bokmässan i Göteborg i september.</p>",

		
					CreatedDate=Convert.ToDateTime("2015-03-15 13:08:20.940"),
					UpdatedDate=Convert.ToDateTime("2015-03-15 13:08:20.940"),
					PublishDate=Convert.ToDateTime("2015-03-15 13:08:20.940"),
					IsApproved=true,
					Categories =listCulture,
					Authors=authorIbra
				},

				new Article{
					Title="Mittfilskörare fick böter",
					Preamble="Mittfilskörare fick böter i Stockholm",
					ArticleBody="<P><FONT face=\"Bookman Old Style\"><STRONG></STRONG></FONT>Motormännen har vid flera tillfällen tagit upp problemet med förare som utan anledning ligger kvar i vänster- eller mittfilen på motorvägarna – och därmed ökar olycksrisken. </P>"+
					"<p>I februari gjorde polisen en riktad insats på E4/E20 mellan Södertälje och Botkyrka. 21 förare bötfälldes.</p><IMG alt=Mittfil src=\"file:///C:/code/WorkInProgress/Newsdesk/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/mittfil.jpg\">"+
					"<p>Bilister som inte håller till höger utan ligger kvar i mittfilen gör att omkörningarna blir komplicerade, långa, tidskrävande och farliga. </p>"+
					"<p>Under två dagar i början av februari 2015 bevakade fyra polispatruller den trefiliga vägen mellan Södertälje och Botkyrka med särskilt fokus på trafikanter som uppehöll sig i den mittersta filen. Totalt bötfälldes 21 förare: 19 som uppehöll sig i mittfilen och två som körde om i högerfilen.</p>"+
					"<p>Redan för drygt ett år sedan berättade Motor om trafiksituationen på motorvägen mellan Botkyrka och Södertälje.</p><p>– Ibland är det nästan tomt i högerfilen, sa dåvarande trafikpolischefen i Södertälje Michael Mathisen då.<BR>Kostnaden för utbyggnaden av motorvägssträckan var 350 miljoner kronor.</P>"+
					"<IMG alt=Vägarbete src=\"file:///C:/code/WorkInProgress/Newsdesk/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/vagbygge.jpg\">",
					CreatedDate=Convert.ToDateTime("2015-03-15 13:10:35.157"),
					UpdatedDate=Convert.ToDateTime("2015-03-15 13:10:35.157"),
					PublishDate=Convert.ToDateTime("2015-03-15 13:10:35.157"),
					IsApproved=true,
					Categories =listCars,
					Authors=authorIbra
				},
				
				new Article{
					Title="Tosca",
					Preamble="Göteborgsoperans Tosca",
					ArticleBody="<P><FONT face=\"Bookman Old Style\"><STRONG></STRONG></FONT> </P><P class=MsoNormal style=\"MARGIN: 0in 0in 10pt\"><SPAN lang=SV style=''FONT-SIZE: 12pt; FONT-FAMILY: \"Times New Roman\",serif; LINE-HEIGHT: 115%''>Floria Tosca följs i <B style=\"mso-bidi-font-weight: normal\">Lorenzo Marianis</B> uppsättning av en blodröd ridå signerad scenografen <B style=\"mso-bidi-font-weight: normal\">"+
					"Maurizio Baló</B>. Ridån förkunnar hennes entré och lämnar scenen svart och avgrundsdjup när hon försvinner ut i kulissen. Det är ”som om hon aldrig lämnat scenen, sin scen”, skriver regissören i programmet. Menar han att Tosca lever i sitt eget fiktiva universum? Fungerar ridån som ett par skygglappar som hindrar henne från att se var scenen tar slut och verkligheten börjar? "+
					"En sådan tolkning riskerar att göra Tosca till en slags docka som spelar upp sitt eget liv utan att egentligen leva det. Känslor eller handlingar blir varken äkta eller betydelsefulla utan blir ett spel, en illusion. Toscas bön är inte en bön utan bara en skådespelerska som spelar för att tillfredsställa Scarpias lystna blick, precis som vid en vanlig kväll på teatern. Marianis "+
					"oreflekterade regi går i just den riktningen. Den tar all möjlig udd av den veristiska tradition som Puccini så starkt trodde på. </SPAN></P>"+
					"<P class=MsoNormal style=\"MARGIN: 0in 0in 10pt\"><SPAN lang=SV style=''FONT-SIZE: 12pt; FONT-FAMILY: \"Times New Roman\",serif; LINE-HEIGHT: 115%''><o:p><IMG alt=Tosca src=\"file:///C:/code/WorkInProgress/Newsdesk/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/tosca.jpg\"></o:p></SPAN></P>"+
					"<P class=MsoNormal style=\"MARGIN: 0in 0in 10pt\"><SPAN lang=SV style=''FONT-SIZE: 12pt; FONT-FAMILY: \"Times New Roman\",serif; LINE-HEIGHT: 115%''>Även om Tosca visar sin sceniska talang så möter hon verkligheten som ett hårt slag i magen när hennes älskade Cavaradossi avrättas framför hennes ögon. Men inte ens då lämnar Mariani illusionen utan låter Tosca falla från Castel Sant’Angelo – ”Like a puppet on a string”. Toscas klänning glöder lika karmosinrött som ridån som följer henne. Stassen, signerad <B style=\"mso-bidi-font-weight: normal\">Silvia Aymonino</B>, ligger helt i linje med regissörens marionettlika tolkning av Tosca. Trots att handlingen är flyttad till 1930-talets fascism vandrar Tosca runt i en klänning med ett klassiskt empiresnitt. Själva tidsflytten skulle kunna uppfattas som ett försök att återskapa Puccinis veristiska ansats men känns tyvärr mest onödig. Förskjutningen i tid påverkar inte den övergripande tolkningen.<o:p></o:p></SPAN></P>"+
					"<P class=MsoNormal style=\"MARGIN: 0in 0in 10pt\"><SPAN lang=SV style=''FONT-SIZE: 12pt; FONT-FAMILY: \"Times New Roman\",serif; LINE-HEIGHT: 115%''>Marianis koncept haltar, det är snyggt att titta på men innehåller alltför många luckor och missar. Som tur är täcks detta upp med råge av <B style=\"mso-bidi-font-weight: normal\">Ingela Brimberg</B>, som inte gör ett enda misstag. Hon låter mig följa med i osäkerheten bakom divans mask. Där, bakom den kavata ytan, får verklighetens handlingar en kännbar påföljd. Långsamt sipprar allt det hon älskar och lever för bort. Att få följa den smärtsamma processen så tydligt frilagd som i Brimbergs Tosca är lika förförande som förfärande. Från första till sista ”Mario” klingar rösten likt en djupröd sammetsridå som sveper sig runt GöteborgsOperans stora salong. Höjden är stor, rik och dramatisk utan att förta subtila nyanser. Det är som balsam för öronen och jag vill bara ha mer. Jag förstår Scarpias åtrå. Brimberg förblir oemotsagd som föreställningens primadonna. Varken <B style=\"mso-bidi-font-weight: normal\">Tomas Linds</B> Cavaradossi eller <B style=\"mso-bidi-font-weight: normal\">Anders Lorentzsons</B> Scarpia rår på hennes Tosca. <o:p></o:p></SPAN></P><SPAN lang=SV style=''FONT-SIZE: 12pt; FONT-FAMILY: \"Times New Roman\",serif; LINE-HEIGHT: 115%; mso-fareast-font-family: \"Times New Roman\"; mso-fareast-theme-font: minor-fareast; mso-ansi-language: SV; mso-fareast-language: SV; mso-bidi-language: AR-SA''>Linds tunga tenor saknar spänsten och energin, vilket inte blir bättre av <B style=\"mso-bidi-font-weight: normal\">Shao-Chia Lüs</B> onödigt släpiga tempo i båda hans stora arior. Lorentzsons Scarpia hade behövt ännu fler demoniska egenskaper för att bli en värdig motståndare till Brimbergs eldklot till Tosca. Han blir aldrig en riktig fiende i andra aktens utdragna duell. Detta är Toscas föreställning, men långt mer än bara ett spel. Det är omöjligt att inte känna med Tosca. Djupt rörd lämnar jag föreställningen för att boka en ny biljett och ta reda på Ingela Brimbergs kommande engagemang.</P>",
					CreatedDate=Convert.ToDateTime("2015-03-15 13:10:35.157"),
					UpdatedDate=Convert.ToDateTime("2015-03-15 13:10:35.157"),
					PublishDate=Convert.ToDateTime("2015-03-15 13:10:35.157"),
					IsApproved=true,
					Categories =listCulture,
					Authors=authorIbra
				},
				new Article{
					Title="Landets bästa krog ligger inte i Stockholm",
					Preamble="Stockholm inte längre i topp",
					ArticleBody="<P>Nej, Stockholm var inte förloraren när restaurangguiden White guide prisade Sveriges krogar och kockar i Vinterträdgården på Grand Hôtel på måndagseftermiddagen. Det är fortfarande i huvudstaden som det finns störst möjlighet att äta bra. Ingen annanstans i landet finns lika många restauranger med ambition. Men, samtidigt visar listan över landets bästa krogar att något har hänt.<BR><BR>White guides inledande trendartikel har rubriken ”Vischan drar ifrån i toppen” och visst stämmer det om man ska utgå från den svenska restaurangguiden testpatrull.<BR><BR>nligt White guide är det i stället till Järpen, Östersund eller till Skåne Tranås som man bör bege sig för en måltid utöver det vanliga.<BR><BR>"+
					"Det var också Magnus Nilsson som driver Fäviken magasinet i Järpen, Östersund som var galans vinnare. Inte bara utsågs Fäviken till Årets bästa restaurang. Magnus Nilsson fick även, som första svensk någonsin, ta emot Global gastronomy award, en utnämning som tidigare gått till internationella gastronomiska storheter som Ferran Adrià (El Bulli, Spanien), Massimo Bottura (Osteria Francescana, Italien) och René Redzepi (Noma, Danmark.<BR><BR>"+
					"En snabb genombläddring av White guide visar att man tänker på ett helt annat sätt än Michelinguiden vars nordiska upplaga lanserades för en dryg vecka sedan. Att de är konkurrenter råder det ingen tvekan om och där den röda guiden valt bort krogar utanför Stockholm, Göteborg och Malmö så väljer den vita guiden att i högre grad än någonsin uppmärksamma restauranger utanför städerna. På så vis får de båda existensberättigande.>BR>"+
					"Men det är också intressant att de värderar krogarna så olika. Att till exempel Volt, som i år fick sin första Michelinstjärna, hamnar på 31:a plats på Mästerklasslistan i White guide, efter Pubologi, Råkultur och Nook – bra ställen men som rimligtvis inte är nära att tilldelas en stjärna.<BR><BR>"+
					"Och att Esperanto som fortsätter att ha en Michelinstjärna, i White guide, hamnar före både Frantzén, Oaxen krog och Mathias Dahlgren Matsalen, alla med två Michelinstjärnor, visar att provätarna hos respektive guiderna tänker lite olika.<BR><BR>Det bästa som White guide visar på är ändå att Sverige som matland växer. Och det är i Göteborg det bubblar mest. Med Gothia towers upper house och Koka återfinns två Göteborgsrestauranger på den internationella mästarklasslistan. Bhoga, Swedish taste, Linnea art restaurant och Hoze ligger hack i häl.<BR><BR>"+
					"Sedan kan man ju tycka att utvecklingen borde gå lite snabbare, att det skulle vara något enklare att hitta ställen som serverar riktigt bra mat utanför storstäderna.</P>",
					CreatedDate=Convert.ToDateTime("2015-03-15 13:13:56.873"),
					UpdatedDate=Convert.ToDateTime("2015-03-15 13:13:56.873"),
					PublishDate=Convert.ToDateTime("2015-03-15 13:13:56.873"),
					IsApproved=true,
					Categories =listCulture,
					Authors=authorIbra
				},
				new Article{
					Title="”Top Gear”-stjärnan avstängd",
					Preamble="På obestämd tid.",
					ArticleBody="<IMG alt=Top src=\"file:///"+ parentDirDirDir+"/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/gear.jpg\"><P><FONT face=\"Bookman Old Style\"><STRONG>Ett av brittiska BBC:s mest inkomstbringande program har lagts på is sedan programledaren Jeremy Clarkson anklagats för att ha slagit en av producenterna. ”Top Gear” ses av 350 miljoner tittare över hela världen.</STRONG></FONT> </P>"+
					"<P>Söndagens ”Top Gear” var inspelat och klar att sändas men tittarna får i stället zappa sig fram till något annat program. BBC, som äger rättigheterna, har valt att ställa in programmet de följande två veckorna.</P>"+
					"<P>Enligt Sky News ska den 54-årige programledaren Jeremy Clarkson ha försökt att slå ned producenten Oisin Tymon sedan den mat som skulle ha serverats efter en lång arbetsdag inte fanns på plats. Vad som egentligen hände ska nu utredas och fram tills utredningen är klar kommer Clarkson inte att leda programmet.</P>",
					CreatedDate=Convert.ToDateTime("2015-03-15 13:15:31.863"),
					UpdatedDate=Convert.ToDateTime("2015-03-15 13:15:31.863"),
					PublishDate=Convert.ToDateTime("2015-03-15 13:15:31.863"),
					IsApproved=true,
					Categories =listCars,
					Authors=authorIbra
				},
		
			new Article{
					Title="Zlatan utvisad men PSG vidare",
					Preamble="Det har pratats om en förbannelse, den att han aldrig lyckats vinna Champions League.",
					ArticleBody="<P>När Ibrahimovic med sänkt huvud lommade av Stamford Bridge redan efter en dryg halvtimma var det lätt att dra den förhastade slutsatsen att där försvann i praktiken PSG:s möjligheter att passera Chelsea och stå som ett av åtta lag i Champions Leagues kvartsfinaler.</P>"+
					"<P >Med en man mindre tvingade PSG fram förlängning, kvitterade till 2–2 med sex minuter kvar, höll undan och gick vidare tack vare 3–3 och bortamålsregeln.</SPAN></P>"+
					"<P ><o:p><IMG alt=\"Zlatan PSG\" src=\"file:///"+ parentDirDirDir+"/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/Zlatan.jpg\"></o:p></SPAN></P>"+
					"<p>Var det rött kort?<o:p></o:p></SPAN></P><P >Men först frågorna som omedelbart ställdes i 31:a minuten och diskuterades framför tv- och radioapparater, datorer, på twitter, i liverapporteringar, paddor, mobiltelefoner eller via vilka plattformar folk numera än väljer när de följer den internationella toppfotbollen:<o:p></o:p></SPAN></P>"+
					"<P>Så var inte fallet.<o:p></o:p></SPAN></P><P>Gjorde den nederländske domaren Björn Kuipers rätt?<o:p></o:p></SPAN></P><P>Hade det inte räckt med en varning?<o:p></o:p></SPAN></P>"+
					"<P>Tvekade inte<o:p></o:p></SPAN></P><P>Det här hände:<o:p></o:p></SPAN></P><P>Chelseas brasilianare Oscar kom från ett håll, Ibrahimovic från ett annat. Oscar var först på bollen, men strax innan frontalkrocken gjorde Ibrahimovic vad han kunde för att inte träffa med dobbarna. Det såg ut som han lyckades, men han rammade i full fart Oscar som på klassiskt fotbollslatinskt manér vred sig i smärtor som om han blivit överkörd av ett tåg med ena foten på rälsen.<o:p></o:p></SPAN></P>"+
					"<P>Kuipers tvekade inte. Kortet halades upp snabbt. Och för fjärde gången i Champions League-sammanhang skickade en domare Ibrahimovic av planen.<o:p></o:p></SPAN></P><P>Stolpskott av Cavani<o:p></o:p></SPAN></P>"+
					"<P>Kompensation eller inte, men innan halvleken var över blundade Kuipers när Edinson Cavani trippade Diego Costa i straffområdet. José Mourinho, Chelseas manager, slog sittande i sin fåtölj ut med händerna och hånflinade som om han tänkte att den inhemska domarkonspiration han fått på hjärnan nu även nått kontinenten.<o:p></o:p></SPAN></P>"+
					"<P>Med en man mer och 1–1 att luta sig mot från Parc des Princes för tre veckor sedan, försökte Chelsea stänga butiken. Då höll Cavani så när på att bryta upp dörren. Han rundade Thibaut Courtois men prickade ur snäv vinkel stolpen i stället för det övergivna målet.<o:p></o:p></SPAN></P>"+
					"<P>Kuipers fick nya problem. Costa satte in en elak tackling på Thiago Silva, men fick bara gult kort till PSG-spelarnas vrede.<o:p></o:p></SPAN></P>"+
					"<P>Thiago Silva avgjorde<o:p></o:p></SPAN></P><P>Med tio minuter drämde Gary Cahill in 1–0 men David Luiz stenhårda nick sex minuter senare, under PSG:s desperata jakt, ordnade kvitteringen som gav förlängning. Sex minuter in i den tog Thiago Silva bollen klumpigt med handen och Eden Hazard slog in straffen.<o:p></o:p></SPAN></P>"+
					"<P>Det var inte över där.<o:p></o:p></SPAN></P><P>Mitt i den andra förlängningskvarten tvingade Thiago Silva med sin nick Courtois till en fenomenal räddning till hörna. På den lyfte brasilianaren igen och nickade in kvitteringen som tog Paris till kvartsfinal.<o:p></o:p></SPAN></P>"+
					"<P>Zlatan Ibrahimovics eviga strävan efter Champions League-pokalen lever åtminstone en månad till. Domaren Björn Kuipers visar det röda kortet för Zlatan Ibrahimovic redan i 31:a minuten men Paris gick vidare efter förlängning trots en man mindre i 90 minuter.</p>", 
					CreatedDate=Convert.ToDateTime("2015-03-14 07:29:29.080"),
					UpdatedDate=Convert.ToDateTime("2015-03-14 07:29:29.080"),
					PublishDate=Convert.ToDateTime("2015-03-14 07:29:29.080"),
					IsApproved=true,
					Categories =listSport,
					Authors=authorNeveus
				},
			
			new Article{
					Title="Tjuvaktiga turister",
					Preamble="När semesterfotot inte räcker till",
					ArticleBody="<P>Förra veckan greps två amerikanska turister som hade ristat in sina initialer på Colosseum i Rom. De är inte ensamma om att ha vandaliserat historiska sevärdheter.<BR>För några år sedan nöjde sig inte en finsk turist med att fotografera ta bilder på Påskön, utan bröt dessutom av ett öra från en av ön kända monument. Mannen greps och fick motsvarande cirka 110 000 kronor i böter.</P>"+
					"<P><IMG alt=\"Tjuvar på resa\" src=\"file:///"+ parentDirDirDir+"/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/påskön.jpg\"></P>",
					CreatedDate=Convert.ToDateTime("2015-03-15 13:19:44.467"),
					UpdatedDate=Convert.ToDateTime("2015-03-15 13:19:44.467"),
					PublishDate=Convert.ToDateTime("2015-03-15 13:19:44.467"),
					IsApproved=true,
					Categories =listTravel,
					Authors=authorNeveus
				},
			new Article{
					Title="Plan kraftigt försenat",
					Preamble="Piloten behövde sova",
					ArticleBody="<P><IMG alt=\"Försenat flyg\" src=\"file:///"+ parentDirDirDir+"/NewsdeskWPFClient/NewsdeskWPFClient/ArticleImages/airFrance.jpg\"></P>"+
					"<P>Air France-flighten från New York till Paris i måndags kom iväg sex timmar efter avsatt tid på grund av att planet, en Airbus 380, behövdes isas av. Väl i luften trodde nog de 440 passagerarna att det värsta var över. Men så var icke fallet.</P>"+
					"<P>Med den franska huvudstaden bara en timma bort meddelade piloten att han var tvungen att styra om planet och landa Manchester istället. Orsaken var att han hade varit i tjänst för länge och enligt flygbolagets regler därför var tvungen att sova, skriver nyhetssajten The Local.</P>",
					CreatedDate=Convert.ToDateTime("2015-03-15 13:21:10.990"),
					UpdatedDate=Convert.ToDateTime("2015-03-15 13:21:10.990"),
					PublishDate=Convert.ToDateTime("2015-03-15 13:21:10.990"),
					IsApproved=true,
					Categories =listTravel,
					Authors=authorNeveus
				},
					
			//new Article{
				//	Title="",
				//	Preamble="",
				//	ArticleBody="<P><FONT face=\"Bookman Old Style\"><STRONG></STRONG></FONT> </P>"+
				//	""+
				//	"",
				//	CreatedDate=Convert.ToDateTime("2015-03-14 07:29:29.080"),
				//	UpdatedDate=Convert.ToDateTime("2015-03-14 07:29:29.080"),
				//	PublishDate=Convert.ToDateTime("2015-03-14 07:29:29.080"),
				//	IsApproved=true,
				//	Categories =listWorld,
				//	Authors=Authors
				//},
			
			};
			Articles.ForEach(i => context.Articles.Add(i));
			context.SaveChanges();

		}
	}
}