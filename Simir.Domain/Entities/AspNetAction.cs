namespace Simir.Domain.Entities
{
    public class AspNetAction : AspNetModulo
    {
        public string Nome { get; set; }
        public int AspNetControllerId { get; set; }
        public virtual AspNetController AspNetController { get; set; }

        public string GetUrl()
        {
            return AspNetController.Nome + Nome;
        }
    }
}