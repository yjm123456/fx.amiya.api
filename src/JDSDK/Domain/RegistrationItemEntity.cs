using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RegistrationItemEntity:JdObject{
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("sex")]
public 				string

             sex
 { get; set; }
      [JsonProperty("birthday")]
public 				DateTime

             birthday
 { get; set; }
      [JsonProperty("idNumber")]
public 				string

             idNumber
 { get; set; }
      [JsonProperty("nationality")]
public 				string

             nationality
 { get; set; }
      [JsonProperty("homeAddress")]
public 				string

             homeAddress
 { get; set; }
      [JsonProperty("addressDetail")]
public 				string

             addressDetail
 { get; set; }
      [JsonProperty("phoneNumber")]
public 				string

             phoneNumber
 { get; set; }
      [JsonProperty("email")]
public 				string

             email
 { get; set; }
      [JsonProperty("emergencyContact")]
public 				string

             emergencyContact
 { get; set; }
      [JsonProperty("emergencyContactNumber")]
public 				string

             emergencyContactNumber
 { get; set; }
      [JsonProperty("clothingSize")]
public 				string

             clothingSize
 { get; set; }
      [JsonProperty("beastResult")]
public 				string

             beastResult
 { get; set; }
      [JsonProperty("certificatePictureUrl")]
public 				string

             certificatePictureUrl
 { get; set; }
      [JsonProperty("job")]
public 				string

             job
 { get; set; }
      [JsonProperty("informationChannel")]
public 				string

             informationChannel
 { get; set; }
	}
}
