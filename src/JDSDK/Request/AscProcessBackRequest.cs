using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscProcessBackRequest : JdRequestBase<AscProcessBackResponse>
    {
                                                                                                                                                                                                                                                 public  		string
              buId
 {get; set;}
                                                          
                                                          public  		string
              operatePin
 {get; set;}
                                                          
                                                          public  		string
              operateNick
 {get; set;}
                                                          
                                                          public  		string
              operateRemark
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sysVersion
 {get; set;}
                                                          
                                                          public  		string
              consigneeName
 {get; set;}
                                                          
                                                          public  		string
              consigneeTel
 {get; set;}
                                                          
                                                                                                                      public  		Nullable<int>
              provinceCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              countyCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              villageCode
 {get; set;}
                                                          
                                                          public  		string
              detailAddress
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              repairState
 {get; set;}
                                                          
                                                          public  		string
              applyRemark
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              shipWayId
 {get; set;}
                                                          
                                                          public  		string
              shipWayName
 {get; set;}
                                                          
                                                          public  		string
              expressCode
 {get; set;}
                                                          
                                                          public  		string
              partCodes
 {get; set;}
                                                          
                                                          public  		string
              extJsonStr
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              wareNum
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.process.back";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("operatePin", this.            operatePin
);
                                                                                                        parameters.Add("operateNick", this.            operateNick
);
                                                                                                        parameters.Add("operateRemark", this.            operateRemark
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("sysVersion", this.            sysVersion
);
                                                                                                        parameters.Add("consigneeName", this.            consigneeName
);
                                                                                                        parameters.Add("consigneeTel", this.            consigneeTel
);
                                                                                                                                                parameters.Add("provinceCode", this.            provinceCode
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("countyCode", this.            countyCode
);
                                                                                                        parameters.Add("villageCode", this.            villageCode
);
                                                                                                        parameters.Add("detailAddress", this.            detailAddress
);
                                                                                                                                parameters.Add("repairState", this.            repairState
);
                                                                                                        parameters.Add("applyRemark", this.            applyRemark
);
                                                                                                        parameters.Add("shipWayId", this.            shipWayId
);
                                                                                                        parameters.Add("shipWayName", this.            shipWayName
);
                                                                                                        parameters.Add("expressCode", this.            expressCode
);
                                                                                                        parameters.Add("partCodes", this.            partCodes
);
                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                                                        parameters.Add("wareNum", this.            wareNum
);
                                                                            }
    }
}





        
 

