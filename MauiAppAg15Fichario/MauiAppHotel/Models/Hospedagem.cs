namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuadraSelecionada {  get; set; }
        public Esporte EsporteSelecionado { get; set; }

        public int Qntparticipantes{  get; set; }

       
        public DateTime DataCheckIn { get; set; }

        public DateTime DataCheckOut { get; set; }
    
        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;

        }

        public double ValorTotal
        {
            get
            {
                double valor_adultos = Qntparticipantes * QuadraSelecionada.ValorDiaria;            

                double total = (valor_adultos ) * Estadia;

                return total;
            }
        }

    }
}
