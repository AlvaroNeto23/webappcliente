namespace WebAppCliente.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public byte Logotipo { get; set; }
        public bool IsActive { get; set; }
    }
}
