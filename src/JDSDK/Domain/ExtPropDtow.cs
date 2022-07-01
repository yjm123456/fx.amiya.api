using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ExtPropDtow:JdObject{
      [JsonProperty("att_id")]
public 				int

                                                                                     attId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("cid")]
public 				int

             cid
 { get; set; }
      [JsonProperty("cata_class")]
public 				int

                                                                                     cataClass
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("order_sort")]
public 				int

                                                                                     orderSort
 { get; set; }
      [JsonProperty("is_required")]
public 				int

                                                                                     isRequired
 { get; set; }
      [JsonProperty("is_shield")]
public 				int

                                                                                     isShield
 { get; set; }
      [JsonProperty("is_search")]
public 				int

                                                                                     isSearch
 { get; set; }
      [JsonProperty("is_keyProperty")]
public 				int

                                                                                     isKeyProperty
 { get; set; }
      [JsonProperty("is_custom")]
public 				int

                                                                                     isCustom
 { get; set; }
      [JsonProperty("is_multiSele")]
public 				int

                                                                                     isMultiSele
 { get; set; }
      [JsonProperty("col_num")]
public 				int

                                                                                     colNum
 { get; set; }
      [JsonProperty("yn")]
public 				int

             yn
 { get; set; }
      [JsonProperty("group_id")]
public 				int

                                                                                     groupId
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
      [JsonProperty("ext_prop_value")]
public 				List<string>

                                                                                                                     extPropValue
 { get; set; }
      [JsonProperty("valCount")]
public 				int

             valCount
 { get; set; }
	}
}
