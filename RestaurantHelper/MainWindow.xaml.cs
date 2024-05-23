using RestaurantHelper.Models;
using RestaurantHelper.Repository;
using RestaurantHelper.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantHelper
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>

    public partial class MainWindow : Window
    {
		private readonly MesaService mesaService;
		public MainWindow()
        {
            InitializeComponent();
			mesaService = new MesaService();

			List<Mesa> mesas = new List<Mesa>();
			for (int i=0;i<=30;i++)
			{
				Mesa mesa = new Mesa();
				mesa.Id = i;
				mesas.Add(mesa);
			}
			GenerarMesas(mesas);
        }

		private void GenerarMesas(List<Mesa> mesas)
		{
			//List<Mesa> mesas = mesaRepository.GetAll();
			foreach (var mesa in mesas)
			{
				// Crear un nuevo botón
				Button button = new Button
				{
					Content = mesa.Id.ToString(),
					Width = 300,
					Height = 280,
					Margin = new Thickness(10),
					Name = "Mesa" + mesa.Id.ToString()
				};
				button.Click += Button_Click;
				button.FontSize = 30;
				// Agregar el botón al contenedor
				ContenedorMesas.Children.Add(button);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (sender is Button button)
			{
				Mesa mesaSelected = mesaService.GetMesaByID(Convert.ToInt32(button.Content));//STRING -> INT
				if (mesaSelected.Id == 0) {
					MessageBox.Show($"¡Has hecho clic en la mesa {button.Content}!");
					//ABRIR VENTANA PARA CREAR MODIFICAR O TERMINAR COMANDAS
					VentanaComanda ventana = new VentanaComanda(mesaSelected);
					ventana.Show();
					//Recargar mesas 
				}
				else
				{
					MessageBox.Show($"¡la mesa {button.Content} no existe!");
				}
			}
		}


	}
}