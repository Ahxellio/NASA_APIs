using NASA_APIs.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NASA_APIs.Models
{
    public class CloseApproachDatum
    {
        [JsonPropertyName("close_approach_date")]
        public string CloseApproachDate { get; set; }

        [JsonPropertyName("close_approach_date_full")]
        public string CloseApproachDateFull { get; set; }

        //[JsonPropertyName("epoch_date_close_approach")]
        //public int EpochDateCloseApproach { get; set; }

        [JsonPropertyName("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }

        [JsonPropertyName("miss_distance")]
        public MissDistance MissDistance { get; set; }

        [JsonPropertyName("orbiting_body")]
        public string OrbitingBody { get; set; }
    }

    public class EstimatedDiameter
    {
        [JsonPropertyName("kilometers")]
        public Kilometers Kilometers { get; set; }

        [JsonPropertyName("meters")]
        public Meters Meters { get; set; }


    }

    public class Kilometers
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }

    public class Meters
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }


    public class MissDistance
    {

        [JsonPropertyName("kilometers")]
        public string Kilometers { get; set; }

        [JsonPropertyName("miles")]
        public string Miles { get; set; }
    }

    public class OrbitalData
    {
        [JsonPropertyName("orbit_id")]
        public string OrbitId { get; set; }

        [JsonPropertyName("orbit_determination_date")]
        public string OrbitDeterminationDate { get; set; }

        [JsonPropertyName("first_observation_date")]
        public string FirstObservationDate { get; set; }

        [JsonPropertyName("last_observation_date")]
        public string LastObservationDate { get; set; }

        [JsonPropertyName("data_arc_in_days")]
        public int DataArcInDays { get; set; }

        [JsonPropertyName("observations_used")]
        public int ObservationsUsed { get; set; }

        [JsonPropertyName("orbit_uncertainty")]
        public string OrbitUncertainty { get; set; }

        [JsonPropertyName("minimum_orbit_intersection")]
        public string MinimumOrbitIntersection { get; set; }

        [JsonPropertyName("jupiter_tisserand_invariant")]
        public string JupiterTisserandInvariant { get; set; }

        [JsonPropertyName("epoch_osculation")]
        public string EpochOsculation { get; set; }

        [JsonPropertyName("eccentricity")]
        public string Eccentricity { get; set; }

        [JsonPropertyName("semi_major_axis")]
        public string SemiMajorAxis { get; set; }

        [JsonPropertyName("inclination")]
        public string Inclination { get; set; }

        [JsonPropertyName("ascending_node_longitude")]
        public string AscendingNodeLongitude { get; set; }

        [JsonPropertyName("orbital_period")]
        public string OrbitalPeriod { get; set; }

        [JsonPropertyName("orbit_class")]
        public OrbitClass OrbitClass { get; set; }
    }

    public class OrbitClass
    {
        [JsonPropertyName("orbit_class_type")]
        public string OrbitClassType { get; set; }

        [JsonPropertyName("orbit_class_description")]
        public string OrbitClassDescription { get; set; }

        [JsonPropertyName("orbit_class_range")]
        public string OrbitClassRange { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonPropertyName("kilometers_per_second")]
        public string KilometersPerSecond { get; set; }

        [JsonPropertyName("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }

        [JsonPropertyName("miles_per_hour")]
        public string MilesPerHour { get; set; }
    }

    public class NeoWsModel
    {
        [JsonPropertyName("links")]
        public Links Links { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("designation")]
        public string Designation { get; set; }

        [JsonPropertyName("nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonPropertyName("absolute_magnitude_h")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonPropertyName("close_approach_data")]
        public List<CloseApproachDatum> CloseApproachData { get; set; }

        [JsonPropertyName("orbital_data")]
        public OrbitalData OrbitalData { get; set; }

        [JsonPropertyName("is_sentry_object")]
        public bool IsSentryObject { get; set; }
    }


}
