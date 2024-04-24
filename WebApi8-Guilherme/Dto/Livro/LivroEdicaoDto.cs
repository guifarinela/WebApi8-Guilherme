using WebApi8_Guilherme.Dto.Vinculo;
using WebApi8_Guilherme.Models;

namespace WebApi8_Guilherme.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
