using Practica4._1.Components;
using Practica4._1.DBases;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Practica4._1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Sech.xaml
    /// </summary>
    public partial class Sech : Page
    {
        private List<ItemLocation> itemLocations = new List<ItemLocation>();
        public Sech()
        {
            InitializeComponent();
            WorkshopCb.ItemsSource = App.db.WorkshopItem.Where(x => x.IsWorkShop == true).ToList();
            WorkshopCb.SelectedIndex = 0;

            List<WorkshopItem> items = App.db.WorkshopItem.Where(x => x.IsWorkShop == false).ToList();
            foreach (WorkshopItem item in items)
                ItemPanel.Children.Add(new ItemControl(item));
        }

        private void Refresh()
        {
            foreach (var item in itemLocations)
                canvas.Children.Remove(item.image);
            itemLocations.Clear();
            WorkshopItem workshop = WorkshopCb.SelectedItem as WorkshopItem;
            PlanImage.Source = Methods.GetBitmapImageFromBytes(workshop.Photo);

            foreach (var item in (WorkshopCb.SelectedItem as WorkshopItem).Location)
            {
                ItemLocation itemLocation = new ItemLocation()
                {
                    item = item.WorkshopItem1,
                    location = item
                };
                itemLocations.Add(AddImageToCanvas(itemLocation));
                MoveImage(itemLocation.image,
                    new Point((double)itemLocation.location.FromLeft, (double)itemLocation.location.FromUp));
            }
        }
        

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in itemLocations)
            {
                if (item.location.Id == 0)
                {
                    App.db.Location.Add(item.location);
                }
            }
            App.db.SaveChanges();

            Methods.TakeInformation("Схема успешно сохранена!");
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            int a = itemLocations.Count;
            for(int i = 0; i < a; i++)
            {
                canvas.Children.Remove(itemLocations[i].image);
                if(itemLocations[i].location.Id != 0)
                    App.db.Location.Remove(itemLocations[i].location);
                
            }
            itemLocations.Clear();
            App.db.SaveChanges();
        }

        private void WorkshopCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is ItemLocation item)
            {
                if (item.image == null)
                    AddImageToCanvas(item);

                MoveImage(item.image, e.GetPosition(canvas));
            }
        }

        private ItemLocation AddImageToCanvas(ItemLocation item)
        {
            Image image = new Image { Source = Methods.GetBitmapImageFromBytes(item.item.Photo) };
            image.Width = 50;
            image.Height = 50;
            canvas.Children.Add(image);
            item.image = image;
            image.DataContext = item;
            image.MouseMove += image_MouseMove;
            return item;
        }

        private void MoveImage(Image image, Point point)
        {
            ItemLocation item = image.DataContext as ItemLocation;
            if (item.location == null)
            {
                item.location = new Location()
                {
                    IdWorkshop = (WorkshopCb.SelectedItem as WorkshopItem).Id,
                    IdItem = item.item.Id,
                    FromLeft = (decimal)point.X,
                    FromUp = (decimal)point.Y,
                };
                itemLocations.Add(item);
            }
            else
            {
                item.location.FromLeft = (decimal)point.X;
                item.location.FromUp = (decimal)point.Y;
            }

            Canvas.SetLeft(image, point.X);
            Canvas.SetTop(image, point.Y);
        }

        private void image_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Image image = sender as Image;
                DragDrop.DoDragDrop(image, new DataObject(DataFormats.Serializable,
                    image.DataContext as ItemLocation), DragDropEffects.Move);
            }
        }

        private void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double zoom = e.Delta > 0 ? 1.1 : 0.9;

            // Определите координаты точки под курсором мыши
            Point mousePosition = e.GetPosition(canvas);

            // Сохраните текущие трансформации
            double currentScaleX = scaleTransform.ScaleX;
            double currentScaleY = scaleTransform.ScaleY;
            double currentTranslateX = translateTransform.X;
            double currentTranslateY = translateTransform.Y;

            Point position = e.GetPosition(Origin);

            // Рассчитайте новую позицию для компенсации сдвига
            double newTranslateX = currentTranslateX - ((15 * (zoom == 0.9 ? -1 : 1)) * (position.X < 0 ? -1 : 3) * currentScaleX);
            double newTranslateY = currentTranslateY - ((15 * (zoom == 0.9 ? -1 : 1)) * (position.Y < 0 ? -1 : 3) * currentScaleY);


            // Примените новую трансформацию масштаба и позицию
            scaleTransform.ScaleX *= zoom;
            scaleTransform.ScaleY *= zoom;
            translateTransform.X = newTranslateX;
            translateTransform.Y = newTranslateY;
        }
    }
}

