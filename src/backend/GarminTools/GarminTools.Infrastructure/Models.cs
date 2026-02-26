// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);

using System.Text.Json.Serialization;

public class ActivityType
    {
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("typeKey")]
        public string TypeKey { get; set; }

        [JsonPropertyName("parentTypeId")]
        public int ParentTypeId { get; set; }

        [JsonPropertyName("isHidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("restricted")]
        public bool Restricted { get; set; }

        [JsonPropertyName("trimmable")]
        public bool Trimmable { get; set; }
    }

    public class ActivityTypeId
    {
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("typeKey")]
        public string TypeKey { get; set; }

        [JsonPropertyName("parentTypeId")]
        public int ParentTypeId { get; set; }

        [JsonPropertyName("isHidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("restricted")]
        public bool Restricted { get; set; }

        [JsonPropertyName("trimmable")]
        public bool Trimmable { get; set; }
    }

    public class PrivacyRule
    {
        [JsonPropertyName("typeId")]
        public int TypeId { get; set; }

        [JsonPropertyName("typeKey")]
        public string TypeKey { get; set; }
    }

    public class Course
    {
        [JsonPropertyName("courseId")]
        public int CourseId { get; set; }

        [JsonPropertyName("userProfileId")]
        public int UserProfileId { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("userGroupId")]
        public object UserGroupId { get; set; }

        [JsonPropertyName("geoRoutePk")]
        public object GeoRoutePk { get; set; }

        [JsonPropertyName("activityType")]
        public ActivityType ActivityType { get; set; }

        [JsonPropertyName("courseName")]
        public string CourseName { get; set; }

        [JsonPropertyName("courseDescription")]
        public object CourseDescription { get; set; }

        [JsonPropertyName("createdDate")]
        public object CreatedDate { get; set; }

        [JsonPropertyName("updatedDate")]
        public object UpdatedDate { get; set; }

        [JsonPropertyName("privacyRule")]
        public PrivacyRule PrivacyRule { get; set; }

        [JsonPropertyName("distanceInMeters")]
        public double DistanceInMeters { get; set; }

        [JsonPropertyName("elevationGainInMeters")]
        public double ElevationGainInMeters { get; set; }

        [JsonPropertyName("elevationLossInMeters")]
        public double ElevationLossInMeters { get; set; }

        [JsonPropertyName("startLatitude")]
        public double StartLatitude { get; set; }

        [JsonPropertyName("startLongitude")]
        public double StartLongitude { get; set; }

        [JsonPropertyName("speedInMetersPerSecond")]
        public double SpeedInMetersPerSecond { get; set; }

        [JsonPropertyName("sourceTypeId")]
        public int SourceTypeId { get; set; }

        [JsonPropertyName("sourcePk")]
        public long? SourcePk { get; set; }

        [JsonPropertyName("elapsedSeconds")]
        public double? ElapsedSeconds { get; set; }

        [JsonPropertyName("coordinateSystem")]
        public string CoordinateSystem { get; set; }

        [JsonPropertyName("originalCoordinateSystem")]
        public string OriginalCoordinateSystem { get; set; }

        [JsonPropertyName("consumer")]
        public string Consumer { get; set; }

        [JsonPropertyName("elevationSource")]
        public int ElevationSource { get; set; }

        [JsonPropertyName("hasShareableEvent")]
        public bool HasShareableEvent { get; set; }

        [JsonPropertyName("hasPaceBand")]
        public bool HasPaceBand { get; set; }

        [JsonPropertyName("hasPowerGuide")]
        public bool HasPowerGuide { get; set; }

        [JsonPropertyName("favorite")]
        public bool Favorite { get; set; }

        [JsonPropertyName("hasTurnDetectionDisabled")]
        public bool HasTurnDetectionDisabled { get; set; }

        [JsonPropertyName("curatedCourseId")]
        public object CuratedCourseId { get; set; }

        [JsonPropertyName("startNote")]
        public object StartNote { get; set; }

        [JsonPropertyName("finishNote")]
        public object FinishNote { get; set; }

        [JsonPropertyName("cutoffDuration")]
        public object CutoffDuration { get; set; }

        [JsonPropertyName("activityTypeId")]
        public ActivityTypeId ActivityTypeId { get; set; }

        [JsonPropertyName("public")]
        public bool Public { get; set; }

        [JsonPropertyName("createdDateFormatted")]
        public string CreatedDateFormatted { get; set; }

        [JsonPropertyName("updatedDateFormatted")]
        public string UpdatedDateFormatted { get; set; }
    }

