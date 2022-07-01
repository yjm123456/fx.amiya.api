using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderPrintDataResult:JdObject{
      [JsonProperty("api_order_print_result")]
public 				ApiOrderPrintData

                                                                                                                                                     apiOrderPrintResult
 { get; set; }
	}
}
