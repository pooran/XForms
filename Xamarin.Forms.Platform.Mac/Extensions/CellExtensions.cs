using Foundation;
using System;
using Xamarin.Forms;

namespace Xamarin.Forms.Platform.Mac
{
	internal static class CellExtensions
	{
		internal static NSIndexPath GetIndexPath (this Cell self)
		{
			if (self == null)
				throw new ArgumentNullException ("self");
			if (self.Parent is ListView)
			{
				int num = 0;
				var group = TemplatedItemsList<ItemsView<Cell>, Cell>.GetGroup (self);
				if (group != null)
					num = TemplatedItemsList<ItemsView<Cell>, Cell>.GetIndex (group.HeaderContent);

				return NSIndexPath.FromItemSection ((nint)num, (nint)0);
				//return NSIndexPath.FromRowSection ((nint)TemplatedItemsList<ItemsView<Cell>, Cell>.GetIndex (self), (nint)num);
			}
			if (!(self.Parent is TableView))
				throw new NotSupportedException ("Unknown cell parent type");
			
			Tuple<int, int> path = TableView.TableSectionModel.GetPath (self);

			return NSIndexPath.FromItemSection ((nint)path.Item2, (nint)path.Item1);
		}
	}
}
