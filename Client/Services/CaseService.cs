using thorstopper.Client.Data;

namespace thorstopper.Client.Services;

public interface ICaseService
{
	public Task<IEnumerable<Case>> GetCases();
}

public class CaseService : ICaseService
{
	private List<Case> _list = new() {
		new Case() { CaseNumber = 1, CaseName = "Sturmwind Schaden Dach & Fassade", Address = "Scheuermattweg 8, 3007 Bern", Lat = 46.941560, Lng = 7.425820,
			CustomerName = "Tom Tommasson", Date = DateTime.Now, Bounty = null, CaseDescription = @"Sehr geehrte Damen und Herren des Versicherungsteams,

ich möchte hiermit einen Schaden an meinem Haus melden, der durch den jüngsten Sturm verursacht wurde. Am [Datum] fegte ein heftiger Sturm über unser Gebiet hinweg und hat dabei erhebliche Schäden an meinem Dach verursacht. Ich bin Inhaber der Gebäudeversicherung mit der Vertragsnummer [Vertragsnummer] und versichere, dass ich sämtliche erforderlichen Schritte unternehme, um den Schaden zu begrenzen und zu dokumentieren.

Der Sturm hat mehrere Dachziegel abgelöst und einige davon sogar vom Dach geweht. Dadurch ist das Dach stark beschädigt und es besteht die Gefahr von Wassereintritt bei Regen. Der Schaden betrifft sowohl die Dachbedeckung als auch die darunterliegende Dachstruktur. Ich habe bereits vorübergehende Maßnahmen ergriffen, um den Schaden so gut wie möglich abzusichern und das Eindringen von Wasser zu verhindern.

Ich bitte um Anleitung, wie ich nun am besten vorgehen soll. Welche Informationen benötigen Sie von meiner Seite, um den Schaden zu begutachten und die notwendigen Schritte einzuleiten? Ich stehe zur Verfügung, um Fotos vom Schaden hochzuladen und weitere Informationen zur Verfügung zu stellen, sobald ich weiß, welche Schritte von mir erwartet werden.

Ich hoffe auf eine zügige Bearbeitung meiner Meldung, um weitere Schäden am Gebäude zu verhindern. Für Rückfragen stehe ich gerne zur Verfügung. Ich danke Ihnen im Voraus für Ihre Unterstützung und schnelle Erledigung.

Mit freundlichen Grüßen,
[Name]
[Kontaktinformationen]"},
		new Case() { CaseNumber = 2, CaseName = "Sturmschäden Dach & Kamin", Address = "Kapellenstrasse 26, 3011 Bern", Lat = 46.945420,
			Lng = 7.433950, CustomerName ="Peter Musterman", Date = DateTime.Now, Bounty = null, CaseDescription = @"Sehr geehrtes Versicherungsteam,

ich wende mich umgehend an Sie, um einen erheblichen Schaden an meinem Haus zu melden, der durch den kürzlich aufgetretenen Sturm verursacht wurde. Ich bin Inhaber der Gebäudeversicherung mit der Nummer [Vertragsnummer]. Der Sturm hat schwere Verwüstungen angerichtet und das Dach meines Hauses stark beschädigt. Es wurden nicht nur zahlreiche Dachziegel abgerissen, sondern auch Teile der Dachstruktur wurden in Mitleidenschaft gezogen.

Die Ausmaße des Schadens sind beträchtlich, und es ist dringend erforderlich, Maßnahmen zu ergreifen, um weiteren Wassereintritt und Folgeschäden zu verhindern. Ich habe vorübergehende Sicherungsmaßnahmen ergriffen, jedoch bedarf es einer professionellen Begutachtung und Reparatur des Daches, um die Stabilität des Hauses wiederherzustellen.

Ich bitte um rasche Unterstützung, um den Schaden zu beheben und weitere Schäden zu minimieren. Bitte teilen Sie mir mit, welche Schritte ich unternehmen sollte und welche Informationen Sie von mir benötigen, um den Prozess in Gang zu setzen. Ich stehe bereit, um Fotos, eine Schadensbeschreibung und alle erforderlichen Dokumente zur Verfügung zu stellen.

Vielen Dank für Ihre prompte Reaktion und Hilfe in dieser Angelegenheit.

Mit freundlichen Grüßen,
[Name]
[Kontaktinformationen]"},
		new Case() { CaseNumber = 3, CaseName = "S Dach hets glupft", Address = "Lindenhofstrasse 1, 3048 Worblaufen", Lat = 46.979641,
			Lng = 7.460920, CustomerName = "Hans Muster", Date = DateTime.Now, Bounty = true, CaseDescription = @"Sehr geehrtes Team der Gebäudeversicherung,

ich melde hiermit einen Schaden an meinem Haus, der durch den kürzlich aufgetretenen Sturm verursacht wurde. Als Versicherungsnehmer mit der Vertragsnummer [Vertragsnummer] möchte ich Sie über die Schadenssituation informieren und um entsprechende Schritte bitten.

Während des Sturms wurden einige Dachziegel von meinem Haus abgelöst, was zu einem Schaden an der Dachbedeckung geführt hat. Glücklicherweise scheint die Dachstruktur nicht stark beeinträchtigt zu sein, und es gibt bisher keinen Wassereintritt. Dennoch bin ich besorgt über mögliche Folgeschäden, wenn der Schaden nicht zeitnah behoben wird.

Ich habe bereits vorläufige Maßnahmen ergriffen, um den Schaden einzudämmen, bis professionelle Reparaturen durchgeführt werden können. Gerne stehe ich bereit, um Ihnen Fotos des Schadens zukommen zu lassen und alle erforderlichen Informationen zu liefern, um den Schaden zu begutachten und die Reparatur zu planen.

Ich bitte um Anleitung, wie wir am besten vorgehen sollten, um den Schaden zu beheben und weitere Probleme zu vermeiden. Vielen Dank im Voraus für Ihre Unterstützung.

Mit freundlichen Grüßen,
[Name]
[Kontaktinformationen]"},
	};

	public async Task<IEnumerable<Case>> GetCases()
	{
		return _list;
	}
}