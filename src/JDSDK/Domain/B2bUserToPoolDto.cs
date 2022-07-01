using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class B2bUserToPoolDto:JdObject{
      [JsonProperty("mappingId")]
public 				string

             mappingId
 { get; set; }
      [JsonProperty("attributeId")]
public 				string

             attributeId
 { get; set; }
      [JsonProperty("mappingLevel")]
public 				int

             mappingLevel
 { get; set; }
      [JsonProperty("b2bMappingId")]
public 				long

             b2bMappingId
 { get; set; }
      [JsonProperty("cateType")]
public 				int

             cateType
 { get; set; }
      [JsonProperty("wareMappingType")]
public 				int

             wareMappingType
 { get; set; }
      [JsonProperty("bizPoolType")]
public 				string

             bizPoolType
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("ext")]
public 				string

             ext
 { get; set; }
      [JsonProperty("editor")]
public 				string

             editor
 { get; set; }
      [JsonProperty("creator")]
public 				string

             creator
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("b2bPoolId")]
public 				long

             b2bPoolId
 { get; set; }
      [JsonProperty("b2bPoolName")]
public 				string

             b2bPoolName
 { get; set; }
      [JsonProperty("routerParam")]
public 				string

             routerParam
 { get; set; }
      [JsonProperty("cateId")]
public 				int

             cateId
 { get; set; }
      [JsonProperty("mappingType")]
public 				int

             mappingType
 { get; set; }
      [JsonProperty("thirdMappingId")]
public 				string

             thirdMappingId
 { get; set; }
      [JsonProperty("outerMappingId")]
public 				string

             outerMappingId
 { get; set; }
      [JsonProperty("dataSource")]
public 				int

             dataSource
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
