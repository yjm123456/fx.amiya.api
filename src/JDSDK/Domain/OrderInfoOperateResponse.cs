using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderInfoOperateResponse:JdObject{
      [JsonProperty("stateCode")]
public 				int

             stateCode
 { get; set; }
      [JsonProperty("stateMessage")]
public 				string

             stateMessage
 { get; set; }
	}
}
