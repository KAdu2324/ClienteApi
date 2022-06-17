using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClienteApi.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Nome")]
        
        public string Nome { get; set; } = string.Empty;
        [BsonElement("Cpf")]
        public string Cpf { get; set; } = string.Empty;
        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;
        [BsonElement("Endereço")]
        public string Endereco { get; set; } = string.Empty;
        [BsonElement("Contato")]
        public string Contato { get; set; } = string.Empty;
        [BsonElement("Status")]
        public bool Status { get; set; }

      
        
          
        
    }
}
