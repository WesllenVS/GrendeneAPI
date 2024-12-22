namespace MakeupAPI.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set;}
        public bool Status { get; set; }  = true;
        public string Mensagem { get; set; } = String.Empty;
    }
}
