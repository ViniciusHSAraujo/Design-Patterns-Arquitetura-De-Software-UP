
namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Singleton {
    public class TicketNumber {

        private TicketNumber() { }

        private static TicketNumber _instance;

        private int TicketAtual = 0;

        public static TicketNumber GetInstance() {
            if (_instance == null) {
                _instance = new TicketNumber();
            }
            return _instance;
        }

        public int GetNextTicket() {
            TicketAtual++;
            return TicketAtual;
        }
    }
}
