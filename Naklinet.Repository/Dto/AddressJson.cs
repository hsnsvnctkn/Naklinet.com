using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Dto
{

        public class Rootobject
        {
            public Response response { get; set; }
        }

        public class Response
        {
            public Geoobjectcollection GeoObjectCollection { get; set; }
        }

        public class Geoobjectcollection
        {
            public Metadataproperty metaDataProperty { get; set; }
            public Featuremember[] featureMember { get; set; }
        }

        public class Metadataproperty
        {
            public Geocoderresponsemetadata GeocoderResponseMetaData { get; set; }
        }

        public class Geocoderresponsemetadata
        {
            public string request { get; set; }
            public string results { get; set; }
            public string found { get; set; }
        }

        public class Featuremember
        {
            public Geoobject GeoObject { get; set; }
        }

        public class Geoobject
        {
            public Metadataproperty1 metaDataProperty { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public Boundedby boundedBy { get; set; }
            public Point Point { get; set; }
        }

        public class Metadataproperty1
        {
            public Geocodermetadata GeocoderMetaData { get; set; }
        }

        public class Geocodermetadata
        {
            public string precision { get; set; }
            public string text { get; set; }
            public string kind { get; set; }
            public Address Address { get; set; }
            public Addressdetails AddressDetails { get; set; }
        }

        public class Address
        {
            public string country_code { get; set; }
            public string formatted { get; set; }
            public Component[] Components { get; set; }
        }

        public class Component
        {
            public string kind { get; set; }
            public string name { get; set; }
        }

        public class Addressdetails
        {
            public Country Country { get; set; }
        }

        public class Country
        {
            public string AddressLine { get; set; }
            public string CountryNameCode { get; set; }
            public string CountryName { get; set; }
            public Administrativearea AdministrativeArea { get; set; }
        }

        public class Administrativearea
        {
            public string AdministrativeAreaName { get; set; }
            public Subadministrativearea SubAdministrativeArea { get; set; }
        }

        public class Subadministrativearea
        {
            public string SubAdministrativeAreaName { get; set; }
            public Locality Locality { get; set; }
        }

        public class Locality
        {
            public Dependentlocality DependentLocality { get; set; }
        }

        public class Dependentlocality
        {
            public string DependentLocalityName { get; set; }
        }

        public class Boundedby
        {
            public Envelope Envelope { get; set; }
        }

        public class Envelope
        {
            public string lowerCorner { get; set; }
            public string upperCorner { get; set; }
        }

        public class Point
        {
            public string pos { get; set; }
        }

    }
