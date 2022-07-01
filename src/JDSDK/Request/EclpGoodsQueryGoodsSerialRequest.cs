using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpGoodsQueryGoodsSerialRequest : JdRequestBase<EclpGoodsQueryGoodsSerialResponse>
    {
                                                                                  public  		string
              bizNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.goods.queryGoodsSerial";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("bizNo", this.            bizNo
);
                                                                                                    }
    }
}





        
 

