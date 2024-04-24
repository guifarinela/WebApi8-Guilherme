using System.Text.Json.Serialization;

namespace WebApi8_Guilherme.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public ICollection<LivroModel> Livros  { get; set; }

    }
}
