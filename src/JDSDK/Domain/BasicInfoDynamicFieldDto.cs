using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BasicInfoDynamicFieldDto:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("cid3")]
public 				int

             cid3
 { get; set; }
      [JsonProperty("field_id")]
public 				string

                                                                                     fieldId
 { get; set; }
      [JsonProperty("field_name")]
public 				string

                                                                                     fieldName
 { get; set; }
      [JsonProperty("field_length")]
public 				string

                                                                                     fieldLength
 { get; set; }
      [JsonProperty("field_value")]
public 				string

                                                                                     fieldValue
 { get; set; }
      [JsonProperty("field_type")]
public 				int

                                                                                     fieldType
 { get; set; }
      [JsonProperty("is_necessary")]
public 				int

                                                                                     isNecessary
 { get; set; }
      [JsonProperty("is_show")]
public 				int

                                                                                     isShow
 { get; set; }
      [JsonProperty("offset")]
public 				int

             offset
 { get; set; }
      [JsonProperty("limit")]
public 				int

             limit
 { get; set; }
	}
}
