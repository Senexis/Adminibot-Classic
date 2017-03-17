using System;
using System.Collections;
using System.Windows.Forms;

namespace th.AdminibotLegacy
{
    class ListViewItemMultiSort : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null || y == null) return 0;
            ListViewItem item1 = x as ListViewItem;
            ListViewItem item2 = y as ListViewItem;
            if (item1 == null || item2 == null) return 0;
            int comRes = String.CompareOrdinal(item1.Text, item2.Text);
            return comRes != 0 ? comRes :  String.CompareOrdinal(item1.SubItems[1].Text, item2.SubItems[1].Text);
        }
    }
}
