using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddOrUpdateHouseResourceBrokerRequest : JdRequestBase<ErsFangAddOrUpdateHouseResourceBrokerResponse>
    {
                                                                                                                                              public  		Nullable<long>
              brokerId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              houseResourceId
 {get; set;}
                                                          
                                                          public  		string
              quotedPrice
 {get; set;}
                                                          
                                                          public  		string
              recommend
 {get; set;}
                                                          
                                                          public  		string
              orderNum
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.addOrUpdateHouseResourceBroker";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("brokerId", this.            brokerId
);
                                                                                                        parameters.Add("houseResourceId", this.            houseResourceId
);
                                                                                                        parameters.Add("quotedPrice", this.            quotedPrice
);
                                                                                                        parameters.Add("recommend", this.            recommend
);
                                                                                                        parameters.Add("orderNum", this.            orderNum
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                                            }
    }
}





        
 

