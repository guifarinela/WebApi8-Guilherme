using WebApi8_Guilherme.Migrations;

namespace WebApi8_Guilherme.Models
{
    public class ResponseModel<T>
    {
    public T? Dados { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    }
}

