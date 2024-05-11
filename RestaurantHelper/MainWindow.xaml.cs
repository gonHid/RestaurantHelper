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
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new RestaurantContext())
            {
               
                // Crear un nuevo usuario
                var nuevoUsuario = new Usuario
                {
                    Rut = "12345678-9", // Ejemplo de Rut
                    Nombre = "Nuevo Usuario",
                    CategoriaId = 1, // Ejemplo de categoría
                    Estado = 1, // Ejemplo de estado
                    Password = "password" // Ejemplo de contraseña
                };

                if (context.Usuarios.FirstOrDefault(x=>x.Estado == 1) == null)
                {
                    // Agregar el usuario a la base de datos
                    context.Usuarios.Add(nuevoUsuario);
                    context.SaveChanges();
                    MessageBox.Show("Usuario agregado correctamente.");
                }

                foreach (var user in context.Usuarios.ToList())
                {
                    texto.Text += user.Nombre;
                }

                
            }

        }
    }
}