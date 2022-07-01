using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class GoodsRecord:JdObject{
      [JsonProperty("bondedArea")]
public 				string

             bondedArea
 { get; set; }
      [JsonProperty("platformId")]
public 				string

             platformId
 { get; set; }
      [JsonProperty("platformName")]
public 				string

             platformName
 { get; set; }
      [JsonProperty("venderId")]
public 				string

             venderId
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("isvGoodsNo")]
public 				string

             isvGoodsNo
 { get; set; }
      [JsonProperty("ccProvider")]
public 				string

             ccProvider
 { get; set; }
      [JsonProperty("pattern")]
public 				string

             pattern
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("barcodes")]
public 				string

             barcodes
 { get; set; }
      [JsonProperty("postChangeType")]
public 				string

             postChangeType
 { get; set; }
      [JsonProperty("brand")]
public 				string

             brand
 { get; set; }
      [JsonProperty("brandEn")]
public 				string

             brandEn
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("goodsNameEn")]
public 				string

             goodsNameEn
 { get; set; }
      [JsonProperty("modelNumber")]
public 				string

             modelNumber
 { get; set; }
      [JsonProperty("spe")]
public 				string

             spe
 { get; set; }
      [JsonProperty("unit")]
public 				string

             unit
 { get; set; }
      [JsonProperty("grossWeight")]
public 				string

             grossWeight
 { get; set; }
      [JsonProperty("netWeight")]
public 				string

             netWeight
 { get; set; }
      [JsonProperty("hsCode")]
public 				string

             hsCode
 { get; set; }
      [JsonProperty("vatRate")]
public 				int

             vatRate
 { get; set; }
      [JsonProperty("taxRate")]
public 				int

             taxRate
 { get; set; }
      [JsonProperty("hgsbys")]
public 				string

             hgsbys
 { get; set; }
      [JsonProperty("function")]
public 				string

             function
 { get; set; }
      [JsonProperty("purpose")]
public 				string

             purpose
 { get; set; }
      [JsonProperty("composition")]
public 				string

             composition
 { get; set; }
      [JsonProperty("enterpriseName")]
public 				string

             enterpriseName
 { get; set; }
      [JsonProperty("enterpriseAddress")]
public 				string

             enterpriseAddress
 { get; set; }
      [JsonProperty("country")]
public 				string

             country
 { get; set; }
      [JsonProperty("qiCountry")]
public 				string

             qiCountry
 { get; set; }
      [JsonProperty("originRegion")]
public 				string

             originRegion
 { get; set; }
      [JsonProperty("goodsCostPrice")]
public 				string

             goodsCostPrice
 { get; set; }
      [JsonProperty("goodsSellerPrice")]
public 				string

             goodsSellerPrice
 { get; set; }
      [JsonProperty("volume")]
public 				string

             volume
 { get; set; }
      [JsonProperty("safeDays")]
public 				int

             safeDays
 { get; set; }
      [JsonProperty("saleWebPage")]
public 				string

             saleWebPage
 { get; set; }
      [JsonProperty("contacts")]
public 				string

             contacts
 { get; set; }
      [JsonProperty("email")]
public 				string

             email
 { get; set; }
      [JsonProperty("telephone")]
public 				string

             telephone
 { get; set; }
      [JsonProperty("recordSuccess")]
public 				byte

             recordSuccess
 { get; set; }
      [JsonProperty("sellerRecord")]
public 				string

             sellerRecord
 { get; set; }
      [JsonProperty("customRecord")]
public 				string

             customRecord
 { get; set; }
      [JsonProperty("qiRecord")]
public 				string

             qiRecord
 { get; set; }
      [JsonProperty("taxNumberPost")]
public 				string

             taxNumberPost
 { get; set; }
      [JsonProperty("postRate")]
public 				string

             postRate
 { get; set; }
      [JsonProperty("measurement")]
public 				string

             measurement
 { get; set; }
      [JsonProperty("qiMeasurement")]
public 				string

             qiMeasurement
 { get; set; }
      [JsonProperty("legalUnit1")]
public 				string

             legalUnit1
 { get; set; }
      [JsonProperty("legalAmount1")]
public 				string

             legalAmount1
 { get; set; }
      [JsonProperty("legalUnit2")]
public 				string

             legalUnit2
 { get; set; }
      [JsonProperty("legalAmount2")]
public 				string

             legalAmount2
 { get; set; }
      [JsonProperty("itemNo")]
public 				string

             itemNo
 { get; set; }
	}
}
