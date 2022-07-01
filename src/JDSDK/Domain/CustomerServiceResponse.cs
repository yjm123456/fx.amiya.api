using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CustomerServiceResponse:JdObject{
      [JsonProperty("detailDataList")]
public 				List<string>

             detailDataList
 { get; set; }
      [JsonProperty("avgData")]
public 				DetailData

             avgData
 { get; set; }
      [JsonProperty("totalData")]
public 				DetailData

             totalData
 { get; set; }
	}
}
