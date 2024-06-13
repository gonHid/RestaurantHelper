using RestaurantHelper.Models;
using RestaurantHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantHelper
{
	/// <summary>
	/// Lógica de interacción para VentanaComanda.xaml
	/// </summary>
	public partial class VentanaComanda : Window
	{
        private readonly ComandaService comandaService;
        private readonly PedidoComandaService pedidoComandaService;
        private Mesa mesa;
		private Comanda comanda;
		private List<PedidoComanda> pedidoComanda;
		public VentanaComanda(Mesa mesa)
		{
			comandaService = new ComandaService();
			pedidoComandaService = new PedidoComandaService();	
			this.mesa = mesa;	
			InitializeComponent();
			//Obtener datos de la mesa + comanda
			comanda = comandaService.GetComandaByID(mesa.ComandaActualId);// Probar sacando directo mesa.ComandaActual
            pedidoComanda = pedidoComandaService.GetPedidoComandaByID(mesa.ComandaActualId);
            //Recargar info en ventana

        }


	}
}
