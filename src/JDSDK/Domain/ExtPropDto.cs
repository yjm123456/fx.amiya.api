using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ExtPropDto:JdObject{
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
      [JsonProperty("is_key_property")]
public 				int

                                                                                                                     isKeyProperty
 { get; set; }
      [JsonProperty("is_custom")]
public 				int

                                                                                     isCustom
 { get; set; }
      [JsonProperty("is_multi_sele")]
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
      [JsonProperty("values")]
public 				List<string>

             values
 { get; set; }
	}
}
