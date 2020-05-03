using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Threading.Tasks;
using Database_Api;

namespace Checkpoint_WCircus
{
    /// <summary>
    /// Interaction logic for TamersControl.xaml
    /// </summary>
    public partial class TamersControl : UserControl
    {
        private int maxNumber;
        private int currentNumber = 0;
        private List<Tamer> tamers;
        private DbPopulator dbPopulator = new DbPopulator();

        public TamersControl()
        {
            InitializeComponent();
            previousImageButton.IsEnabled = false;
        }

        private void previousImageButton_Click(object sender, RoutedEventArgs e)
        {
            nextImageButton.IsEnabled = true;
            currentNumber -= 1;
            if (currentNumber == 0)
                previousImageButton.IsEnabled = false;
            this.DataContext = tamers[currentNumber];
        }

        private void nextImageButton_Click(object sender, RoutedEventArgs e)
        {
            previousImageButton.IsEnabled = true;
            currentNumber += 1;
            if (currentNumber == maxNumber)
                nextImageButton.IsEnabled = false;
            this.DataContext = tamers[currentNumber];
        }

        private void spiritAnimal_Click(object sender, RoutedEventArgs e)
        {
            int animalId = tamers[currentNumber].SpiritAnimal.SpiritAnimalId;
            var animalControl = new AnimalsUserControl(animalId - 1);
            this.Content = animalControl;
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            RadioButton animalButton = (RadioButton)mainWindow.FindName("animalsButton");
            animalButton.IsChecked = true;
        }

        private async Task LoadTamers()
        {
            tamers = await dbPopulator.GetTamersDataAsync();
            this.DataContext = tamers[currentNumber];
            maxNumber = tamers.Count - 1;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadTamers();
        }
    }
}
