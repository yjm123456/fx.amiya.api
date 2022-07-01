using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SupplierModel:JdObject{
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("deptName")]
public 				string

             deptName
 { get; set; }
      [JsonProperty("eclpSupplierNo")]
public 				string

             eclpSupplierNo
 { get; set; }
      [JsonProperty("supplierName")]
public 				string

             supplierName
 { get; set; }
      [JsonProperty("supplierType")]
public 				string

             supplierType
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("contacts")]
public 				string

             contacts
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("fax")]
public 				string

             fax
 { get; set; }
      [JsonProperty("email")]
public 				string

             email
 { get; set; }
      [JsonProperty("province")]
public 				string

             province
 { get; set; }
      [JsonProperty("city")]
public 				string

             city
 { get; set; }
      [JsonProperty("county")]
public 				string

             county
 { get; set; }
      [JsonProperty("town")]
public 				string

             town
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
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
