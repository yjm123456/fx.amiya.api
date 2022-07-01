using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OpenOmbJosModifyRequest : JdRequestBase<OpenOmbJosModifyResponse>
    {
                                                                                                                                              public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              weight
 {get; set;}
                                                          
                                                          public  		string
              receiveTownName
 {get; set;}
                                                          
                                                          public  		string
              receiveCityName
 {get; set;}
                                                          
                                                          public  		string
              operateTime
 {get; set;}
                                                          
                                                          public  		string
              receiveTel
 {get; set;}
                                                          
                                                          public  		string
              receiveMobile
 {get; set;}
                                                          
                                                          public  		string
              receiveCountyName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiveProvinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiveTownId
 {get; set;}
                                                          
                                                          public  		string
              operateUser
 {get; set;}
                                                          
                                                          public  		string
              waybillCode
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                                                           public  	    Nullable<double>
              volume
 {get; set;}
                                                          
                                                          public  		string
              receiveName
 {get; set;}
                                                          
                                                          public  		string
              receiveProvinceName
 {get; set;}
                                                          
                                                          public  		string
              senderStation
 {get; set;}
                                                          
                                                          public  		string
              deliverStation
 {get; set;}
                                                          
                                                          public  		string
              receiveAddress
 {get; set;}
                                                          
                                                                                                                                                                                        public  		Nullable<int>
              receiveCityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiveCountyId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.open.omb.jos.modify";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("weight", this.            weight
);
                                                                                                        parameters.Add("receiveTownName", this.            receiveTownName
);
                                                                                                        parameters.Add("receiveCityName", this.            receiveCityName
);
                                                                                                        parameters.Add("operateTime", this.            operateTime
);
                                                                                                        parameters.Add("receiveTel", this.            receiveTel
);
                                                                                                        parameters.Add("receiveMobile", this.            receiveMobile
);
                                                                                                        parameters.Add("receiveCountyName", this.            receiveCountyName
);
                                                                                                        parameters.Add("receiveProvinceId", this.            receiveProvinceId
);
                                                                                                        parameters.Add("receiveTownId", this.            receiveTownId
);
                                                                                                        parameters.Add("operateUser", this.            operateUser
);
                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                                                                        parameters.Add("volume", this.            volume
);
                                                                                                        parameters.Add("receiveName", this.            receiveName
);
                                                                                                        parameters.Add("receiveProvinceName", this.            receiveProvinceName
);
                                                                                                        parameters.Add("senderStation", this.            senderStation
);
                                                                                                        parameters.Add("deliverStation", this.            deliverStation
);
                                                                                                        parameters.Add("receiveAddress", this.            receiveAddress
);
                                                                                                                                                                                                                        parameters.Add("receiveCityId", this.            receiveCityId
);
                                                                                                        parameters.Add("receiveCountyId", this.            receiveCountyId
);
                                                                            }
    }
}





        
 

