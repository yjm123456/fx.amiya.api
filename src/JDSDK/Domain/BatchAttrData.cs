using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BatchAttrData:JdObject{
      [JsonProperty("deptName")]
public 				string

             deptName
 { get; set; }
      [JsonProperty("sellerName")]
public 				string

             sellerName
 { get; set; }
      [JsonProperty("sellerNo")]
public 				string

             sellerNo
 { get; set; }
      [JsonProperty("logistics")]
public 				string

             logistics
 { get; set; }
      [JsonProperty("boxNumberAttr")]
public 				string

             boxNumberAttr
 { get; set; }
      [JsonProperty("warehouseName")]
public 				string

             warehouseName
 { get; set; }
      [JsonProperty("deptNo")]
public 				string

             deptNo
 { get; set; }
      [JsonProperty("manufacturer")]
public 				string

             manufacturer
 { get; set; }
      [JsonProperty("productionDate")]
public 				DateTime

             productionDate
 { get; set; }
      [JsonProperty("spareBatch")]
public 				string

             spareBatch
 { get; set; }
      [JsonProperty("poNo")]
public 				string

             poNo
 { get; set; }
      [JsonProperty("supplier")]
public 				string

             supplier
 { get; set; }
      [JsonProperty("stockNum")]
public 				int

             stockNum
 { get; set; }
      [JsonProperty("stockStatus")]
public 				int

             stockStatus
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("expirationDate")]
public 				DateTime

             expirationDate
 { get; set; }
      [JsonProperty("pluManagerBatchAttr")]
public 				string

             pluManagerBatchAttr
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("stockType")]
public 				int

             stockType
 { get; set; }
      [JsonProperty("goodsLevel")]
public 				string

             goodsLevel
 { get; set; }
      [JsonProperty("usableNum")]
public 				int

             usableNum
 { get; set; }
      [JsonProperty("packageBatchNo")]
public 				string

             packageBatchNo
 { get; set; }
      [JsonProperty("receiptDate")]
public 				DateTime

             receiptDate
 { get; set; }
      [JsonProperty("lotNumber")]
public 				string

             lotNumber
 { get; set; }
      [JsonProperty("store")]
public 				string

             store
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("supplierManage")]
public 				string

             supplierManage
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("originCountry")]
public 				string

             originCountry
 { get; set; }
      [JsonProperty("notMarketableAttr")]
public 				string

             notMarketableAttr
 { get; set; }
      [JsonProperty("isvGoodsNo")]
public 				string

             isvGoodsNo
 { get; set; }
      [JsonProperty("goodsBarcode")]
public 				string

             goodsBarcode
 { get; set; }
	}
}
