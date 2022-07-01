using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ProductStock:JdObject{
      [JsonProperty("stock")]
public 				long

             stock
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
	}
}
