using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SaleAttributeDto:JdObject{
      [JsonProperty("attr_dim")]
public 				int

                                                                                     attrDim
 { get; set; }
      [JsonProperty("attr_value")]
public 				string

                                                                                     attrValue
 { get; set; }
      [JsonProperty("attr_seq")]
public 				int

                                                                                     attrSeq
 { get; set; }
	}
}
