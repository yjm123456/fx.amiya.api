using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DataVenderStrategyComputeGeneralByidRequest : JdRequestBase<DataVenderStrategyComputeGeneralByidResponse>
    {
                                                                                                                                                                                                                public  		string
                                                                                      strategyId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      strategyParam
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      pinType
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.data.vender.strategy.compute.general.byid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("strategy_id", this.                                                                                    strategyId
);
                                                                                                        parameters.Add("strategy_param", this.                                                                                    strategyParam
);
                                                                                                        parameters.Add("pin_type", this.                                                                                    pinType
);
                                                                                                                            }
    }
}





        
 

