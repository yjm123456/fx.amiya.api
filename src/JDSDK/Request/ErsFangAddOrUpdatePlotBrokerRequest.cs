using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ErsFangAddOrUpdatePlotBrokerRequest : JdRequestBase<ErsFangAddOrUpdatePlotBrokerResponse>
    {
                                                                                                                                              public  		Nullable<long>
              brokerId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              plotId
 {get; set;}
                                                          
                                                          public  		string
              recommend
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityCode
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              sourceId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ers.fang.addOrUpdatePlotBroker";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("brokerId", this.            brokerId
);
                                                                                                        parameters.Add("plotId", this.            plotId
);
                                                                                                        parameters.Add("recommend", this.            recommend
);
                                                                                                        parameters.Add("cityCode", this.            cityCode
);
                                                                                                        parameters.Add("sourceId", this.            sourceId
);
                                                                                                                            }
    }
}





        
 

