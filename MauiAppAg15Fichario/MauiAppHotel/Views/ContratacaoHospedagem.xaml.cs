using MauiAppHotel.Models;
using System.Data;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage

    {

    App PropriedadesApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();
        PropriedadesApp = (App)Application.Current;

        pck_quadra.ItemsSource = PropriedadesApp.Lista_quartos;
        pck_esporte.ItemsSource = PropriedadesApp.Lista_esportes;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(1);
        dtpck_checkin.Date = DateTime.Now;

        dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
        dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(2);
        dtpck_checkout.Date = DateTime.Now.AddDays(1);
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new PaginaSobre());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                QuadraSelecionada = (Quarto) pck_quadra.SelectedItem,
                Qntparticipantes = Convert.ToInt32(stp_participantes.Value),
               EsporteSelecionado = (Esporte)pck_esporte.SelectedItem,
                DataCheckIn = dtpck_checkin.Date.Value,
                DataCheckOut = dtpck_checkout.Date.Value,

            };


            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h

            });
                
                }
        catch (Exception ex)
        {
            await DisplayAlert("ops", ex.Message, "OK");

        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {

        DateTime data_in = e.NewDate ?? DateTime.Now;

        //dtpck_checkout.Date = data_in.AddDays(1);

        dtpck_checkout.MinimumDate = data_in.AddDays(1);

        dtpck_checkout.MaximumDate = data_in.AddMonths(2);

        if(dtpck_checkout.Date > dtpck_checkout.MaximumDate || dtpck_checkout.MinimumDate < data_in)
        {
            Dispatcher.Dispatch(() =>
            {
                dtpck_checkout.Date = data_in.AddDays(1);
            });
        }
    }

    private void dtpck_checkout_DateSelected(object sender, DateChangedEventArgs e)
    {


        if (dtpck_checkout.Date > dtpck_checkout.MaximumDate || dtpck_checkout.MinimumDate < ((DateTime)dtpck_checkin.Date))
        {
            Dispatcher.Dispatch(() =>
            {
                dtpck_checkout.Date = ((DateTime)dtpck_checkin.Date).AddDays(1);
            });
        }
    }
}