using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PartitionWarehouse:JdObject{
      [JsonProperty("venderId")]
public 				long[]

             venderId
 { get; set; }
      [JsonProperty("seq_num")]
public 				long[]

                                                                                     seqNum
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("use_flag")]
public 				int[]

                                                                                     useFlag
 { get; set; }
      [JsonProperty("type")]
public 				int[]

             type
 { get; set; }
	}
}
