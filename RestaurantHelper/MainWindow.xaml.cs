using RestaurantHelper.Models;
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
        public MainWindow()
        {
            InitializeComponent();
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
			foreach (var mesa in mesas)
			{
				// Crear un nuevo botón
				Button button = new Button
				{
					Content = mesa.Id.ToString(),
					Width = 400,
					Height = 300,
					Margin = new Thickness(10),
					Name = "Mesa" + mesa.Id.ToString()
				};
				button.Click += Button_Click;
				// Agregar el botón al contenedor
				ContenedorMesas.Children.Add(button);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// Esta función se ejecuta cuando se haga clic en cualquier botón generado dinamicamente
			var button = sender as Button;
			if (button != null)
			{
				MessageBox.Show($"¡Has hecho clic en la mesa {button.Content}!");
				// Aquí puedes agregar la lógica que desees realizar cuando se hace clic en un botón
			}
		}


	}
}