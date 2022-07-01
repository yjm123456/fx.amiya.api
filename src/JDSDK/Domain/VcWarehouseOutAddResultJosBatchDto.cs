using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VcWarehouseOutAddResultJosBatchDto:JdObject{
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("resultMessage")]
public 				string

             resultMessage
 { get; set; }
      [JsonProperty("vcWareHouseOutInfoJosDtos")]
public 				List<string>

             vcWareHouseOutInfoJosDtos
 { get; set; }
	}
}
