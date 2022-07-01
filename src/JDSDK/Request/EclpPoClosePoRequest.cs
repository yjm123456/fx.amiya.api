using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpPoClosePoRequest : JdRequestBase<EclpPoClosePoResponse>
    {
                                                                                                                                              public  		string
              poOrderNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.po.closePo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("poOrderNo", this.            poOrderNo
);
                                                                                                                            }
    }
}





        
 

