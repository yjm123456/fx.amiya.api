using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DeliverOrderTrackDTO:JdObject{
      [JsonProperty("ope_title")]
public 				string

                                                                                     opeTitle
 { get; set; }
      [JsonProperty("ope_remark")]
public 				string

                                                                                     opeRemark
 { get; set; }
      [JsonProperty("ope_name")]
public 				string

                                                                                     opeName
 { get; set; }
      [JsonProperty("ope_time")]
public 				string

                                                                                     opeTime
 { get; set; }
      [JsonProperty("way_bill_code")]
public 				string

                                                                                                                     wayBillCode
 { get; set; }
	}
}
