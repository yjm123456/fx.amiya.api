using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosPage:JdObject{
      [JsonProperty("size")]
public 				int

             size
 { get; set; }
      [JsonProperty("nex_que_cod")]
public 				string

                                                                                                                     nexQueCod
 { get; set; }
      [JsonProperty("cur_que_cod")]
public 				string

                                                                                                                     curQueCod
 { get; set; }
      [JsonProperty("err_cod")]
public 				int

                                                                                     errCod
 { get; set; }
      [JsonProperty("err_msg")]
public 				string

                                                                                     errMsg
 { get; set; }
      [JsonProperty("content")]
public 				List<string>

             content
 { get; set; }
	}
}
