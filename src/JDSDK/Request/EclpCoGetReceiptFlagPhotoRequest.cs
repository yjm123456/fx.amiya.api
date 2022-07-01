using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCoGetReceiptFlagPhotoRequest : JdRequestBase<EclpCoGetReceiptFlagPhotoResponse>
    {
                                                                                  public  		string
              lwbNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.co.getReceiptFlagPhoto";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("lwbNo", this.            lwbNo
);
                                                                                                                                                    }
    }
}





        
 

