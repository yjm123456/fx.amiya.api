using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BookOrderVO:JdObject{
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("salesOrderNo")]
public 				string

             salesOrderNo
 { get; set; }
      [JsonProperty("companyType")]
public 				string

             companyType
 { get; set; }
      [JsonProperty("seviceSkuCode")]
public 				string

             seviceSkuCode
 { get; set; }
      [JsonProperty("seviceSkuName")]
public 				string

             seviceSkuName
 { get; set; }
      [JsonProperty("itemCode")]
public 				string

             itemCode
 { get; set; }
      [JsonProperty("itemName")]
public 				string

             itemName
 { get; set; }
      [JsonProperty("productSn")]
public 				string

             productSn
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
      [JsonProperty("userName")]
public 				string

             userName
 { get; set; }
      [JsonProperty("userMobile")]
public 				string

             userMobile
 { get; set; }
      [JsonProperty("userProvince")]
public 				string

             userProvince
 { get; set; }
      [JsonProperty("userCity")]
public 				string

             userCity
 { get; set; }
      [JsonProperty("userCounty")]
public 				string

             userCounty
 { get; set; }
      [JsonProperty("userTown")]
public 				string

             userTown
 { get; set; }
      [JsonProperty("userAddress")]
public 				string

             userAddress
 { get; set; }
      [JsonProperty("userAreaId")]
public 				string

             userAreaId
 { get; set; }
      [JsonProperty("itemCatName")]
public 				string

             itemCatName
 { get; set; }
      [JsonProperty("buyDate")]
public 				DateTime

             buyDate
 { get; set; }
      [JsonProperty("buyShop")]
public 				string

             buyShop
 { get; set; }
      [JsonProperty("inOrOut")]
public 				int

             inOrOut
 { get; set; }
      [JsonProperty("salesOrderState")]
public 				string

             salesOrderState
 { get; set; }
      [JsonProperty("failureName")]
public 				string

             failureName
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
      [JsonProperty("wishBookDate")]
public 				string

             wishBookDate
 { get; set; }
      [JsonProperty("deliverCompany")]
public 				string

             deliverCompany
 { get; set; }
      [JsonProperty("deliverNo")]
public 				string

             deliverNo
 { get; set; }
      [JsonProperty("deliverArriveDate")]
public 				DateTime

             deliverArriveDate
 { get; set; }
	}
}
