using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AdventGoodsStockDetail:JdObject{
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("stockStatus")]
public 				string

             stockStatus
 { get; set; }
      [JsonProperty("num")]
public 				int[]

             num
 { get; set; }
      [JsonProperty("ext1")]
public 				string

             ext1
 { get; set; }
      [JsonProperty("ext2")]
public 				string

             ext2
 { get; set; }
      [JsonProperty("ext3")]
public 				string

             ext3
 { get; set; }
      [JsonProperty("ext4")]
public 				string

             ext4
 { get; set; }
      [JsonProperty("ext5")]
public 				string

             ext5
 { get; set; }
	}
}
