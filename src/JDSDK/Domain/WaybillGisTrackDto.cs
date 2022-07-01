using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillGisTrackDto:JdObject{
      [JsonProperty("waybillFinishFlag")]
public 				int

             waybillFinishFlag
 { get; set; }
      [JsonProperty("gpsFrequency")]
public 				int

             gpsFrequency
 { get; set; }
      [JsonProperty("gpsSource")]
public 				int

             gpsSource
 { get; set; }
      [JsonProperty("gpsSourceName")]
public 				string

             gpsSourceName
 { get; set; }
      [JsonProperty("courierCode")]
public 				string

             courierCode
 { get; set; }
      [JsonProperty("courierName")]
public 				string

             courierName
 { get; set; }
      [JsonProperty("courierMobile")]
public 				string

             courierMobile
 { get; set; }
      [JsonProperty("tplFlag")]
public 				int

             tplFlag
 { get; set; }
      [JsonProperty("arrivedTime")]
public 				string

             arrivedTime
 { get; set; }
      [JsonProperty("waybillGisDtoList")]
public 				List<string>

             waybillGisDtoList
 { get; set; }
	}
}
