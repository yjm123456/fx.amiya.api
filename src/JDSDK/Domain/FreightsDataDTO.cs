using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FreightsDataDTO:JdObject{
      [JsonProperty("bizCode")]
public 				int

             bizCode
 { get; set; }
      [JsonProperty("bizMessage")]
public 				string

             bizMessage
 { get; set; }
      [JsonProperty("generalInfo")]
public 				GeneralFreightsDTO

             generalInfo
 { get; set; }
      [JsonProperty("detailInfo")]
public 				List<string>

             detailInfo
 { get; set; }
	}
}
