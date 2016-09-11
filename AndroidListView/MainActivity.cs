using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Collections;
using Android.Views;

namespace AndroidListView
{
	[Activity(Label = "AndroidListView", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var items = new List<MyListItem>() {
				new MyListItem() { Title = "Item 1", Color = Android.Graphics.Color.Red },
				new MyListItem() { Title = "Item 2", Color = Android.Graphics.Color.Bisque },
				new MyListItem() { Title = "Item 3", Color = Android.Graphics.Color.BlueViolet }
			};

			ListAdapter = new MyListAdapter(this, items);
		}
	}

	public class MyListItem
	{
		public string Title { get; set; }
		public Android.Graphics.Color Color { get; set; }
	}

	public class MyListAdapter : BaseAdapter<MyListItem>
	{
		IList<MyListItem> items;
		Activity context;

		public MyListAdapter(Activity context, IList<MyListItem> items) : base()
		{
			this.context = context;
			this.items = items;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override MyListItem this[int position]
		{
			get { return items[position]; }
		}

		public override int Count
		{
			get { return items.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

			MyListItem item = items[position];
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Title;

			view.SetBackgroundColor(item.Color);

			return view;
		}
	}


}


