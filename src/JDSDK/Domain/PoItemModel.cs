using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PoItemModel:JdObject{
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("numApplication")]
public 				string

             numApplication
 { get; set; }
      [JsonProperty("goodsStatus")]
public 				string

             goodsStatus
 { get; set; }
      [JsonProperty("realInstoreQty")]
public 				string

             realInstoreQty
 { get; set; }
      [JsonProperty("shortQty")]
public 				string

             shortQty
 { get; set; }
      [JsonProperty("damagedQty")]
public 				string

             damagedQty
 { get; set; }
      [JsonProperty("emptyQty")]
public 				string

             emptyQty
 { get; set; }
      [JsonProperty("expiredQty")]
public 				string

             expiredQty
 { get; set; }
      [JsonProperty("otherQty")]
public 				string

             otherQty
 { get; set; }
      [JsonProperty("goodsDamagedQty")]
public 				string

             goodsDamagedQty
 { get; set; }
      [JsonProperty("deformedQty")]
public 				string

             deformedQty
 { get; set; }
      [JsonProperty("errorQty")]
public 				string

             errorQty
 { get; set; }
      [JsonProperty("excessQty")]
public 				string

             excessQty
 { get; set; }
      [JsonProperty("barcodeScanFailQty")]
public 				string

             barcodeScanFailQty
 { get; set; }
      [JsonProperty("expirationDateErrorQty")]
public 				string

             expirationDateErrorQty
 { get; set; }
      [JsonProperty("barcodeErrorQty")]
public 				string

             barcodeErrorQty
 { get; set; }
      [JsonProperty("pollutionQty")]
public 				string

             pollutionQty
 { get; set; }
      [JsonProperty("markUnclearQty")]
public 				string

             markUnclearQty
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("orderLine")]
public 				string

             orderLine
 { get; set; }
      [JsonProperty("realGoodsStatus")]
public 				string

             realGoodsStatus
 { get; set; }
      [JsonProperty("realGoodsLevel")]
public 				string

             realGoodsLevel
 { get; set; }
      [JsonProperty("batchCode")]
public 				string

             batchCode
 { get; set; }
	}
}
