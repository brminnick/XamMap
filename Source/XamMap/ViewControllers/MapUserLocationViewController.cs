using System;

using UIKit;

using MapKit;

namespace XamMap
{
	public partial class MapUserLocationViewController : UIViewController
	{
		public MapUserLocationViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			MapHelpers.RequestLocationWhenInUse();

			MapHelpers.ShowUserLocation(MapView);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			MapView.DidUpdateUserLocation += HandleDidUpdateUserLocation;
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);

			MapView.DidUpdateUserLocation -= HandleDidUpdateUserLocation;
		}

		void HandleDidUpdateUserLocation(object sender, MKUserLocationEventArgs e) => MapHelpers.MoveMapToLocation(sender as MKMapView, true);
	}
}