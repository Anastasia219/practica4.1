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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica4._1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Sech.xaml
    /// </summary>
    public partial class Sech : Page
    {

        private Point mouseOffset;
        private bool isDragging = false;
        private UIElement draggedElement;


        public Sech()
        {
            InitializeComponent();
            
        }

        private void WorkshopComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // При изменении выбранного цеха можно добавить логику загрузки соответствующего плана (пока просто очищаем)
            PlanCanvas.Children.Clear();
        }

        private void AddEquipmentBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var equipment = new Rectangle { Width = 20, Height = 20, Fill = Brushes.Blue };
                PlanCanvas.Children.Add(equipment);
                Point position = e.GetPosition(PlanCanvas);
                Canvas.SetLeft(equipment, position.X);
                Canvas.SetTop(equipment, position.Y);
                equipment.MouseLeftButtonDown += PlanCanvas_MouseLeftButtonDown;
            }
        }

        private void AddExtinguisherBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var extinguisher = new Ellipse { Width = 20, Height = 20, Fill = Brushes.Red };
                PlanCanvas.Children.Add(extinguisher);
                Point position = e.GetPosition(PlanCanvas);
                Canvas.SetLeft(extinguisher, position.X);
                Canvas.SetTop(extinguisher, position.Y);
                extinguisher.MouseLeftButtonDown += PlanCanvas_MouseLeftButtonDown;
            }
        }

        private void AddFirstAidBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var firstAid = new Rectangle { Width = 20, Height = 20, Fill = Brushes.Green };
                PlanCanvas.Children.Add(firstAid);
                Point position = e.GetPosition(PlanCanvas);
                Canvas.SetLeft(firstAid, position.X);
                Canvas.SetTop(firstAid, position.Y);
                firstAid.MouseLeftButtonDown += PlanCanvas_MouseLeftButtonDown;
            }
        }

        private void PlanCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedElement != null)
            {
                Point mousePos = e.GetPosition(PlanCanvas);
                Canvas.SetLeft(draggedElement, mousePos.X - mouseOffset.X);
                Canvas.SetTop(draggedElement, mousePos.Y - mouseOffset.Y);
            }
        }

        private void PlanCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is UIElement element)
            {
                draggedElement = element;
                mouseOffset = e.GetPosition(element);
                isDragging = true;
                element.CaptureMouse();
            }
        }

        private void PlanCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedElement != null)
            {
                draggedElement.ReleaseMouseCapture();
                isDragging = false;
                draggedElement = null;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Код для сохранения изменений
            MessageBox.Show("Изменения сохранены!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Код для отмены изменений
            MessageBox.Show("Изменения отменены!");
        }
    }
}
