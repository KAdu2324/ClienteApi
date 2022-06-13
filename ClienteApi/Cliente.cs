namespace ClienteApi
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string CPF { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Endereço { get; set; } = String.Empty;

        public string Contato { get; set; } = String.Empty;
        public string Status { get; set; } = String.Empty;
    }
}
