
using MauiAppHotel.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public List<Quarto> Lista_quartos = new List<Quarto>
        {
            new Quarto()
            {
                Descricao = "Quadra de areia",
                ValorDiaria = 12.0
                
            },

             new Quarto()
            {
                Descricao = "Campo de grama",
                ValorDiaria = 20.0,
               
            },
             new Quarto()
            {
                Descricao = "Quadra de cimento",
                ValorDiaria = 6.0,
               
            },
              new Quarto()
            {
                Descricao = "Quadra de tacos",
                ValorDiaria = 16.0,
               
            }
        };
        public List<Esporte> Lista_esportes = new List<Esporte>
        {
            new Esporte()
            {
                DescricaoEsporte = " Jogo de Queimada",
               

            },

             new Esporte()
            {
                DescricaoEsporte = " Jogo de Basquete",
            

            },
             new Esporte()
            {
                DescricaoEsporte = " Jogo de Volei",
               

            },
              new Esporte()
            {
                DescricaoEsporte = " Jogo de Futebol",
                

            }
        };

        public App()
        {
            InitializeComponent();



            MainPage = new NavigationPage(new Views.ContratacaoHospedagem());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 750;
            return window;
        }
    }
}