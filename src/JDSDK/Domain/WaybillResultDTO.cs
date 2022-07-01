using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillResultDTO:JdObject{
      [JsonProperty("waybillCodeList")]
public 				List<string>

             waybillCodeList
 { get; set; }
      [JsonProperty("platformOrderNo")]
public 				string

             platformOrderNo
 { get; set; }
	}
}
