using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PropDto:JdObject{
      [JsonProperty("id")]
public 				int

             id
 { get; set; }
      [JsonProperty("order_sort")]
public 				int

                                                                                     orderSort
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("required")]
public 					bool

             required
 { get; set; }
      [JsonProperty("input_type")]
public 				int

                                                                                     inputType
 { get; set; }
      [JsonProperty("attr_alias")]
public 				string

                                                                                     attrAlias
 { get; set; }
      [JsonProperty("val_unit")]
public 				string

                                                                                     valUnit
 { get; set; }
      [JsonProperty("maintain_remark")]
public 				string

                                                                                     maintainRemark
 { get; set; }
      [JsonProperty("alias_content")]
public 				string

                                                                                     aliasContent
 { get; set; }
      [JsonProperty("choose_purchase")]
public 				int

                                                                                     choosePurchase
 { get; set; }
      [JsonProperty("values")]
public 				List<string>

             values
 { get; set; }
      [JsonProperty("valCount")]
public 				int

             valCount
 { get; set; }
	}
}
