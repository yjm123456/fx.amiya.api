using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AsmsVenderTaskDtoForOut:JdObject{
      [JsonProperty("dispatchTime")]
public 				DateTime

             dispatchTime
 { get; set; }
      [JsonProperty("contactName")]
public 				string

             contactName
 { get; set; }
      [JsonProperty("contactTel")]
public 				string

             contactTel
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("appointmentTime")]
public 				DateTime

             appointmentTime
 { get; set; }
      [JsonProperty("serviceProductSku")]
public 				long

             serviceProductSku
 { get; set; }
      [JsonProperty("serviceProductName")]
public 				string

             serviceProductName
 { get; set; }
      [JsonProperty("serviceProductSkuNum")]
public 				int

             serviceProductSkuNum
 { get; set; }
      [JsonProperty("serviceLeaveMessageJD")]
public 				List<string>

             serviceLeaveMessageJD
 { get; set; }
      [JsonProperty("serviceLeaveMessageCustomer")]
public 				int

             serviceLeaveMessageCustomer
 { get; set; }
      [JsonProperty("mainWareSku")]
public 				long

             mainWareSku
 { get; set; }
      [JsonProperty("mainWareName")]
public 				string

             mainWareName
 { get; set; }
      [JsonProperty("mainWareSn")]
public 				string

             mainWareSn
 { get; set; }
      [JsonProperty("mainWareArrivalTime")]
public 				DateTime

             mainWareArrivalTime
 { get; set; }
      [JsonProperty("serviceState")]
public 				int

             serviceState
 { get; set; }
      [JsonProperty("provinceId")]
public 				int

             provinceId
 { get; set; }
      [JsonProperty("provinceName")]
public 				string

             provinceName
 { get; set; }
      [JsonProperty("cityId")]
public 				int

             cityId
 { get; set; }
      [JsonProperty("cityName")]
public 				string

             cityName
 { get; set; }
      [JsonProperty("countyId")]
public 				int

             countyId
 { get; set; }
      [JsonProperty("countyName")]
public 				string

             countyName
 { get; set; }
      [JsonProperty("villageId")]
public 				int

             villageId
 { get; set; }
      [JsonProperty("villageName")]
public 				string

             villageName
 { get; set; }
	}
}
