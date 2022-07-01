using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsFreightOut:JdObject{
      [JsonProperty("afsFreightId")]
public 				int

             afsFreightId
 { get; set; }
      [JsonProperty("afsServiceId")]
public 				int

             afsServiceId
 { get; set; }
      [JsonProperty("partReceiveId")]
public 				int

             partReceiveId
 { get; set; }
      [JsonProperty("freightCode")]
public 				string

             freightCode
 { get; set; }
      [JsonProperty("expressCode")]
public 				string

             expressCode
 { get; set; }
      [JsonProperty("freightMoney")]
public 					string

             freightMoney
 { get; set; }
      [JsonProperty("modifiedMoney")]
public 					string

             modifiedMoney
 { get; set; }
      [JsonProperty("expressCompany")]
public 				string

             expressCompany
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
	}
}
