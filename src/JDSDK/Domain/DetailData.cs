using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DetailData:JdObject{
      [JsonProperty("statTm")]
public 				string

             statTm
 { get; set; }
      [JsonProperty("sdate")]
public 				string

             sdate
 { get; set; }
      [JsonProperty("responseRate")]
public 				string

             responseRate
 { get; set; }
      [JsonProperty("respDuration")]
public 				double

             respDuration
 { get; set; }
      [JsonProperty("avgResponseTime")]
public 				string

             avgResponseTime
 { get; set; }
      [JsonProperty("reception30Num")]
public 				double

             reception30Num
 { get; set; }
      [JsonProperty("medalNum")]
public 				double

             medalNum
 { get; set; }
      [JsonProperty("evaluationNum")]
public 				double

             evaluationNum
 { get; set; }
      [JsonProperty("satisfactionPlusNum")]
public 				double

             satisfactionPlusNum
 { get; set; }
      [JsonProperty("receptionNum")]
public 				double

             receptionNum
 { get; set; }
      [JsonProperty("responseRate30")]
public 				string

             responseRate30
 { get; set; }
      [JsonProperty("respTimes")]
public 				double

             respTimes
 { get; set; }
      [JsonProperty("satisfactionNum")]
public 				double

             satisfactionNum
 { get; set; }
      [JsonProperty("consultationNum")]
public 				double

             consultationNum
 { get; set; }
      [JsonProperty("satisfactionRate")]
public 				string

             satisfactionRate
 { get; set; }
	}
}
