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

namespace RestaurantHelper.CustomDialog
{
    /// <summary>
    /// Lógica de interacción para CustomConfirmacion.xaml
    /// </summary>
    public partial class CustomConfirmacion : Window
    {
        public CustomConfirmacion()
        {
            InitializeComponent();
        }

        public bool? Modificar { get; private set; }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            Modificar = true;
            this.DialogResult = true;
        }

        private void TerminateButton_Click(object sender, RoutedEventArgs e)
        {
            Modificar = false;
            this.DialogResult = true;
        }
    }
}
