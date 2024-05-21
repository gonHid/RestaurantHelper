using RestaurantHelper.Models;
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
		private Mesa mesa;
		public VentanaComanda(Mesa mesa)
		{
			this.mesa = mesa;	
			InitializeComponent();
		}


	}
}
