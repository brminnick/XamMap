using System;

using UIKit;
using CoreLocation;
using MapKit;

namespace XamMap
{
	public partial class XamarinHQLocationViewController : UIViewController
	{
		readonly CLLocationCoordinate2D _xamarinHQCoordinates = new CLLocationCoordinate2D(37.7767687, -122.4166164);

		public XamarinHQLocationViewController(IntPtr handle) : base(handle)
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

			AddXamarinHQPinToMap();
			
			MapHelpers.MoveMapToLocation(MapView, false, _xamarinHQCoordinates);
		}

		void AddXamarinHQPinToMap()
		{
			var xamarinHQPointAnnotiation = new MKPointAnnotation
			{
				Title = "Xamarin HQ",
				Coordinate = _xamarinHQCoordinates
			};

			MapView.AddAnnotation(xamarinHQPointAnnotiation);

			MapView.SelectedAnnotations = new MKPointAnnotation[] { xamarinHQPointAnnotiation };
		}
	}
}