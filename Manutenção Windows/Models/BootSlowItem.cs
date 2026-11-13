namespace Manutenção_Windows.Models

/**
 *
 * @author Daniel Arantes Telles
 */

{
    public class BootSlowItem
    {
        public string Nome { get; set; }
        public string Tipo { get; set; } // "Aplicativo", "Driver" ou "Serviço"
        public double DuracaoMs { get; set; }
        public int EventId { get; set; }
    }
}
