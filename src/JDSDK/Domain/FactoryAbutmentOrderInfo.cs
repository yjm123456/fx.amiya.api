using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FactoryAbutmentOrderInfo:JdObject{
      [JsonProperty("orderno")]
public 				string

             orderno
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("factoryAbutmentServiceInfoList")]
public 				List<string>

             factoryAbutmentServiceInfoList
 { get; set; }
      [JsonProperty("orderServiceRemark")]
public 				string

             orderServiceRemark
 { get; set; }
      [JsonProperty("authorizedSequence")]
public 				string

             authorizedSequence
 { get; set; }
      [JsonProperty("customerName")]
public 				string

             customerName
 { get; set; }
      [JsonProperty("customerTel")]
public 				string

             customerTel
 { get; set; }
      [JsonProperty("serviceProvinceId")]
public 				string

             serviceProvinceId
 { get; set; }
      [JsonProperty("serviceCityId")]
public 				string

             serviceCityId
 { get; set; }
      [JsonProperty("serviceCountyId")]
public 				string

             serviceCountyId
 { get; set; }
      [JsonProperty("serviceDistrictId")]
public 				string

             serviceDistrictId
 { get; set; }
      [JsonProperty("serviceProvince")]
public 				string

             serviceProvince
 { get; set; }
      [JsonProperty("serviceCity")]
public 				string

             serviceCity
 { get; set; }
      [JsonProperty("serviceCounty")]
public 				string

             serviceCounty
 { get; set; }
      [JsonProperty("serviceDistrict")]
public 				string

             serviceDistrict
 { get; set; }
      [JsonProperty("serviceStreet")]
public 				string

             serviceStreet
 { get; set; }
      [JsonProperty("jdWareId")]
public 				string

             jdWareId
 { get; set; }
      [JsonProperty("factoryWareId")]
public 				string

             factoryWareId
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("serviceOrderId")]
public 				string

             serviceOrderId
 { get; set; }
      [JsonProperty("createOrderTime")]
public 				DateTime

             createOrderTime
 { get; set; }
      [JsonProperty("ImageUploadPath")]
public 				DateTime

             ImageUploadPath
 { get; set; }
      [JsonProperty("ImageDownloadPath")]
public 				DateTime

             ImageDownloadPath
 { get; set; }
      [JsonProperty("codDate")]
public 				DateTime

             codDate
 { get; set; }
      [JsonProperty("daJiaDianInstallDate")]
public 				DateTime

             daJiaDianInstallDate
 { get; set; }
      [JsonProperty("serviceDate")]
public 				DateTime

             serviceDate
 { get; set; }
      [JsonProperty("expectAtHomePeriod")]
public 				string

             expectAtHomePeriod
 { get; set; }
	}
}
