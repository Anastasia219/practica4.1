﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Xml.Linq;

namespace Practica4._1
{
    public static class Methods
    {
        public static BitmapImage GetBitmapImageFromBytes(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(bytes);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = memoryStream;
            image.EndInit();
            return image;
        }
        public static void TakeWarning(string text)
        {
            MessageBox.Show(text, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public static void TakeInformation(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static bool TakeChoice(string text)
        {
            MessageBoxResult result = MessageBox.Show(text, "Информация", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            return result == MessageBoxResult.Yes ? true : false;
        }
    }
}
