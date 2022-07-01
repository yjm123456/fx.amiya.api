using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CoCreateLwbResultForQueryB2BSWbMain:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("resultMsg")]
public 				string

             resultMsg
 { get; set; }
      [JsonProperty("lwbMain")]
public 				LwbMain

             lwbMain
 { get; set; }
      [JsonProperty("waybillList")]
public 				List<string>

             waybillList
 { get; set; }
	}
}
