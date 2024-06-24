namespace AuthenticationNote.Models.Entidades
{
    public class Nota
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataNote { get; set; }
    }
}
