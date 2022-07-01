using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class GoodsRecordQueryResult:JdObject{
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
      [JsonProperty("goodsRecordList")]
public 				List<string>

             goodsRecordList
 { get; set; }
	}
}
