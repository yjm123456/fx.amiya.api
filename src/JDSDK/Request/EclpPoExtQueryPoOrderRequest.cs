using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpPoExtQueryPoOrderRequest : JdRequestBase<EclpPoExtQueryPoOrderResponse>
    {
                                                                                                                                              public  		string
              poOrderNo
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              queryItemFlag
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              queryBoxFlag
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              queryQcFlag
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.po.ext.queryPoOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("poOrderNo", this.            poOrderNo
);
                                                                                                        parameters.Add("queryItemFlag", this.            queryItemFlag
);
                                                                                                        parameters.Add("queryBoxFlag", this.            queryBoxFlag
);
                                                                                                        parameters.Add("queryQcFlag", this.            queryQcFlag
);
                                                                                                                            }
    }
}





        
 

