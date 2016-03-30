﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ExmpleApp.PlayerModule.Converters
{
    public class IndexElementConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            ListViewItem item = (ListViewItem)value;

            ListView lv = ItemsControl.ItemsControlFromItemContainer(item) as ListView;

            return lv.ItemContainerGenerator.IndexFromContainer(item)+1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
