using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SalesForecastDTO:JdObject{
      [JsonProperty("id")]
public 				long[]

             id
 { get; set; }
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("wareCodeJD")]
public 				string

             wareCodeJD
 { get; set; }
      [JsonProperty("wareCodeVendor")]
public 				string

             wareCodeVendor
 { get; set; }
      [JsonProperty("brandCode")]
public 				string

             brandCode
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
      [JsonProperty("categoryCode")]
public 				string

             categoryCode
 { get; set; }
      [JsonProperty("categoryName")]
public 				string

             categoryName
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("deliverCenterID")]
public 				string

             deliverCenterID
 { get; set; }
      [JsonProperty("deliverCenter")]
public 				string

             deliverCenter
 { get; set; }
      [JsonProperty("bandInfo")]
public 				string

             bandInfo
 { get; set; }
      [JsonProperty("baseSales")]
public 				string

             baseSales
 { get; set; }
      [JsonProperty("promotionSales")]
public 				string

             promotionSales
 { get; set; }
      [JsonProperty("salesAdjustment")]
public 				string

             salesAdjustment
 { get; set; }
      [JsonProperty("totalSalesForecast")]
public 				string

             totalSalesForecast
 { get; set; }
      [JsonProperty("canPurchaseStock")]
public 				string

             canPurchaseStock
 { get; set; }
      [JsonProperty("endingDateStock")]
public 				string

             endingDateStock
 { get; set; }
      [JsonProperty("replenishmentQuantity")]
public 				string

             replenishmentQuantity
 { get; set; }
      [JsonProperty("stockUpCycle")]
public 				string

             stockUpCycle
 { get; set; }
      [JsonProperty("nrt")]
public 				string

             nrt
 { get; set; }
      [JsonProperty("vlt")]
public 				string

             vlt
 { get; set; }
      [JsonProperty("replenishmentPoint")]
public 				string

             replenishmentPoint
 { get; set; }
      [JsonProperty("targetStockDays")]
public 				string

             targetStockDays
 { get; set; }
      [JsonProperty("targetStockQuantity")]
public 				string

             targetStockQuantity
 { get; set; }
      [JsonProperty("forecastTime")]
public 				DateTime

             forecastTime
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
	}
}
