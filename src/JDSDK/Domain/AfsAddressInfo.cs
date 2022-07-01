using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsAddressInfo:JdObject{
      [JsonProperty("companyId")]
public 				int

             companyId
 { get; set; }
      [JsonProperty("typeId")]
public 				int

             typeId
 { get; set; }
      [JsonProperty("addressId")]
public 				int

             addressId
 { get; set; }
      [JsonProperty("contactName")]
public 				string

             contactName
 { get; set; }
      [JsonProperty("contactTel")]
public 				string

             contactTel
 { get; set; }
      [JsonProperty("contactZipcode")]
public 				string

             contactZipcode
 { get; set; }
      [JsonProperty("provinceCode")]
public 				int

             provinceCode
 { get; set; }
      [JsonProperty("detailAddress")]
public 				string

             detailAddress
 { get; set; }
	}
}
