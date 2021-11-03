using System.Text;

namespace DesafioTecnicoFramework
{
    public class Numeros
    {
        public StringBuilder Divisores { get; set; }
        public StringBuilder Primos { get; set; }
        public int Entrada { get; set; }

        public Numeros()
        {
            Divisores = new StringBuilder();
            Primos = new StringBuilder();
        }
    }
}
