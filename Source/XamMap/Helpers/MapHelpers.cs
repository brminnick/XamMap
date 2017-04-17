using System;
using CoreLocation;
using MapKit;
namespace XamMap
{
	public static class MapHelpers
	{
		public static void MoveMapToLocation(MKMapView mapView, bool useGPS, CLLocationCoordinate2D coordinates = new CLLocationCoordinate2D())
		{
			switch (useGPS)
			{
				case true:
					if (mapView?.UserLocation == null)
						return;

					coordinates = mapView.UserLocation.Coordinate;
					break;

				case false:
					if (coordinates.Equals(new CLLocationCoordinate2D()))
						return;
					break;
			}

			MoveMapToLocation(mapView, coordinates);
		}

		public static void RequestLocationWhenInUse()
		{
			new CLLocationManager().RequestWhenInUseAuthorization();
		}

		public static void ShowUserLocation(MKMapView mapView)
		{
			mapView.ShowsUserLocation = true;
		}

		static double MilesToLatitudeDegrees(double miles)
		{
			double earthRadius = 3960.0;
			double radiansToDegrees = 180.0 / Math.PI;
			return (miles / earthRadius) * radiansToDegrees;
		}

		static double MilesToLongitudeDegrees(double miles, double atLatitude)
		{
			double earthRadius = 3960.0;
			double degreesToRadians = Math.PI / 180.0;
			double radiansToDegrees = 180.0 / Math.PI;

			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);

			return (miles / radiusAtLatitude) * radiansToDegrees;
		}

		static void MoveMapToLocation(MKMapView mapView, CLLocationCoordinate2D coordinates)
		{
			var mapSpan = new MKCoordinateSpan(MilesToLatitudeDegrees(2), MilesToLongitudeDegrees(2, coordinates.Latitude));

			mapView.SetRegion(new MKCoordinateRegion(coordinates, mapSpan), true);
		}
	}
}
