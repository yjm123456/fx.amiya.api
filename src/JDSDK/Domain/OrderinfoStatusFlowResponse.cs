using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderinfoStatusFlowResponse:JdObject{
      [JsonProperty("state_value")]
public 				byte

                                                                                     stateValue
 { get; set; }
      [JsonProperty("state_time")]
public 				string

                                                                                     stateTime
 { get; set; }
      [JsonProperty("state_operator")]
public 				string

                                                                                     stateOperator
 { get; set; }
      [JsonProperty("state_remark")]
public 				string

                                                                                     stateRemark
 { get; set; }
	}
}
