using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillQryFreightsResultDTO:JdObject{
      [JsonProperty("result")]
public 				bool

             result
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
      [JsonProperty("waybillCode")]
public 				string

             waybillCode
 { get; set; }
      [JsonProperty("totalFreights")]
public 				string

             totalFreights
 { get; set; }
      [JsonProperty("basicFreight")]
public 				string

             basicFreight
 { get; set; }
      [JsonProperty("boxCharge")]
public 				string

             boxCharge
 { get; set; }
      [JsonProperty("waybillExtraCharge")]
public 				WaybillExtraCharge

             waybillExtraCharge
 { get; set; }
      [JsonProperty("springFestivalPeakSurcharge")]
public 				string

             springFestivalPeakSurcharge
 { get; set; }
	}
}
