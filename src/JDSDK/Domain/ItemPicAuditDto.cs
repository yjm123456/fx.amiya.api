using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ItemPicAuditDto:JdObject{
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
      [JsonProperty("operate_time")]
public 				string

                                                                                     operateTime
 { get; set; }
      [JsonProperty("erp_code")]
public 				string

                                                                                     erpCode
 { get; set; }
      [JsonProperty("opinion")]
public 				string

             opinion
 { get; set; }
      [JsonProperty("erp_name")]
public 				string

                                                                                     erpName
 { get; set; }
	}
}
