using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using Database_Api;

namespace Checkpoint_WCircus
{
    /// <summary>
    /// Interaction logic for AnimalsUserControl.xaml
    /// </summary>
    public partial class AnimalsUserControl : UserControl
    {
        private int maxNumber;
        private int currentNumber;
        private List<SpiritAnimal> animals;
        private DbPopulator dbPopulator = new DbPopulator();

        public AnimalsUserControl(int currNum = 0)
        {
            InitializeComponent();
            currentNumber = currNum;
        }

        private void previousImageButton_Click(object sender, RoutedEventArgs e)
        {
            nextImageButton.IsEnabled = true;
            currentNumber -= 1;
            if (currentNumber == 0)
                previousImageButton.IsEnabled = false;
            this.DataContext = animals[currentNumber];
        }

        private void nextImageButton_Click(object sender, RoutedEventArgs e)
        {
            previousImageButton.IsEnabled = true;
            currentNumber += 1;
            if (currentNumber == maxNumber)
                nextImageButton.IsEnabled = false;
            this.DataContext = animals[currentNumber];
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadAnimals();
        }

        private async Task LoadAnimals()
        {
            animals = await dbPopulator.GetAllAnimalsAsync();
            this.DataContext = animals[currentNumber];
            maxNumber = animals.Count - 1;
            if (currentNumber == 0)
                previousImageButton.IsEnabled = false;
            else if (currentNumber == maxNumber)
                nextImageButton.IsEnabled = false;
        }
    }
}
