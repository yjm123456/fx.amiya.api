using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BatchOpenPresortRequestDto:JdObject{
      [JsonProperty("batchId")]
public 				long

             batchId
 { get; set; }
      [JsonProperty("responseCode")]
public 				int

             responseCode
 { get; set; }
      [JsonProperty("responseMessage")]
public 				string

             responseMessage
 { get; set; }
      [JsonProperty("provinceId")]
public 				int

             provinceId
 { get; set; }
      [JsonProperty("cityId")]
public 				int

             cityId
 { get; set; }
      [JsonProperty("countyId")]
public 				int

             countyId
 { get; set; }
      [JsonProperty("townId")]
public 				int

             townId
 { get; set; }
      [JsonProperty("fullAddress")]
public 				string

             fullAddress
 { get; set; }
      [JsonProperty("companyCode")]
public 				string

             companyCode
 { get; set; }
      [JsonProperty("waybillCode")]
public 				string

             waybillCode
 { get; set; }
      [JsonProperty("phoneCode")]
public 				string

             phoneCode
 { get; set; }
      [JsonProperty("provinceName")]
public 				string

             provinceName
 { get; set; }
      [JsonProperty("cityName")]
public 				string

             cityName
 { get; set; }
      [JsonProperty("countyName")]
public 				string

             countyName
 { get; set; }
      [JsonProperty("townName")]
public 				string

             townName
 { get; set; }
      [JsonProperty("lat")]
public 				double

             lat
 { get; set; }
      [JsonProperty("lng")]
public 				double

             lng
 { get; set; }
	}
}
