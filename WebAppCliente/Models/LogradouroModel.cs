namespace WebAppCliente.Models
{
    public class LogradouroModel
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// Relacionamento Logradouro-Cliente
        /// </summary>
        public int? ClienteId { get; set; }
        public virtual ClienteModel? Cliente { get; set; }
    }
}
